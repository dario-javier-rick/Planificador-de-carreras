
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/31/2017 18:30:43
-- Generated from EDMX file: C:\Users\dario\Source\Repos\Planificador-de-carreras\Planificador\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PlanificadorCarreras];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [IdUsuario] int IDENTITY(1,1) NOT NULL,
    [DNI] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [FechaUltimaActualizacion] datetime  NOT NULL,
    [Pass] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MateriaSet'
CREATE TABLE [dbo].[MateriaSet] (
    [IdMateria] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [EsConNota] bit  NOT NULL
);
GO

-- Creating table 'CarreraSet'
CREATE TABLE [dbo].[CarreraSet] (
    [IdCarrera] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MateriasPorCarreraSet'
CREATE TABLE [dbo].[MateriasPorCarreraSet] (
    [IdMateriaPorCarrera] int IDENTITY(1,1) NOT NULL,
    [IdMateria] int  NOT NULL,
    [IdCarrera] int  NOT NULL
);
GO

-- Creating table 'CarrerasPorUsuarioSet'
CREATE TABLE [dbo].[CarrerasPorUsuarioSet] (
    [IdCarreraPorUsuario] int IDENTITY(1,1) NOT NULL,
    [IdUsuario] int  NOT NULL,
    [IdCarrera] int  NOT NULL,
    [Promedio] decimal(18,0)  NOT NULL,
    [PorcentajeCompletitud] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'MateriasPorUsuarioSet'
CREATE TABLE [dbo].[MateriasPorUsuarioSet] (
    [IdMateriaPorUsuario] int IDENTITY(1,1) NOT NULL,
    [IdUsuario] int  NOT NULL,
    [IdMateria] int  NOT NULL,
    [EstaAprobada] bit  NOT NULL,
    [Nota] smallint  NOT NULL
);
GO

-- Creating table 'CorrelativaPorMateriaSet'
CREATE TABLE [dbo].[CorrelativaPorMateriaSet] (
    [IdCorrelativaPorMateria] int IDENTITY(1,1) NOT NULL,
    [IdMateriaOrigen] int  NOT NULL,
    [IdMateriaDestino] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdUsuario] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC);
GO

-- Creating primary key on [IdMateria] in table 'MateriaSet'
ALTER TABLE [dbo].[MateriaSet]
ADD CONSTRAINT [PK_MateriaSet]
    PRIMARY KEY CLUSTERED ([IdMateria] ASC);
GO

-- Creating primary key on [IdCarrera] in table 'CarreraSet'
ALTER TABLE [dbo].[CarreraSet]
ADD CONSTRAINT [PK_CarreraSet]
    PRIMARY KEY CLUSTERED ([IdCarrera] ASC);
GO

-- Creating primary key on [IdMateriaPorCarrera] in table 'MateriasPorCarreraSet'
ALTER TABLE [dbo].[MateriasPorCarreraSet]
ADD CONSTRAINT [PK_MateriasPorCarreraSet]
    PRIMARY KEY CLUSTERED ([IdMateriaPorCarrera] ASC);
GO

-- Creating primary key on [IdCarreraPorUsuario] in table 'CarrerasPorUsuarioSet'
ALTER TABLE [dbo].[CarrerasPorUsuarioSet]
ADD CONSTRAINT [PK_CarrerasPorUsuarioSet]
    PRIMARY KEY CLUSTERED ([IdCarreraPorUsuario] ASC);
GO

-- Creating primary key on [IdMateriaPorUsuario] in table 'MateriasPorUsuarioSet'
ALTER TABLE [dbo].[MateriasPorUsuarioSet]
ADD CONSTRAINT [PK_MateriasPorUsuarioSet]
    PRIMARY KEY CLUSTERED ([IdMateriaPorUsuario] ASC);
GO

-- Creating primary key on [IdCorrelativaPorMateria] in table 'CorrelativaPorMateriaSet'
ALTER TABLE [dbo].[CorrelativaPorMateriaSet]
ADD CONSTRAINT [PK_CorrelativaPorMateriaSet]
    PRIMARY KEY CLUSTERED ([IdCorrelativaPorMateria] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdUsuario] in table 'MateriasPorUsuarioSet'
ALTER TABLE [dbo].[MateriasPorUsuarioSet]
ADD CONSTRAINT [FK_UsuarioMateriasPorUsuario]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[UsuarioSet]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioMateriasPorUsuario'
CREATE INDEX [IX_FK_UsuarioMateriasPorUsuario]
ON [dbo].[MateriasPorUsuarioSet]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdUsuario] in table 'CarrerasPorUsuarioSet'
ALTER TABLE [dbo].[CarrerasPorUsuarioSet]
ADD CONSTRAINT [FK_UsuarioCarrerasPorUsuario]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[UsuarioSet]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioCarrerasPorUsuario'
CREATE INDEX [IX_FK_UsuarioCarrerasPorUsuario]
ON [dbo].[CarrerasPorUsuarioSet]
    ([IdUsuario]);
GO

-- Creating foreign key on [IdMateria] in table 'MateriasPorCarreraSet'
ALTER TABLE [dbo].[MateriasPorCarreraSet]
ADD CONSTRAINT [FK_MateriaMateriasPorCarrera]
    FOREIGN KEY ([IdMateria])
    REFERENCES [dbo].[MateriaSet]
        ([IdMateria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MateriaMateriasPorCarrera'
CREATE INDEX [IX_FK_MateriaMateriasPorCarrera]
ON [dbo].[MateriasPorCarreraSet]
    ([IdMateria]);
GO

-- Creating foreign key on [IdMateria] in table 'MateriasPorUsuarioSet'
ALTER TABLE [dbo].[MateriasPorUsuarioSet]
ADD CONSTRAINT [FK_MateriaMateriasPorUsuario]
    FOREIGN KEY ([IdMateria])
    REFERENCES [dbo].[MateriaSet]
        ([IdMateria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MateriaMateriasPorUsuario'
CREATE INDEX [IX_FK_MateriaMateriasPorUsuario]
ON [dbo].[MateriasPorUsuarioSet]
    ([IdMateria]);
GO

-- Creating foreign key on [IdCarrera] in table 'MateriasPorCarreraSet'
ALTER TABLE [dbo].[MateriasPorCarreraSet]
ADD CONSTRAINT [FK_CarreraMateriasPorCarrera]
    FOREIGN KEY ([IdCarrera])
    REFERENCES [dbo].[CarreraSet]
        ([IdCarrera])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarreraMateriasPorCarrera'
CREATE INDEX [IX_FK_CarreraMateriasPorCarrera]
ON [dbo].[MateriasPorCarreraSet]
    ([IdCarrera]);
GO

-- Creating foreign key on [IdCarrera] in table 'CarrerasPorUsuarioSet'
ALTER TABLE [dbo].[CarrerasPorUsuarioSet]
ADD CONSTRAINT [FK_CarreraCarrerasPorUsuario]
    FOREIGN KEY ([IdCarrera])
    REFERENCES [dbo].[CarreraSet]
        ([IdCarrera])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarreraCarrerasPorUsuario'
CREATE INDEX [IX_FK_CarreraCarrerasPorUsuario]
ON [dbo].[CarrerasPorUsuarioSet]
    ([IdCarrera]);
GO

-- Creating foreign key on [IdMateriaOrigen] in table 'CorrelativaPorMateriaSet'
ALTER TABLE [dbo].[CorrelativaPorMateriaSet]
ADD CONSTRAINT [FK_MateriasPorCarreraCorrelativaPorMateria]
    FOREIGN KEY ([IdMateriaOrigen])
    REFERENCES [dbo].[MateriasPorCarreraSet]
        ([IdMateriaPorCarrera])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MateriasPorCarreraCorrelativaPorMateria'
CREATE INDEX [IX_FK_MateriasPorCarreraCorrelativaPorMateria]
ON [dbo].[CorrelativaPorMateriaSet]
    ([IdMateriaOrigen]);
GO

-- Creating foreign key on [IdMateriaDestino] in table 'CorrelativaPorMateriaSet'
ALTER TABLE [dbo].[CorrelativaPorMateriaSet]
ADD CONSTRAINT [FK_IdMateriaDestino]
    FOREIGN KEY ([IdMateriaDestino])
    REFERENCES [dbo].[MateriasPorCarreraSet]
        ([IdMateriaPorCarrera])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IdMateriaDestino'
CREATE INDEX [IX_FK_IdMateriaDestino]
ON [dbo].[CorrelativaPorMateriaSet]
    ([IdMateriaDestino]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------