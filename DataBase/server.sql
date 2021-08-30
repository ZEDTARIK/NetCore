USE [VueJsApi]
GO

/****** Objet : Table [dbo].[Departments] Date du script : 30/08/2021 17:00:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Departments];


GO
CREATE TABLE [dbo].[Departments] (
    [DepartmentId]   INT          IDENTITY (1, 1) NOT NULL,
    [DepartmentName] VARCHAR (50) NULL
);

GO 

USE [VueJsApi]
GO

/****** Objet : Table [dbo].[Employees] Date du script : 30/08/2021 17:00:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees] (
    [EmployeeId]    INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeName]  VARCHAR (50)   NOT NULL,
    [Department]    VARCHAR (50)   NULL,
    [DateOfJoining] DATETIME       NULL,
    [PhotoFileName] NVARCHAR (100) NULL
);


GO
CREATE TABLE [dbo].[Departments] (
    [DepartmentId]   INT          IDENTITY (1, 1) NOT NULL,
    [DepartmentName] VARCHAR (50) NULL
);




