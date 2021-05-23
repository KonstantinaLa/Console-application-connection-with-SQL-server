--All Students		
SELECT	*
FROM	Student	
GO
--All Courses		
SELECT	*
FROM	Course
GO
--All Trainers
SELECT	*
FROM	Trainer
GO
--All Assignment
SELECT	*
FROM	Assignment
GO

--All the Student Per Course (call the Stored procedure for each course)
EXECUTE Attendees'Database'
GO

EXECUTE Attendees'C#'
GO

EXECUTE Attendees'Python'
GO

EXECUTE Attendees'Java'
GO

EXECUTE Attendees'JavaScript'
GO

--Trainers Per Course (call the Stored procedure for each course)

EXECUTE TrainersPerCourse 'C#'
GO

EXECUTE TrainersPerCourse 'Python'
GO

EXECUTE TrainersPerCourse 'Java'
GO

EXECUTE TrainersPerCourse 'JavaScript'
GO

EXECUTE TrainersPerCourse 'Database'
GO

--Assignments Per Course (call the Stored procedure for each course)

EXECUTE AssignmentPerCourse 'C#'
GO

EXECUTE AssignmentPerCourse 'Python'
GO

EXECUTE AssignmentPerCourse 'Java'
GO

EXECUTE AssignmentPerCourse 'JavaScript'
GO

Execute AssignmentPerCourse 'Database'
GO

-- All the assignments per course per student 
SELECT DISTINCT Student.StudentID, 	Student.FirstName ,Student.LastName , Course.Title AS CourseTitle,  Assignment.Title AS AssignmentTitle 
FROM StudentCourse , AssignmentCourse , Assignment , Student, Course
WHERE StudentCourse.CourseId = AssignmentCourse.CourseId 
AND AssignmentCourse.AssignmentId = Assignment.AssignmentId 
AND Student.StudentID = StudentCourse.StudentId 
AND	Course.CourseId = StudentCourse.CourseId
ORDER BY StudentID
GO


--A list of students that belong to more than one courses
SELECT Student.StudentId , Student.FirstName , Student.LastName
FROM Student
WHERE EXISTS (SELECT StudentID
				FROM StudentCourse
				WHERE StudentCourse.StudentId = Student.StudentID 
				GROUP BY StudentId
				HAVING COUNT(StudentCourse.StudentId)>=2)
 GO



