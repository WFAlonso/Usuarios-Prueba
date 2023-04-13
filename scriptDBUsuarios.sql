USE [master]
GO
/****** Object:  Database [DBPruebaWFUsuarios]    Script Date: 13/04/2023 11:42:45 a. m. ******/
CREATE DATABASE [DBPruebaWFUsuarios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBPruebaWFUsuarios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBPruebaWFUsuarios.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBPruebaWFUsuarios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBPruebaWFUsuarios_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBPruebaWFUsuarios].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET RECOVERY FULL 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET  MULTI_USER 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBPruebaWFUsuarios', N'ON'
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET QUERY_STORE = OFF
GO
USE [DBPruebaWFUsuarios]
GO
/****** Object:  User [test]    Script Date: 13/04/2023 11:42:45 a. m. ******/
CREATE USER [test] FOR LOGIN [test] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 13/04/2023 11:42:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[FechaNacimiento] [date] NULL,
	[Sexo] [char](1) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CRUD_USUARIOS]    Script Date: 13/04/2023 11:42:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CRUD_USUARIOS] 

	@Accion int = 0,
	@id int = 0,
	@Nombre varchar(100) = null,
	@Nacimiento date = null,
	@Sexo char = null
AS
BEGIN
	
	BEGIN TRY  
		-- consulta
		IF @Accion = 0 
		BEGIN
			IF @id = 0 
			BEGIN
				SELECT a.id, a.Nombre, a.FechaNacimiento, a.Sexo
				FROM dbo.Usuarios as a
			END 
			ELSE
			BEGIN
				SELECT a.id, a.Nombre, a.FechaNacimiento, a.Sexo
				FROM dbo.Usuarios as a
				WHERE id = @id
			END
		END 
		
		-- Inserta
		IF @Accion = 1
		BEGIN
			  INSERT INTO DBO.Usuarios (Nombre, FechaNacimiento, Sexo) VALUES
			  (@Nombre, @Nacimiento, @Sexo)
		END

		

		-- Actualiza
		IF @Accion = 2
		BEGIN
			IF NOT EXISTS ( SELECT a.id FROM dbo.Usuarios as a WHERE id = @id )
			BEGIN
				SELECT 423 'CodeError', 'Registro no encontrado' 'Message'
			END
			ELSE
			BEGIN
				UPDATE dbo.Usuarios
				SET Nombre = @Nombre,
					FechaNacimiento = @Nacimiento,
					Sexo = @Sexo
				WHERE id = @id
			END
		END
		
		-- Elimina
		IF @Accion = 3
		BEGIN
				DELETE FROM dbo.Usuarios 
				WHERE id = @id
		END
		
	
	END TRY  
	BEGIN CATCH  
		SELECT   
			ERROR_NUMBER() AS ErrorNumber  
			,ERROR_SEVERITY() AS ErrorSeverity  
			,ERROR_STATE() AS ErrorState  
			,ERROR_PROCEDURE() AS ErrorProcedure  
			,ERROR_LINE() AS ErrorLine  
			,ERROR_MESSAGE() AS ErrorMessage;  
  
		IF @@TRANCOUNT > 0  
			ROLLBACK TRANSACTION;  
	END CATCH;  
  
	IF @@TRANCOUNT > 0  
		COMMIT TRANSACTION;  
	
END
GO
USE [master]
GO
ALTER DATABASE [DBPruebaWFUsuarios] SET  READ_WRITE 
GO
