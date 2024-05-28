USE [SEDC_ACADEMY_HOMEWORK]
GO

-- Find all Students with FirstName = Antonio
SELECT *
FROM [dbo].[Student]
WHERE FirstName = 'Antonio'
GO

-- Find all Students with DateOfBirth greater than ‘01.01.1999'
SELECT *
FROM [dbo].[Student]
WHERE [DateOfBirth] > '1999.01.01'
GO

-- Find all Students with LastName starting With ‘J’ enrolled in January/1998
SELECT *
FROM [dbo].[Student]
WHERE LastName LIKE 'J%' AND [EnrolledDate] >= '1998.01.01' AND [EnrolledDate] <= '1998.01.31'
GO
-- mislev samo da stavam [EnrolledDate] < '1998.01.01' ama ne bev siguren da li kje bide tochno


-- List all Students ordered by FirstName
SELECT *
FROM [dbo].[Student]
ORDER BY FirstName ASC
GO

-- List all Teacher Last Names and Student Last Names in single result set. Remove duplicates
SELECT [LastName]
FROM [dbo].[Teacher]
UNION
SELECT [LastName]
FROM [dbo].[Student]
GO

-- Create Foreign key constraints from diagram or with script
--///////////////////////////////////////////////////////////////

--List all possible combinations of Courses names and AchievementType names that can be passed by student

--SELECT *
--FROM [dbo].[Course]
--CROSS JOIN 
--[dbo].[AchievementType]

SELECT c.[Name], aType.[Name]
FROM [dbo].[Course] AS c
CROSS JOIN 
[dbo].[AchievementType] AS aType
-- ne go reshiv sam


-- List all Teachers without exam Grade
SELECT t.*
FROM [dbo].[Teacher] AS t
LEFT JOIN 
[dbo].[Grade] AS g
ON
g.TeacherID = t.ID AND g.ID IS NULL
-- ne go reshiv sam

--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


-- 23.05.2024 Homework

--Calculate the count of all grades per Teacher in the system
SELECT COUNT(*) AS Grades
FROM [dbo].[Teacher] t
INNER JOIN [dbo].[Grade] g ON t.ID = g.TeacherID
GROUP BY t.ID

--Calculate the count of all grades per Teacher in the system for first 100
--Students (ID < 100)
SELECT COUNT(*) AS GradesPerTeacher
FROM [dbo].[Teacher] t
INNER JOIN [dbo].[Student] s ON t.ID = s.ID
WHERE s.ID < 100

--Find the Maximal Grade, and the Average Grade per Student on all grades in
--the system
SELECT MAX(g.Grade) AS MaximalGrade , AVG(g.Grade) AS AverageGrade
FROM [dbo].[Student] s
INNER JOIN [dbo].[Grade] g ON s.ID = g.StudentID
GROUP BY s.ID

--Calculate the count of all grades per Teacher in the system and filter only
--grade count greater then 200
SELECT COUNT(*)
FROM [dbo].[Teacher] t
INNER JOIN [dbo].[Grade] g ON t.ID = g.TeacherID

--Find the Grade Count, Maximal Grade, and the Average Grade per Student on
--all grades in the system. Filter only records where Maximal Grade is equal to
--Average Grade
SELECT s.id AS studentId, COUNT(g.Grade) AS Grade, MAX(g.Grade) AS MaxGrade, AVG(g.Grade) AS AvgGrade 
FROM [dbo].[Student] s
INNER JOIN [dbo].[Grade] g ON s.ID = g.StudentID
GROUP BY
s.ID

--List Student First Name and Last Name next to the other details from previous
--query
SELECT s.id AS studentId, COUNT(g.Grade) AS Grade, MAX(g.Grade) AS MaxGrade, AVG(g.Grade) AS AvgGrade, s.FirstName, s.LastName 
FROM [dbo].[Student] s
INNER JOIN [dbo].[Grade] g ON s.ID = g.StudentID
GROUP BY
s.ID, s.FirstName, s.LastName

--Create new view (vv_StudentGrades) that will List all StudentIds and count of
--Grades per student
CREATE VIEW VW_StudentGrades AS 
SELECT 
	s.ID AS StudentId,
	COUNT (g.Grade) AS GradeCount
FROM [dbo].[Student] s
JOIN [dbo].[Grade] g ON s.ID = g.StudentID
GROUP BY
	s.ID
GO

--DROP VIEW VW_StudentGrades

SELECT VW_StudentGrades.GradeCount AS GradeCount, VW_StudentGrades.StudentId AS StudentID FROM VW_StudentGrades

--Change the view to show Student First and Last Names instead of StudentID

SELECT * FROM VW_StudentGrades
-- Smeniv vo design na samiot view

ALTER VIEW VW_StudentGrades AS 
SELECT 
	s.FirstName,
	s.LastName,
	COUNT (g.Grade) AS GradeCount
FROM [dbo].[Student] s
JOIN [dbo].[Grade] g ON s.ID = g.StudentID
GROUP BY
	s.FirstName, s.LastName
GO

--List all rows from view ordered by biggest Grade Count
SELECT *
FROM VW_StudentGrades
ORDER BY GradeCount DESC

--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

-- Homework 28.05.2024

--Declare scalar variable for storing FirstName values
DECLARE @FirstName NVARCHAR(50)

--• Assign value ‘Antonio’ to the FirstName variable
SET @FirstName = 'Antonio'
SELECT @FirstName

--• Find all Students having FirstName same as the variable
SELECT *
FROM [dbo].[Student]
WHERE FirstName = @FirstName

--• Declare table variable that will contain StudentId, StudentName and DateOfBirth
DECLARE @StudentList TABLE (StudentId INT, StudentName NVARCHAR(100), DateOfBirth DATE)

--• Fill the table variable with all Female students
INSERT INTO @StudentList (StudentId, StudentName, DateOfBirth)
SELECT Id, FirstName, DateOfBirth
FROM [dbo].[Student]
WHERE Gender = 'F'

SELECT *
FROM @StudentList


--• Declare temp table that will contain LastName and EnrolledDate columns
CREATE TABLE #LastNameAndEnrolledDate (LastName NVARCHAR(100), EnrolledDate DATE)

--• Fill the temp table with all Male students having First Name starting with ‘A’
INSERT INTO #LastNameAndEnrolledDate (LastName, EnrolledDate)
SELECT LastName, EnrolledDate
FROM [dbo].[Student]
WHERE Gender = 'M' AND FirstName LIKE 'A%'

SELECT *
FROM #LastNameAndEnrolledDate

--• Retrieve the students from the table which last name is with 7 characters
SELECT *
FROM [dbo].[Student]
WHERE LEN(LastName) = 7

--• Find all teachers whose FirstName length is less than 5 and the first 3 characters of their FirstName and LastName are the same.
SELECT *
FROM [dbo].[Teacher]
WHERE LEN(FirstName) < 5 AND LEFT(FirstName, 3) = LEFT(LastName, 3)

