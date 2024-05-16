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