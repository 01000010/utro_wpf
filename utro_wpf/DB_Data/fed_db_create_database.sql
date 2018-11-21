SET NOCOUNT ON
GO

-- Setting things to work with date time --

SET NOCOUNT ON
SET DATEFORMAT DMY

USE MASTER

DECLARE @DTTM NVARCHAR(55)
SELECT @DTTM=CONVERT(NVARCHAR, GETDATE(), 113)
RAISERROR('Creating the database ast %s ....', 1, 1, @DTTM) WITH NOWAIT

GO

-- Drop the previous data base if it already existed --

IF EXISTS(SELECT * FROM SYSDATABASES WHERE NAME='izdelie')
BEGIN
    RAISERROR('Dropping the existing database...', 0, 1)
    DROP DATABASE izdelie
END
GO

CHECKPOINT
GO

RAISERROR('Creating the database...', 0, 1)
CREATE DATABASE izdelie
GO

CHECKPOINT
GO

USE izdelie
GO

IF DB_NAME() <> 'izdelie'
    RAISERROR('Error in initializing izdelie, ''USE izdelie'' failed! Killing the SPID now.', 22, 127) WITH LOG
GO

-- Create the tables for the database --

CREATE TABLE ИЗДЕЛИЕ
(
    АРТИКУЛ NVARCHAR(300) NOT NULL
        PRIMARY KEY CLUSTERED,
    НАИМЕНОВАНИЕ NVARCHAR(300) NULL,
    ШИРИНА NUMERIC NULL,
    ДЛИНА NUMERIC NULL,
    ИЗОБРАЖЕНИЕ NVARCHAR(300) NULL,
    КОММЕНТАРИЙ NVARCHAR(MAX) NULL
)
GO

CREATE TABLE ПОЛЬЗОВАТЕЛЬ
(
    ЛОГИН NVARCHAR(300) NOT NULL
        PRIMARY KEY CLUSTERED,
    ПАРОЛЬ NVARCHAR(MAX) NOT NULL,
    РОЛЬ NVARCHAR(300) NOT NULL,
    НАИМЕНОВАНИЕ NVARCHAR(300) NULL
)
GO

CREATE TABLE ТКАНЬ
(
    АРТИКУЛ NVARCHAR(300) NOT NULL
        PRIMARY KEY CLUSTERED,
    НАИМЕНОВАНИЕ NVARCHAR(300) NULL,
    ЦВЕТ NVARCHAR(300) NULL,
    РИСУНОК NVARCHAR(300) NULL,
    ИЗОБРАЖЕНИЕ NVARCHAR(300) NULL,
    СОСТАВ NVARCHAR(MAX) NULL,
    ШИРИНА NUMERIC NULL,
    ДЛИНА NUMERIC NULL,
    ЦЕНА MONEY NULL
)
GO

CREATE TABLE ТКАНИ_ИЗДЕЛИЯ
(
    АРТИКУЛ_ТКАНИ NVARCHAR(300) NOT NULL
        REFERENCES ТКАНЬ(АРТИКУЛ),
    АРТИКУЛ_ИЗДЕЛИЯ NVARCHAR(300) NOT NULL
        REFERENCES ИЗДЕЛИЕ(АРТИКУЛ)
)
GO

CREATE TABLE СКЛАД_ТКАНИ
(
    РУЛОН NVARCHAR(300) NOT NULL
        PRIMARY KEY CLUSTERED,
    АРТИКУЛ_ТКАНИ NVARCHAR(300) NOT NULL
        REFERENCES ТКАНЬ(АРТИКУЛ),
    ШИРИНА NUMERIC NOT NULL,
    ДЛИНА NUMERIC NOT NULL
)
GO

CREATE TABLE ФУРНИТУРА 
(
    АРТИКУЛ NVARCHAR(300) NOT NULL
        PRIMARY KEY CLUSTERED,
    НАИМЕНОВАНИЕ NVARCHAR(300) NULL,
    ТИП NVARCHAR(300) NULL,
    ШИРИНА NUMERIC NULL,
    ДЛИНА NUMERIC NULL,
    ВЕС NUMERIC NULL,
    ИЗОБРАЖЕНИЕ NVARCHAR(300) NULL,
    ЦЕНА MONEY NULL
)
GO

CREATE TABLE ФУРНИТУРА_ИЗДЕЛИЯ
(
    АРТИКУЛ_ФУРНИТУРЫ NVARCHAR(300) NOT NULL
        REFERENCES ФУРНИТУРА(АРТИКУЛ),
    АРТИКУЛ_ИЗДЕЛИЯ NVARCHAR(300) NOT NULL
        REFERENCES ИЗДЕЛИЕ(АРТИКУЛ),
    РАЗМЕЩЕНИЕ NVARCHAR(300) NOT NULL,
    ШИРИНА NUMERIC NULL,
    ДЛИНА NUMERIC NULL,
    ПОВОРОТ NUMERIC NULL,
    КОЛИЧЕСТВО NUMERIC NOT NULL
)
GO

CREATE TABLE СКЛАД_ФУРНИТУРЫ
(
    ПАРТИЯ NVARCHAR(300) NOT NULL
        PRIMARY KEY CLUSTERED,
    АРТИКУЛ_ФУРНИТУРЫ NVARCHAR(300) NOT NULL
        REFERENCES ФУРНИТУРА(АРТИКУЛ),
    КОЛИЧЕСТВО NUMERIC NOT NULL
)
GO

CREATE TABLE ЗАКАЗ 
(
    НОМЕР NVARCHAR(300) NOT NULL
        PRIMARY KEY CLUSTERED,
    ДАТА DATETIME NOT NULL,
    ЭТАП_ВЫПОЛНЕНИЯ NVARCHAR(300) NOT NULL,
    ЗАКАЗЧИК NVARCHAR(300) NOT NULL
        REFERENCES ПОЛЬЗОВАТЕЛЬ(ЛОГИН),
    МЕНЕДЖЕР NVARCHAR(300) NOT NULL
        REFERENCES ПОЛЬЗОВАТЕЛЬ(ЛОГИН),
    СТОИМОСТЬ MONEY NULL 
)
GO

CREATE TABLE ЗАКАЗАННЫЕ_ИЗДЕЛИЯ 
(
    НОМЕР_ЗАКАЗА NVARCHAR(300) NOT NULL
        REFERENCES ЗАКАЗ(НОМЕР),
    АРТИКУЛ NVARCHAR(300) NOT NULL
        REFERENCES ИЗДЕЛИЕ(АРТИКУЛ),
    КОЛИЧЕСТВО NUMERIC NOT NULL
)
GO

RAISERROR('Database created...', 0, 1)
GO