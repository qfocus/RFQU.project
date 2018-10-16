using CsvHelper;
using runmu.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using Unity;

namespace runmu
{
    public sealed class Importer
    {
        private IService studentService;
        private IService courseService;
        private IService assistantService;
        private IService platformService;
        private IService learnStatusService;
        private IService signService;
        private IService paymentService;
        private IService teacherService;

        public Importer(IUnityContainer container)
        {
            this.studentService = container.Resolve<StudentsService>();
            this.courseService = container.Resolve<CourseService>();
            this.assistantService = container.Resolve<AssistantService>();
            this.platformService = container.Resolve<PlatformService>();
            this.learnStatusService = container.Resolve<LearnStatusService>();
            this.signService = container.Resolve<SignUpService>();
            this.paymentService = container.Resolve<PaymentService>();
            this.teacherService = container.Resolve<TeacherService>();
        }

        public void ImportData(SQLiteConnection conn, String path)
        {
            TextReader textReader = File.OpenText(path);
            Dictionary<string, object> paras = new Dictionary<string, object>();
            CsvReader reader = new CsvReader(textReader);
            reader.Read();

            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> teachers = new Dictionary<string, int>();
            Dictionary<string, int> assistants = new Dictionary<string, int>();
            Dictionary<string, int> courses = new Dictionary<string, int>();
            Dictionary<string, int> signUp = new Dictionary<string, int>();
            while (reader.Read())
            {
                if (string.IsNullOrEmpty(reader[0]))
                {
                    continue;
                }
                string name = reader[4];
                int qq = Convert.ToInt32(reader[3]);
                if (qq == 0)
                {
                    continue;
                }
                if (!students.ContainsKey(name))
                {
                    Args[] student = new Args[]{new Args(AttributeName.NAME,name),
                                            new Args(AttributeName.ID,qq),
                                            new Args(AttributeName.Phone,""),
                                            new Args(AttributeName.Wechat,""),
                                            new Args(AttributeName.Email,"")};
                    studentService.Add(conn, student);
                    students.Add(name, qq);
                    Logger.Info("Add student " + qq);
                }

                string teacher = reader[9];
                if (!teachers.ContainsKey(teacher))
                {

                    Args[] arg = new Args[]{new Args(AttributeName.NAME, teacher),
                                            new Args(AttributeName.QQ,"" ),
                                            new Args(AttributeName.Alias,""),
                                            new Args(AttributeName.Email,""),};
                    int teacerId = teacherService.Add(conn, arg);
                    teachers.Add(teacher, teacerId);
                    Logger.Info("Add teacher " + teacher);
                }

                string assistant = reader[8];
                if (!assistants.ContainsKey(assistant))
                {
                    int assistantId = assistantService.Add(conn, new Args(AttributeName.NAME, assistant));
                    assistants.Add(assistant, assistantId);
                    Logger.Info("Add assistant " + assistant);
                }

                string course = reader[5];
                double price = Convert.ToDouble(reader[7]);
                if (!courses.ContainsKey(course))
                {
                    int teacherId = teachers[teacher];
                    Args[] args = new Args[]{new Args(AttributeName.NAME, course ),
                                             new Args( AttributeName.Price, price ),
                                             new Args( AttributeName.TeacherID, teacherId)};
                    int courseId = courseService.Add(conn, args);
                    courses.Add(course, courseId);
                    Logger.Info("Add course " + assistant);
                }

                string sign = qq + course;
                string payType = reader[1];
                string date = reader[2];
                DateTime signDate;
                if (string.IsNullOrEmpty(payType))
                {
                    payType = "全额";
                    DateTime.TryParse(date, out signDate);
                }
                else
                {
                    int index = date.IndexOf("年");
                    string year = date.Substring(0, index);
                    string month = date.Substring(index + 1, date.IndexOf("月") - index-1);
                    signDate = new DateTime(int.Parse(year), int.Parse(month), 1);
                }
                if (!signUp.ContainsKey(sign))
                {
                    int count = 1;
                    DataTable signed = signService.Query(conn, new Args(AttributeName.StudentID, qq));
                    if (signed.Rows.Count > 0)
                    {
                        count = count + signed.Rows.Count;
                    }
                    count = Math.Min(4, count);

                    int courseId = courses[course];
                    int assistantId = assistants[assistant];

                    DateTime end = signDate.AddYears(count);
                    long expire = Common.GetTimeStamp(end);
                    long signDateTimestamp = Common.GetTimeStamp(signDate);
                    string signDateString = signDate.ToString(Constants.SHORT_DATE_FORMAT);
                    Args[] args = new Args[] {
                                            new Args(AttributeName.CourseID, courseId),
                                            new Args(AttributeName.StudentID, qq),
                                            new Args(AttributeName.AssistantID, assistantId),
                                            new Args(AttributeName.PlatformID, 1),
                                            new Args(AttributeName.StatusID, 1),
                                            new Args(AttributeName.PayType, payType),
                                            new Args(AttributeName.SignDate, signDateString),
                                            new Args(AttributeName.SignTimestamp, signDateTimestamp),
                                            new Args(AttributeName.ExpireDate, end.ToString(Constants.SHORT_DATE_FORMAT)),
                                            new Args(AttributeName.Expire, expire)
                    };
                    int signId = signService.Add(conn, args);
                    signUp.Add(sign, signId);
                }

                if (signUp.ContainsKey(sign))
                {
                    int signId = signUp[sign];
                    if (string.IsNullOrEmpty(reader[1]))
                    {
                        Args[] args = new Args[]{
                                          new Args(AttributeName.CourseID,  courses[course]),
                                          new Args(AttributeName.StudentID, qq ),
                                          new Args(AttributeName.PayType,Constants.FULL ),
                                          new Args(AttributeName.Status, Constants.PAID ),
                                          new Args(AttributeName.Values, price),
                                          new Args(AttributeName.PayDate,signDate.ToString(Constants.SHORT_DATE_FORMAT)),
                                          new Args(AttributeName.Expire,Common.GetTimeStamp(signDate))};
                        paymentService.Add(conn, args);
                    }
                    else
                    {
                        Args[] args = new Args[]{
                                          new Args(AttributeName.CourseID,  courses[course]),
                                          new Args(AttributeName.StudentID, qq ),
                                          new Args(AttributeName.PayType,"分期" ),
                                          new Args(AttributeName.Status, Constants.UNPAID ),
                                          new Args(AttributeName.Values, price),
                                          new Args(AttributeName.PayDate,signDate.ToString(Constants.SHORT_DATE_FORMAT)),
                                          new Args(AttributeName.Expire,Common.GetTimeStamp(signDate))};
                        paymentService.Add(conn, args);
                    }
                }




            }
        }


        private void ImportBasicData()
        {
        }


        public void ImportFullPaymentStudents(IService service, SQLiteConnection conn, string path)
        {
            List<string> list = new List<string>();

            TextReader textReader = File.OpenText(path);
            Dictionary<string, object> paras = new Dictionary<string, object>();
            CsvReader reader = new CsvReader(textReader);
            reader.Read();

            while (reader.Read())
            {
                string name = reader[4];
                string qq = reader[3];
                if (list.Contains(qq))
                {
                    continue;
                }
                list.Add(qq);
                paras.Add(AttributeName.NAME, name);
                paras.Add(AttributeName.QQ, qq);
                paras.Add(AttributeName.Phone, 100000);
                paras.Add(AttributeName.Wechat, "");
                paras.Add(AttributeName.Email, "");
                //service.Add(conn, paras);
                paras.Clear();
            }
        }
    }
}
