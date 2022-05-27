USE [master]
GO
/****** Object:  Database [Project]    Script Date: 5/25/2022 8:01:45 PM ******/
CREATE DATABASE [Project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Project', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER2019\MSSQL\DATA\Project.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Project_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER2019\MSSQL\DATA\Project_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Project] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Project] SET ARITHABORT OFF 
GO
ALTER DATABASE [Project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Project] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Project] SET RECOVERY FULL 
GO
ALTER DATABASE [Project] SET  MULTI_USER 
GO
ALTER DATABASE [Project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Project] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Project] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Project] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Project', N'ON'
GO
ALTER DATABASE [Project] SET QUERY_STORE = OFF
GO
USE [Project]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/25/2022 8:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] NULL,
	[CategoryName] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/25/2022 8:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](max) NULL,
	[CategoryID] [int] NULL,
	[CategoryName] [varchar](max) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'test1')
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [CategoryName]) VALUES (1, N'Product5', 56, N'Category5')
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [CategoryName]) VALUES (2, N'Mouse', 2, N'Comp')
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [CategoryName]) VALUES (3, N'Product1', 2, N'Category2')
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [CategoryName]) VALUES (4, N'Product3', 56, N'Category3')
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [CategoryName]) VALUES (1002, N'Product5', 56, N'Category5')
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 5/25/2022 8:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddCategory]
   @CategoryID int ,  
   @CategoryName varchar (50)
AS
BEGIN
	 Insert into Category([CategoryID], [CategoryName])
	 values(@CategoryID,@CategoryName)  
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewProduct]    Script Date: 5/25/2022 8:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddNewProduct]  
(  
   @ProductName varchar (50),  
   @CategoryID int ,  
   @CategoryName varchar (50)  
)  
as  
begin  
   Insert into Product([ProductName], [CategoryID], [CategoryName]) values(@ProductName,@CategoryID,@CategoryName)  
End
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 5/25/2022 8:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteCategory]
 @CategoryId int  
	
AS
BEGIN
	 Delete from Category where CategoryId=@CategoryId  
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteproById]    Script Date: 5/25/2022 8:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteproById]  
(  
   @ProductId int  
)  
as   
begin  
   Delete from Product where ProductId=@ProductId  
End 
GO
/****** Object:  StoredProcedure [dbo].[GetCategory]    Script Date: 5/25/2022 8:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCategory]

AS
BEGIN
	select *from Category
END
GO
/****** Object:  StoredProcedure [dbo].[GetProduct]    Script Date: 5/25/2022 8:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetProduct]   
as  
begin  
   select *from product  
End 
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategory]    Script Date: 5/25/2022 8:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




















CREATE PROCEDURE [dbo].[UpdateCategory]
	-- Add the parameters for the stored procedure here
	 @CategoryId int,  
     @CategoryName varchar (50)
AS
BEGIN
	Update Category   
   set CategoryName=@CategoryName
   where CategoryId=@CategoryId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 5/25/2022 8:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create procedure [dbo].[UpdateProduct]  
(  
   @ProductID int,  
   @ProductName varchar (50),  
   @CategoryID int,  
   @CategoryName varchar (50)  
)  
as  
begin  
   Update Product   
   set ProductName=@ProductName,  
   CategoryID=@CategoryID,  
   CategoryName=@CategoryName
   where ProductID=@ProductID  
End 
GO
USE [master]
GO
ALTER DATABASE [Project] SET  READ_WRITE 
GO
