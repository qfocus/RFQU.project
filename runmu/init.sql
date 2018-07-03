BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS `teacher` (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`name`	TEXT NOT NULL,
	`alias`	TEXT,
	`qq`	INTEGER NOT NULL,
	`email`	TEXT NOT NULL,
	`createdTime`	TEXT NOT NULL,
	`updateTime`	TEXT NOT NULL
);
INSERT INTO `teacher` (ID,name,alias,qq,email,createdTime,updateTime) VALUES (1,'东方','',0,'0','2018-05-27','2018-05-27'),
 (2,'帅飞','小手飞影',0,'0','',''),
 (3,'小凉',NULL,0,'0','',''),
 (4,'小瑞',NULL,0,'0','',''),
 (5,'暮木',NULL,0,'0','',''),
 (6,'寒柏',NULL,0,'0','',''),
 (7,'卓威',NULL,0,'0','',''),
 (8,'万里',NULL,0,'0','','');
CREATE TABLE IF NOT EXISTS `students` (
	`ID`	INTEGER NOT NULL UNIQUE,
	`name`	TEXT NOT NULL,
	`email`	TEXT,
	`phone`	TEXT,
	`weChat`	TEXT,
	`createdTime`	TEXT NOT NULL,
	`updateTime`	TEXT NOT NULL,
	PRIMARY KEY(`ID`)
);
INSERT INTO `students` (ID,name,email,phone,weChat,createdTime,updateTime) VALUES (289198777,'噢不','289198777','1234567890',NULL,'','');
CREATE TABLE IF NOT EXISTS `signup` (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`courseID`	INTEGER NOT NULL,
	`studentID`	INTEGER NOT NULL,
	`assistantID`	INTEGER NOT NULL,
	`platformID`	INTEGER NOT NULL,
	`statusID`	INTEGER NOT NULL,
	`payType`	TEXT NOT NULL,
	`signDate`	TEXT NOT NULL,
	`endDate`	INTEGER NOT NULL,
	`createdTime`	TEXT NOT NULL,
	`updateTime`	TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS `platform` (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`name`	TEXT NOT NULL,
	`createdTime`	TEXT,
	`updateTime`	TEXT
);
INSERT INTO `platform` (ID,name,createdTime,updateTime) VALUES (1,'腾讯课堂','2018-06-15','2018-06-15');
CREATE TABLE IF NOT EXISTS `payment` (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`courseID`	INTEGER NOT NULL,
	`studentID`	INTEGER NOT NULL,
	`payType`	TEXT NOT NULL,
	`values`	INTEGER NOT NULL,
	`status`	TEXT NOT NULL,
	`payDate`	TEXT NOT NULL,
	`endDate`   INTEGER NOT NULL,
	`createdTime`	TEXT NOT NULL,
	`updateTime`	TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS `learnStatus` (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`alias`	TEXT NOT NULL,
	`name`	TEXT,
	`updateTime`	TEXT NOT NULL,
	`createdTime`	TEXT NOT NULL
);
INSERT INTO `learnStatus` (ID,alias,name,updateTime,createdTime) VALUES (1,'in-progress','学习中','',''),
 (2,'suspend','休学','',''),
 (3,'completed','结课','',''),
 (4,'terminated','中止','','');
CREATE TABLE IF NOT EXISTS `hibernate` (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`courseID`	INTEGER NOT NULL,
	`studentID`	INTEGER NOT NULL,
	`start`	TEXT NOT NULL,
	`end`	TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS `course` (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`teacherID`	INTEGER NOT NULL,
	`name`	TEXT NOT NULL,
	`price`	INTEGER NOT NULL,
	`createdTime`	TEXT NOT NULL,
	`updateTime`	TEXT NOT NULL
);
INSERT INTO `course` (ID,teacherID,name,price,createdTime,updateTime) VALUES (1,1,'素描普及',1000,'',''),
 (2,1,'素描强化',1000,'',''),
 (3,1,'素描静物',1000,'',''),
 (4,1,'小钢笔',1000,'',''),
 (5,1,'大钢笔',1000,'',''),
 (6,1,'小油画',1000,'',''),
 (7,1,'大油画',1000,'',''),
 (8,1,'色彩原理',1000,'',''),
 (9,2,'素描肖像',1000,'',''),
 (10,2,'彩铅肖像',1000,'',''),
 (11,2,'彩铅基础',1000,'',''),
 (12,2,'人物速写',1000,'',''),
 (13,3,'板绘基础',1000,'',''),
 (14,4,'水彩基础
',1000,'',''),
 (15,4,'水粉基础',1000,'',''),
 (16,5,'艺用人体',1000,'',''),
 (17,6,'写意花鸟',1000,'',''),
 (18,7,'室内手绘',1000,'',''),
 (19,7,'钢笔建筑',1000,'','');
CREATE TABLE IF NOT EXISTS `assistant` (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`name`	TEXT NOT NULL,
	`updateTime`	TEXT,
	`createdTime`	TEXT
);
INSERT INTO `assistant` (ID,name,updateTime,createdTime) VALUES (1,'小屿',NULL,NULL),
 (2,'小喵',NULL,NULL),
 (3,'小班
',NULL,NULL),
 (4,'小执',NULL,NULL),
 (5,'阳光',NULL,NULL),
 (6,'其他',NULL,NULL);
COMMIT;
