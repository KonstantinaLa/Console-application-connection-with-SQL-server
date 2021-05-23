USE [master]
GO
/****** Object:  Database [Private School]    Script Date: 30/4/2021 4:46:12 μμ ******/
CREATE DATABASE [Private School]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Private School', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Private School.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Private School_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Private School_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Private School] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Private School].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Private School] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Private School] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Private School] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Private School] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Private School] SET ARITHABORT OFF 
GO
ALTER DATABASE [Private School] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Private School] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Private School] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Private School] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Private School] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Private School] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Private School] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Private School] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Private School] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Private School] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Private School] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Private School] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Private School] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Private School] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Private School] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Private School] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Private School] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Private School] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Private School] SET  MULTI_USER 
GO
ALTER DATABASE [Private School] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Private School] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Private School] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Private School] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Private School] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Private School] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Private School] SET QUERY_STORE = OFF
GO
USE [Private School]
GO
/****** Object:  Table [dbo].[Assignment]    Script Date: 30/4/2021 4:46:12 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignment](
	[AssignmentId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[subDateTime] [datetime] NULL,
	[oralMark] [int] NULL,
	[totalMark] [int] NULL,
 CONSTRAINT [PK_Assignment] PRIMARY KEY CLUSTERED 
(
	[AssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignmentCourse]    Script Date: 30/4/2021 4:46:12 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignmentCourse](
	[AssignmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_AssignmentCourse] PRIMARY KEY CLUSTERED 
(
	[AssignmentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 30/4/2021 4:46:12 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Stream] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Start_date] [date] NULL,
	[End_date] [date] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 30/4/2021 4:46:12 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[TuitionFees] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 30/4/2021 4:46:12 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_StudentCourse] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainer]    Script Date: 30/4/2021 4:46:12 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainer](
	[TrainerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Subject] [nvarchar](50) NULL,
 CONSTRAINT [PK_Trainer] PRIMARY KEY CLUSTERED 
(
	[TrainerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainerCourse]    Script Date: 30/4/2021 4:46:12 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainerCourse](
	[TrainerId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_TrainerCourse] PRIMARY KEY CLUSTERED 
(
	[TrainerId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Assignment] ON 
GO
INSERT [dbo].[Assignment] ([AssignmentId], [Title], [Description], [subDateTime], [oralMark], [totalMark]) VALUES (1, N'Projectc#', N'Individual', CAST(N'2021-03-15T00:00:00.000' AS DateTime), 50, 100)
GO
INSERT [dbo].[Assignment] ([AssignmentId], [Title], [Description], [subDateTime], [oralMark], [totalMark]) VALUES (2, N'ProjectPython', N'Individual', CAST(N'2021-05-12T00:00:00.000' AS DateTime), 30, 100)
GO
INSERT [dbo].[Assignment] ([AssignmentId], [Title], [Description], [subDateTime], [oralMark], [totalMark]) VALUES (3, N'ProjectJava', N'Individual', CAST(N'2021-07-04T00:00:00.000' AS DateTime), 50, 100)
GO
INSERT [dbo].[Assignment] ([AssignmentId], [Title], [Description], [subDateTime], [oralMark], [totalMark]) VALUES (4, N'ProjectJavaScript', N'Individual', CAST(N'2021-07-04T00:00:00.000' AS DateTime), 60, 100)
GO
INSERT [dbo].[Assignment] ([AssignmentId], [Title], [Description], [subDateTime], [oralMark], [totalMark]) VALUES (5, N'ProjectDatabase', N'Group', CAST(N'2021-09-05T00:00:00.000' AS DateTime), 40, 100)
GO
SET IDENTITY_INSERT [dbo].[Assignment] OFF
GO
INSERT [dbo].[AssignmentCourse] ([AssignmentId], [CourseId]) VALUES (1, 1)
GO
INSERT [dbo].[AssignmentCourse] ([AssignmentId], [CourseId]) VALUES (2, 2)
GO
INSERT [dbo].[AssignmentCourse] ([AssignmentId], [CourseId]) VALUES (3, 3)
GO
INSERT [dbo].[AssignmentCourse] ([AssignmentId], [CourseId]) VALUES (4, 4)
GO
INSERT [dbo].[AssignmentCourse] ([AssignmentId], [CourseId]) VALUES (5, 1)
GO
INSERT [dbo].[AssignmentCourse] ([AssignmentId], [CourseId]) VALUES (5, 2)
GO
INSERT [dbo].[AssignmentCourse] ([AssignmentId], [CourseId]) VALUES (5, 3)
GO
INSERT [dbo].[AssignmentCourse] ([AssignmentId], [CourseId]) VALUES (5, 4)
GO
INSERT [dbo].[AssignmentCourse] ([AssignmentId], [CourseId]) VALUES (5, 5)
GO
SET IDENTITY_INSERT [dbo].[Course] ON 
GO
INSERT [dbo].[Course] ([CourseId], [Title], [Stream], [Type], [Start_date], [End_date]) VALUES (1, N'C#', N'FullTime', N'Online', CAST(N'2021-11-03' AS Date), CAST(N'2022-03-06' AS Date))
GO
INSERT [dbo].[Course] ([CourseId], [Title], [Stream], [Type], [Start_date], [End_date]) VALUES (2, N'Python', N'PartTime', N'Online', CAST(N'2021-03-15' AS Date), CAST(N'2021-09-15' AS Date))
GO
INSERT [dbo].[Course] ([CourseId], [Title], [Stream], [Type], [Start_date], [End_date]) VALUES (3, N'Java', N'PartTime', N'Online', CAST(N'2021-04-15' AS Date), CAST(N'2021-10-15' AS Date))
GO
INSERT [dbo].[Course] ([CourseId], [Title], [Stream], [Type], [Start_date], [End_date]) VALUES (4, N'JavaScript', N'FullTime', N'Online', CAST(N'2021-05-15' AS Date), CAST(N'2021-08-15' AS Date))
GO
INSERT [dbo].[Course] ([CourseId], [Title], [Stream], [Type], [Start_date], [End_date]) VALUES (5, N'Database', N'PartTime', N'Online', CAST(N'2021-04-01' AS Date), CAST(N'2021-10-01' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (1, N'Konstantina', N'Georgiou', CAST(N'1998-09-08' AS Date), CAST(250 AS Decimal(18, 0)))
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (2, N'Maria', N'Kanistra', CAST(N'1998-02-04' AS Date), CAST(400 AS Decimal(18, 0)))
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (3, N'George', N'Papadatos', CAST(N'1999-03-04' AS Date), CAST(350 AS Decimal(18, 0)))
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (4, N'Katerina', N'Antoniou', CAST(N'1992-03-08' AS Date), CAST(400 AS Decimal(18, 0)))
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (5, N'Antonis', N'Alexiou', CAST(N'1995-04-05' AS Date), CAST(220 AS Decimal(18, 0)))
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (6, N'Michalis', N'Tsakiris', CAST(N'2000-07-09' AS Date), CAST(300 AS Decimal(18, 0)))
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (7, N'Fotini', N'Kokkinou', CAST(N'1989-05-06' AS Date), CAST(500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (8, N'Kostas', N'Papadopoulos', CAST(N'1997-04-14' AS Date), CAST(450 AS Decimal(18, 0)))
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (9, N'Panagiotis', N'Fournaros', CAST(N'1997-05-06' AS Date), CAST(450 AS Decimal(18, 0)))
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (10, N'Olga', N'Bakou', CAST(N'1990-05-04' AS Date), CAST(560 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (1, 1)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (1, 2)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (2, 2)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (2, 4)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (3, 1)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (3, 5)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (4, 3)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (5, 3)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (5, 5)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (6, 1)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (7, 4)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (7, 5)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (8, 1)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (8, 5)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (9, 2)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (9, 4)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (10, 5)
GO
SET IDENTITY_INSERT [dbo].[Trainer] ON 
GO
INSERT [dbo].[Trainer] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (1, N'Aretousa', N'Anagnostopoulou', N'Programmig')
GO
INSERT [dbo].[Trainer] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (2, N'Dimitra', N'Apsomotou', N'Programming')
GO
INSERT [dbo].[Trainer] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (3, N'Aggelos', N'Alexopoulos', N'Database')
GO
INSERT [dbo].[Trainer] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (4, N'Pantelis', N'Antonoglou', N'Database')
GO
INSERT [dbo].[Trainer] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (5, N'Dimitris', N'Karagiorgou', N'Programmig')
GO
SET IDENTITY_INSERT [dbo].[Trainer] OFF
GO
INSERT [dbo].[TrainerCourse] ([TrainerId], [CourseId]) VALUES (1, 1)
GO
INSERT [dbo].[TrainerCourse] ([TrainerId], [CourseId]) VALUES (1, 2)
GO
INSERT [dbo].[TrainerCourse] ([TrainerId], [CourseId]) VALUES (2, 3)
GO
INSERT [dbo].[TrainerCourse] ([TrainerId], [CourseId]) VALUES (2, 4)
GO
INSERT [dbo].[TrainerCourse] ([TrainerId], [CourseId]) VALUES (3, 1)
GO
INSERT [dbo].[TrainerCourse] ([TrainerId], [CourseId]) VALUES (3, 2)
GO
INSERT [dbo].[TrainerCourse] ([TrainerId], [CourseId]) VALUES (3, 5)
GO
INSERT [dbo].[TrainerCourse] ([TrainerId], [CourseId]) VALUES (4, 3)
GO
INSERT [dbo].[TrainerCourse] ([TrainerId], [CourseId]) VALUES (4, 4)
GO
INSERT [dbo].[TrainerCourse] ([TrainerId], [CourseId]) VALUES (4, 5)
GO
INSERT [dbo].[TrainerCourse] ([TrainerId], [CourseId]) VALUES (5, 1)
GO
INSERT [dbo].[TrainerCourse] ([TrainerId], [CourseId]) VALUES (5, 2)
GO
INSERT [dbo].[TrainerCourse] ([TrainerId], [CourseId]) VALUES (5, 4)
GO
ALTER TABLE [dbo].[AssignmentCourse]  WITH CHECK ADD  CONSTRAINT [FK_AssignmentCourse_Assignment] FOREIGN KEY([AssignmentId])
REFERENCES [dbo].[Assignment] ([AssignmentId])
GO
ALTER TABLE [dbo].[AssignmentCourse] CHECK CONSTRAINT [FK_AssignmentCourse_Assignment]
GO
ALTER TABLE [dbo].[AssignmentCourse]  WITH CHECK ADD  CONSTRAINT [FK_AssignmentCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[AssignmentCourse] CHECK CONSTRAINT [FK_AssignmentCourse_Course]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Course]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Student]
GO
ALTER TABLE [dbo].[TrainerCourse]  WITH CHECK ADD  CONSTRAINT [FK_TrainerCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[TrainerCourse] CHECK CONSTRAINT [FK_TrainerCourse_Course]
GO
ALTER TABLE [dbo].[TrainerCourse]  WITH CHECK ADD  CONSTRAINT [FK_TrainerCourse_Trainer] FOREIGN KEY([TrainerId])
REFERENCES [dbo].[Trainer] ([TrainerId])
GO
ALTER TABLE [dbo].[TrainerCourse] CHECK CONSTRAINT [FK_TrainerCourse_Trainer]
GO
/****** Object:  StoredProcedure [dbo].[AssignmentPerCourse]    Script Date: 30/4/2021 4:46:12 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AssignmentPerCourse]
@course nvarchar(50)
AS
BEGIN
DECLARE @courseId int
SET @courseId = (
				SELECT CourseId 
				FROM Course
				WHERE Course.Title = @course)
SELECT DISTINCT Assignment.Title
		FROM Assignment
		INNER JOIN AssignmentCourse ON AssignmentCourse.AssignmentId = Assignment.AssignmentId 
		INNER JOIN Course ON  AssignmentCourse.CourseId = @courseId
END;
GO
/****** Object:  StoredProcedure [dbo].[Attendees]    Script Date: 30/4/2021 4:46:12 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Attendees]
@course nvarchar(50)
AS
BEGIN
DECLARE @courseId int
SET @courseId = (
				SELECT CourseId 
				FROM Course
				WHERE Course.Title = @course)
SELECT DISTINCT Student.FirstName , Student.LastName
		FROM Student
		INNER JOIN StudentCourse ON StudentCourse.StudentId= Student.StudentID
		INNER JOIN Course ON  StudentCourse.CourseId = @courseId
END;
GO
/****** Object:  StoredProcedure [dbo].[TrainersPerCourse]    Script Date: 30/4/2021 4:46:12 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TrainersPerCourse]
@course nvarchar(50)
AS
BEGIN
DECLARE @courseId int
SET @courseId = (
				SELECT CourseId 
				FROM Course
				WHERE Course.Title = @course)
SELECT DISTINCT Trainer.FirstName , Trainer.LastName
		FROM Trainer
		INNER JOIN TrainerCourse ON TrainerCourse.TrainerId= Trainer.TrainerId
		INNER JOIN Course ON  TrainerCourse.CourseId = @courseId
END;
GO
USE [master]
GO
ALTER DATABASE [Private School] SET  READ_WRITE 
GO
