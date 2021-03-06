USE [master]
GO
/****** Object:  Database [Universities]    Script Date: 21.8.2014 г. 15:59:59 ч. ******/
CREATE DATABASE [Universities]
 CONTAINMENT = NONE

ALTER DATABASE [Universities] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Universities].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Universities] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Universities] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Universities] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Universities] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Universities] SET ARITHABORT OFF 
GO
ALTER DATABASE [Universities] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Universities] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Universities] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Universities] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Universities] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Universities] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Universities] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Universities] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Universities] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Universities] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Universities] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Universities] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Universities] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Universities] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Universities] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Universities] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Universities] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Universities] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Universities] SET RECOVERY FULL 
GO
ALTER DATABASE [Universities] SET  MULTI_USER 
GO
ALTER DATABASE [Universities] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Universities] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Universities] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Universities] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Universities', N'ON'
GO
USE [Universities]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 21.8.2014 г. 16:00:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](100) NOT NULL,
	[ProfessorId] [int] NOT NULL,
	[DepartmentId] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 21.8.2014 г. 16:00:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](200) NOT NULL,
	[FacultyId] [int] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 21.8.2014 г. 16:00:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[FacultyId] [int] IDENTITY(1,1) NOT NULL,
	[FacultyName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[FacultyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professor]    Script Date: 21.8.2014 г. 16:00:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor](
	[ProfessorId] [int] IDENTITY(1,1) NOT NULL,
	[ProfessorName] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Professor] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professor_Title]    Script Date: 21.8.2014 г. 16:00:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor_Title](
	[ProfessorId] [int] NOT NULL,
	[TitleId] [int] NOT NULL,
 CONSTRAINT [PK_Professor_Title] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[TitleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 21.8.2014 г. 16:00:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[FacultyId] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student_Course]    Script Date: 21.8.2014 г. 16:00:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Course](
	[CourseId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_Student_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Title]    Script Date: 21.8.2014 г. 16:00:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Title](
	[TitleId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Title] PRIMARY KEY CLUSTERED 
(
	[TitleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Professor]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Faculty] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculty] ([FacultyId])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Faculty]
GO
ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_Department]
GO
ALTER TABLE [dbo].[Professor_Title]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Title_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO
ALTER TABLE [dbo].[Professor_Title] CHECK CONSTRAINT [FK_Professor_Title_Professor]
GO
ALTER TABLE [dbo].[Professor_Title]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Title_Title] FOREIGN KEY([TitleId])
REFERENCES [dbo].[Title] ([TitleId])
GO
ALTER TABLE [dbo].[Professor_Title] CHECK CONSTRAINT [FK_Professor_Title_Title]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Faculty] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculty] ([FacultyId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Faculty]
GO
ALTER TABLE [dbo].[Student_Course]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Student_Course] CHECK CONSTRAINT [FK_Student_Course_Course]
GO
ALTER TABLE [dbo].[Student_Course]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Student_Course] CHECK CONSTRAINT [FK_Student_Course_Student]
GO
USE [master]
GO
ALTER DATABASE [Universities] SET  READ_WRITE 
GO
