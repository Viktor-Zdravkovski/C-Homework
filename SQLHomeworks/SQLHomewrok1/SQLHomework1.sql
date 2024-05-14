USE [master]
GO

CREATE DATABASE [SEDCACADEMYDB]
GO

USE [SEDCACADEMYDB]
GO

CREATE TABLE [Student](
	Id INT IDENTITY(1,1),
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	DateOfBirth DATE NOT NULL,
	EnroledDate DATE NOT NULL,
	Gender VARCHAR(7) NOT NULL,
	NationalIDNumber INT NOT NULL,
	StudentCardNumber INT NOT NULL
)

CREATE TABLE [Teacher](
	Id INT IDENTITY(1,1),
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	DateOfBirth DATE NOT NULL,
	AcademicRank INT NOT NULL,
	HireDate DATE NOT NULL
)

CREATE TABLE [Grade](
	Id INT IDENTITY(1,1),
	StudentID INT NOT NULL,
	CourseID INT NOT NULL,
	TeacherID INT NOT NULL,
	Grade INT NOT NULL,
	Comment NVARCHAR(400) NOT NULL,
	CreateDate DATE NOT NULL
)

CREATE TABLE [Course](
	Id INT IDENTITY(1,1),
	[Name] NVARCHAR(20) NOT NULL,
	Credit INT NOT NULL,
	AcademicYear DATETIME NOT NULL,
	Semester INT NOT NULL
)

CREATE TABLE [GradeDetails](
	Id INT IDENTITY(1,1),
	GradeID INT NOT NULL,
	AchievementTypeID INT NOT NULL,
	AchievementPoints INT NOT NULL,
	AchievementMaxPoints INT NOT NULL,
	AchievementDate DATE NOT NULL
)

CREATE TABLE [AchievementType](
	Id INT IDENTITY(1,1),
	[Name] NVARCHAR(20) NOT NULL,
	[Description] NVARCHAR(30) NOT NULL,
	ParticipationRate DECIMAL(18,2) NOT NULL
)

SELECT * FROM dbo.Student
SELECT * FROM dbo.Teacher
SELECT * FROM dbo.Grade
SELECT * FROM dbo.Course
SELECT * FROM dbo.AchievementType
SELECT * FROM dbo.GradeDetails