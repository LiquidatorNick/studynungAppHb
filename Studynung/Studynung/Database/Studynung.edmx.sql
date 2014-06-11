
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/09/2014 10:18:18
-- Generated from EDMX file: C:\Users\Nick\Documents\GitHub\studynungAppHb\Studynung\Studynung\Database\Studynung.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db4ca9ca25b0bd49b69fe0a3160091430d];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsersInRoles_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersInRoles] DROP CONSTRAINT [FK_UsersInRoles_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersInRoles_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersInRoles] DROP CONSTRAINT [FK_UsersInRoles_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_TeacherInfoCathedra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeacherInfoes] DROP CONSTRAINT [FK_TeacherInfoCathedra];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentInfoAcademicGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentInfoes] DROP CONSTRAINT [FK_StudentInfoAcademicGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_UserLaboratoryProcess]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LaboratoryProcesses] DROP CONSTRAINT [FK_UserLaboratoryProcess];
GO
IF OBJECT_ID(N'[dbo].[FK_LaboratoryProcessLaboratoryResult]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LaboratoryResults] DROP CONSTRAINT [FK_LaboratoryProcessLaboratoryResult];
GO
IF OBJECT_ID(N'[dbo].[FK_LaboratoryProcessLaboratoryWork]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LaboratoryProcesses] DROP CONSTRAINT [FK_LaboratoryProcessLaboratoryWork];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[StudentInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentInfoes];
GO
IF OBJECT_ID(N'[dbo].[TeacherInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeacherInfoes];
GO
IF OBJECT_ID(N'[dbo].[Cathedras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cathedras];
GO
IF OBJECT_ID(N'[dbo].[AcademicGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AcademicGroups];
GO
IF OBJECT_ID(N'[dbo].[LaboratoryWorks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LaboratoryWorks];
GO
IF OBJECT_ID(N'[dbo].[LaboratoryProcesses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LaboratoryProcesses];
GO
IF OBJECT_ID(N'[dbo].[LaboratoryResults]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LaboratoryResults];
GO
IF OBJECT_ID(N'[dbo].[UsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersInRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [MiddleName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StudentInfoes'
CREATE TABLE [dbo].[StudentInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [AcademicGroup_Id] int  NOT NULL
);
GO

-- Creating table 'TeacherInfoes'
CREATE TABLE [dbo].[TeacherInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Cathedra_Id] int  NOT NULL
);
GO

-- Creating table 'Cathedras'
CREATE TABLE [dbo].[Cathedras] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AcademicGroups'
CREATE TABLE [dbo].[AcademicGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LaboratoryWorks'
CREATE TABLE [dbo].[LaboratoryWorks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LaboratoryProcesses'
CREATE TABLE [dbo].[LaboratoryProcesses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [StartDateTime] datetime  NULL,
    [EndDateTime] datetime  NULL,
    [UserId] int  NOT NULL,
    [LaboratoryWorkId] int  NOT NULL
);
GO

-- Creating table 'LaboratoryResults'
CREATE TABLE [dbo].[LaboratoryResults] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Results] nvarchar(max)  NULL,
    [Errors] nvarchar(max)  NULL,
    [LaboratoryProcess_Id] int  NOT NULL
);
GO

-- Creating table 'UsersInRoles'
CREATE TABLE [dbo].[UsersInRoles] (
    [Users_Id] int  NOT NULL,
    [Roles_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentInfoes'
ALTER TABLE [dbo].[StudentInfoes]
ADD CONSTRAINT [PK_StudentInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeacherInfoes'
ALTER TABLE [dbo].[TeacherInfoes]
ADD CONSTRAINT [PK_TeacherInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cathedras'
ALTER TABLE [dbo].[Cathedras]
ADD CONSTRAINT [PK_Cathedras]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AcademicGroups'
ALTER TABLE [dbo].[AcademicGroups]
ADD CONSTRAINT [PK_AcademicGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LaboratoryWorks'
ALTER TABLE [dbo].[LaboratoryWorks]
ADD CONSTRAINT [PK_LaboratoryWorks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LaboratoryProcesses'
ALTER TABLE [dbo].[LaboratoryProcesses]
ADD CONSTRAINT [PK_LaboratoryProcesses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LaboratoryResults'
ALTER TABLE [dbo].[LaboratoryResults]
ADD CONSTRAINT [PK_LaboratoryResults]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Users_Id], [Roles_Id] in table 'UsersInRoles'
ALTER TABLE [dbo].[UsersInRoles]
ADD CONSTRAINT [PK_UsersInRoles]
    PRIMARY KEY CLUSTERED ([Users_Id], [Roles_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Users_Id] in table 'UsersInRoles'
ALTER TABLE [dbo].[UsersInRoles]
ADD CONSTRAINT [FK_UsersInRoles_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_Id] in table 'UsersInRoles'
ALTER TABLE [dbo].[UsersInRoles]
ADD CONSTRAINT [FK_UsersInRoles_Role]
    FOREIGN KEY ([Roles_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersInRoles_Role'
CREATE INDEX [IX_FK_UsersInRoles_Role]
ON [dbo].[UsersInRoles]
    ([Roles_Id]);
GO

-- Creating foreign key on [Cathedra_Id] in table 'TeacherInfoes'
ALTER TABLE [dbo].[TeacherInfoes]
ADD CONSTRAINT [FK_TeacherInfoCathedra]
    FOREIGN KEY ([Cathedra_Id])
    REFERENCES [dbo].[Cathedras]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherInfoCathedra'
CREATE INDEX [IX_FK_TeacherInfoCathedra]
ON [dbo].[TeacherInfoes]
    ([Cathedra_Id]);
GO

-- Creating foreign key on [AcademicGroup_Id] in table 'StudentInfoes'
ALTER TABLE [dbo].[StudentInfoes]
ADD CONSTRAINT [FK_StudentInfoAcademicGroup]
    FOREIGN KEY ([AcademicGroup_Id])
    REFERENCES [dbo].[AcademicGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentInfoAcademicGroup'
CREATE INDEX [IX_FK_StudentInfoAcademicGroup]
ON [dbo].[StudentInfoes]
    ([AcademicGroup_Id]);
GO

-- Creating foreign key on [UserId] in table 'LaboratoryProcesses'
ALTER TABLE [dbo].[LaboratoryProcesses]
ADD CONSTRAINT [FK_UserLaboratoryProcess]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserLaboratoryProcess'
CREATE INDEX [IX_FK_UserLaboratoryProcess]
ON [dbo].[LaboratoryProcesses]
    ([UserId]);
GO

-- Creating foreign key on [LaboratoryProcess_Id] in table 'LaboratoryResults'
ALTER TABLE [dbo].[LaboratoryResults]
ADD CONSTRAINT [FK_LaboratoryProcessLaboratoryResult]
    FOREIGN KEY ([LaboratoryProcess_Id])
    REFERENCES [dbo].[LaboratoryProcesses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LaboratoryProcessLaboratoryResult'
CREATE INDEX [IX_FK_LaboratoryProcessLaboratoryResult]
ON [dbo].[LaboratoryResults]
    ([LaboratoryProcess_Id]);
GO

-- Creating foreign key on [LaboratoryWorkId] in table 'LaboratoryProcesses'
ALTER TABLE [dbo].[LaboratoryProcesses]
ADD CONSTRAINT [FK_LaboratoryProcessLaboratoryWork]
    FOREIGN KEY ([LaboratoryWorkId])
    REFERENCES [dbo].[LaboratoryWorks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LaboratoryProcessLaboratoryWork'
CREATE INDEX [IX_FK_LaboratoryProcessLaboratoryWork]
ON [dbo].[LaboratoryProcesses]
    ([LaboratoryWorkId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------