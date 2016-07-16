USE [master]
GO
/****** Object:  Database [hair_salon]    Script Date: 7/16/2016 9:27:18 AM ******/
CREATE DATABASE [hair_salon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hair_salon', FILENAME = N'C:\Users\Shradha Pulla\hair_salon.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'hair_salon_log', FILENAME = N'C:\Users\Shradha Pulla\hair_salon_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [hair_salon] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hair_salon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hair_salon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hair_salon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hair_salon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hair_salon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hair_salon] SET ARITHABORT OFF 
GO
ALTER DATABASE [hair_salon] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [hair_salon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hair_salon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hair_salon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hair_salon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hair_salon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hair_salon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hair_salon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hair_salon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hair_salon] SET  ENABLE_BROKER 
GO
ALTER DATABASE [hair_salon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hair_salon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hair_salon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hair_salon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hair_salon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hair_salon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hair_salon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hair_salon] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [hair_salon] SET  MULTI_USER 
GO
ALTER DATABASE [hair_salon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hair_salon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hair_salon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hair_salon] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [hair_salon] SET DELAYED_DURABILITY = DISABLED 
GO
USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 7/16/2016 9:27:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](255) NULL,
	[last_name] [varchar](255) NULL,
	[phone_number] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stylists]    Script Date: 7/16/2016 9:27:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](255) NULL,
	[last_name] [varchar](255) NULL,
	[phone_number] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[street_address] [varchar](500) NULL,
	[city_address] [varchar](255) NULL,
	[state_address] [varchar](255) NULL,
	[zipcode] [varchar](255) NULL
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [hair_salon] SET  READ_WRITE 
GO
