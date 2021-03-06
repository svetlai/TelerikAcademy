USE [master]
GO
/****** Object:  Database [MultilingualDictionary]    Script Date: 22.8.2014 г. 14:23:58 ч. ******/
CREATE DATABASE [MultilingualDictionary]
 CONTAINMENT = NONE

ALTER DATABASE [MultilingualDictionary] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MultilingualDictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MultilingualDictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MultilingualDictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MultilingualDictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET RECOVERY FULL 
GO
ALTER DATABASE [MultilingualDictionary] SET  MULTI_USER 
GO
ALTER DATABASE [MultilingualDictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MultilingualDictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MultilingualDictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MultilingualDictionary', N'ON'
GO
USE [MultilingualDictionary]
GO
/****** Object:  Table [dbo].[Antonym]    Script Date: 22.8.2014 г. 14:23:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antonym](
	[AntonymId] [int] IDENTITY(1,1) NOT NULL,
	[Antonym] [nvarchar](50) NULL,
 CONSTRAINT [PK_Antonym] PRIMARY KEY CLUSTERED 
(
	[AntonymId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Explanation]    Script Date: 22.8.2014 г. 14:24:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanation](
	[ExplanationId] [int] IDENTITY(1,1) NOT NULL,
	[Explanation] [text] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[WordId] [int] NOT NULL,
 CONSTRAINT [PK_Explanation] PRIMARY KEY CLUSTERED 
(
	[ExplanationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Explanation_Language]    Script Date: 22.8.2014 г. 14:24:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanation_Language](
	[LanguageId] [int] NOT NULL,
	[ExplanationId] [int] NOT NULL,
 CONSTRAINT [PK_Explanation_Language] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC,
	[ExplanationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hypernym]    Script Date: 22.8.2014 г. 14:24:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hypernym](
	[HypernymId] [int] IDENTITY(1,1) NOT NULL,
	[Hypernym] [nvarchar](50) NULL,
	[WordId] [int] NULL,
 CONSTRAINT [PK_Hypernym] PRIMARY KEY CLUSTERED 
(
	[HypernymId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Language]    Script Date: 22.8.2014 г. 14:24:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[Language] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartOfSpeech]    Script Date: 22.8.2014 г. 14:24:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartOfSpeech](
	[PartOfSpeechId] [int] IDENTITY(1,1) NOT NULL,
	[PartOfSpeech] [nvarchar](50) NULL,
 CONSTRAINT [PK_PartOfSpeech] PRIMARY KEY CLUSTERED 
(
	[PartOfSpeechId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SynonymSet]    Script Date: 22.8.2014 г. 14:24:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SynonymSet](
	[SynonymSetId] [int] IDENTITY(1,1) NOT NULL,
	[SynonymSet] [nvarchar](50) NULL,
	[WordId] [int] NULL,
 CONSTRAINT [PK_SynonymSet] PRIMARY KEY CLUSTERED 
(
	[SynonymSetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translation]    Script Date: 22.8.2014 г. 14:24:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translation](
	[WordId] [int] NOT NULL,
	[TranslationId] [int] IDENTITY(1,1) NOT NULL,
	[LanguageId] [int] NOT NULL,
 CONSTRAINT [PK_Translation_1] PRIMARY KEY CLUSTERED 
(
	[TranslationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Word]    Script Date: 22.8.2014 г. 14:24:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Word](
	[WordId] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[AntonymId] [int] NULL,
	[PartOfSpeechId] [int] NULL,
	[HypernimId] [int] NULL,
 CONSTRAINT [PK_Word] PRIMARY KEY CLUSTERED 
(
	[WordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Word_Explanation]    Script Date: 22.8.2014 г. 14:24:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Word_Explanation](
	[WordId] [int] NOT NULL,
	[ExplanationId] [int] NOT NULL,
 CONSTRAINT [PK_Word_Explanation] PRIMARY KEY CLUSTERED 
(
	[WordId] ASC,
	[ExplanationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Word_PartOfSpeech]    Script Date: 22.8.2014 г. 14:24:00 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Word_PartOfSpeech](
	[WordId] [int] NOT NULL,
	[PartOfSpeechId] [int] NOT NULL,
 CONSTRAINT [PK_Word_PartOfSpeech] PRIMARY KEY CLUSTERED 
(
	[WordId] ASC,
	[PartOfSpeechId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Explanation]  WITH CHECK ADD  CONSTRAINT [FK_Explanation_Language] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([LanguageId])
GO
ALTER TABLE [dbo].[Explanation] CHECK CONSTRAINT [FK_Explanation_Language]
GO
ALTER TABLE [dbo].[Explanation]  WITH CHECK ADD  CONSTRAINT [FK_Explanation_Word] FOREIGN KEY([WordId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[Explanation] CHECK CONSTRAINT [FK_Explanation_Word]
GO
ALTER TABLE [dbo].[Explanation_Language]  WITH CHECK ADD  CONSTRAINT [FK_Explanation_Language_Explanation] FOREIGN KEY([ExplanationId])
REFERENCES [dbo].[Explanation] ([ExplanationId])
GO
ALTER TABLE [dbo].[Explanation_Language] CHECK CONSTRAINT [FK_Explanation_Language_Explanation]
GO
ALTER TABLE [dbo].[Explanation_Language]  WITH CHECK ADD  CONSTRAINT [FK_Explanation_Language_Language] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([LanguageId])
GO
ALTER TABLE [dbo].[Explanation_Language] CHECK CONSTRAINT [FK_Explanation_Language_Language]
GO
ALTER TABLE [dbo].[Hypernym]  WITH CHECK ADD  CONSTRAINT [FK_Hypernym_Word] FOREIGN KEY([WordId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[Hypernym] CHECK CONSTRAINT [FK_Hypernym_Word]
GO
ALTER TABLE [dbo].[SynonymSet]  WITH CHECK ADD  CONSTRAINT [FK_SynonymSet_Word] FOREIGN KEY([WordId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[SynonymSet] CHECK CONSTRAINT [FK_SynonymSet_Word]
GO
ALTER TABLE [dbo].[Translation]  WITH CHECK ADD  CONSTRAINT [FK_Translation_Language1] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([LanguageId])
GO
ALTER TABLE [dbo].[Translation] CHECK CONSTRAINT [FK_Translation_Language1]
GO
ALTER TABLE [dbo].[Translation]  WITH CHECK ADD  CONSTRAINT [FK_Translation_Word] FOREIGN KEY([WordId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[Translation] CHECK CONSTRAINT [FK_Translation_Word]
GO
ALTER TABLE [dbo].[Word]  WITH CHECK ADD  CONSTRAINT [FK_Word_Antonym] FOREIGN KEY([AntonymId])
REFERENCES [dbo].[Antonym] ([AntonymId])
GO
ALTER TABLE [dbo].[Word] CHECK CONSTRAINT [FK_Word_Antonym]
GO
ALTER TABLE [dbo].[Word]  WITH CHECK ADD  CONSTRAINT [FK_Word_Language] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([LanguageId])
GO
ALTER TABLE [dbo].[Word] CHECK CONSTRAINT [FK_Word_Language]
GO
ALTER TABLE [dbo].[Word]  WITH CHECK ADD  CONSTRAINT [FK_Word_Word] FOREIGN KEY([HypernimId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[Word] CHECK CONSTRAINT [FK_Word_Word]
GO
ALTER TABLE [dbo].[Word]  WITH CHECK ADD  CONSTRAINT [FK_Word_Word1] FOREIGN KEY([AntonymId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[Word] CHECK CONSTRAINT [FK_Word_Word1]
GO
ALTER TABLE [dbo].[Word_Explanation]  WITH CHECK ADD  CONSTRAINT [FK_Word_Explanation_Explanation] FOREIGN KEY([ExplanationId])
REFERENCES [dbo].[Explanation] ([ExplanationId])
GO
ALTER TABLE [dbo].[Word_Explanation] CHECK CONSTRAINT [FK_Word_Explanation_Explanation]
GO
ALTER TABLE [dbo].[Word_Explanation]  WITH CHECK ADD  CONSTRAINT [FK_Word_Explanation_Word] FOREIGN KEY([WordId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[Word_Explanation] CHECK CONSTRAINT [FK_Word_Explanation_Word]
GO
ALTER TABLE [dbo].[Word_PartOfSpeech]  WITH CHECK ADD  CONSTRAINT [FK_Word_PartOfSpeech_PartOfSpeech] FOREIGN KEY([PartOfSpeechId])
REFERENCES [dbo].[PartOfSpeech] ([PartOfSpeechId])
GO
ALTER TABLE [dbo].[Word_PartOfSpeech] CHECK CONSTRAINT [FK_Word_PartOfSpeech_PartOfSpeech]
GO
ALTER TABLE [dbo].[Word_PartOfSpeech]  WITH CHECK ADD  CONSTRAINT [FK_Word_PartOfSpeech_Word] FOREIGN KEY([WordId])
REFERENCES [dbo].[Word] ([WordId])
GO
ALTER TABLE [dbo].[Word_PartOfSpeech] CHECK CONSTRAINT [FK_Word_PartOfSpeech_Word]
GO
USE [master]
GO
ALTER DATABASE [MultilingualDictionary] SET  READ_WRITE 
GO
