using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace runmu.Business
{
    public class SignUpService : Service
    {
        private static string tableName = "`signup`";
        private static string selectAllSql =
            @"select s.ID, c.name as '课程', st.name as '学员',st.ID as 'QQ', s.signDate as '报名日期',s.expireDate as '指导期', s.payType as '付款方式', a.name as '销售',ls.name as '状态',p.name as '平台' from signup as s
            join course as c on s.courseID = c.ID
            join students as st on s.studentID = st.ID
            join assistant as a on s.assistantID = a.ID
            join learnStatus as ls on s.statusID = ls.ID
			join platform as p on s.platformID = p.ID";

        private static string insertSql =
            @"INSERT INTO `signup`
            (`courseID`,`studentID`,`assistantID`,`signDate`,`expireDate`, `expire`, `payType`,`platformID`,`statusID`,`signTimestamp`,`createdTime`,`updateTime`) VALUES 
            (@courseID, @studentID, @assistantID, @signDate, @expireDate, @expire, @payType, @platformID, @statusID, @signTimestamp, @date, @date);";
        private static readonly Dictionary<string, string> mapping = new Dictionary<string, string>() {
            { AttributeName.StudentID,"st.ID" },
            { AttributeName.CourseID, "c.ID"},
            { AttributeName.AssistantID,"a.ID"},
            { AttributeName.StatusID,"ls.ID"},
            { AttributeName.SignTimestamp,"s.signTimestamp"},
            { AttributeName.Expire,"s.expire"}
        };

        public override bool Update(SQLiteConnection conn, DataTable table)
        {
            throw new NotImplementedException();
        }

        protected override SQLiteParameter[] BuildInsertParameters(params Args[] values)
        {
            return BuildParamsWithDate(values);
        }

        protected override SQLiteParameter[] BuildQueryParameters(params Args[] values)
        {
            return BuildDefaultParams(values).ToArray();
        }

        protected override string GetInsertSql()
        {
            return insertSql;
        }


        protected override string GetQuerySql()
        {
            return selectAllSql;
        }

        protected override string GetSelectAllSql()
        {
            return selectAllSql;
        }

        protected override string TableName()
        {
            return tableName;
        }

        public override DataTable MutiplyQuery(SQLiteConnection conn, params Args[] values)
        {
            string sql = BuildSql(values);

            SQLiteParameter[] parameters = BuildParams(values);

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);

            SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd);

            DataTable result = new DataTable();
            adp.Fill(result);

            return result;

        }

        private SQLiteParameter[] BuildParams(params Args[] conditions)
        {

            if (conditions == null || conditions.Length == 0 || conditions[0] == null)
            {
                return new SQLiteParameter[] { };
            }
            List<SQLiteParameter> list = new List<SQLiteParameter>();

            foreach (var item in conditions)
            {
                if (item.Condition == "IN")
                {
                    IList values = (IList)item.Value;
                    for (int i = 0; i < values.Count; i++)
                    {
                        list.Add(new SQLiteParameter()
                        {
                            ParameterName = "@" + item.Name + i.ToString(),
                            Value = values[i],
                        });
                    }
                    continue;
                }

                list.Add(new SQLiteParameter()
                {
                    ParameterName = "@" + item.Name,
                    Value = item.Value,
                });
            }
            return list.ToArray();
        }

        private string BuildSql(params Args[] conditions)
        {
            if (conditions == null || conditions.Length == 0 || conditions[0] == null)
            {
                return selectAllSql;
            }


            StringBuilder builder = new StringBuilder(selectAllSql);
            builder.Append(" WHERE ");

            foreach (var item in conditions)
            {
                string name = item.Name;
                if (mapping.ContainsKey(name))
                {
                    name = mapping[name];
                }

                builder.Append(name);
                builder.Append(" ");
                if (item.Condition == "IN")
                {
                    builder.Append(item.Condition);
                    builder.Append("( ");
                    IList values = (IList)item.Value;
                    for (int i = 0; i < values.Count; i++)
                    {
                        builder.Append(" @");
                        builder.Append(item.Name);
                        builder.Append(i);
                        if (i != values.Count - 1)
                        {
                            builder.Append(", ");
                        }
                    }
                    builder.Append(" ) and ");
                }
                else
                {
                    builder.Append(item.Condition);
                    builder.Append(" @");
                    builder.Append(item.Name);
                    builder.Append(" and ");
                }
            }

            if (conditions != null && conditions.Length > 0)
            {
                builder.Remove(builder.Length - 5, 5);
            }

            return builder.ToString();
        }
    }
}
