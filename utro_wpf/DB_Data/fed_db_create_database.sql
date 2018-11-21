SET NOCOUNT ON
GO

-- Setting things to work with date time --

SET NOCOUNT ON
SET DATEFORMAT DMY

USE MASTER

DECLARE @DTTM VARCHAR(55)
SELECT @DTTM=CONVERT(VARCHAR, GETDATE(), 113)
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

USE bitch
GO

IF DB_NAME() <> 'izdelie'
    RAISERROR('Error in initializing izdelie, ''USE izdelie'' failed! Killing the SPID now.', 22, 127) WITH LOG
GO

-- Create the tables for the database --

CREATE TABLE ИЗДЕЛИЕ
(
    АРТИКУЛ VARCHAR(10) NOT NULL
        PRIMARY KEY CLUSTERED,
    НАИМЕНОВАНИЕ VARCHAR(100) NOT NULL,
    ШИРИНА NUMERIC NOT NULL,
    ДЛИНА NUMERIC NOT NULL,
    ИЗОБРАЖЕНИЕ VARCHAR(50) NULL,
    КОММЕНТАРИЙ VARCHAR(MAX) NULL
)
GO

CREATE TABLE ПОЛЬЗОВАТЕЛЬ
(
    ЛОГИН VARCHAR(50) NOT NULL
        PRIMARY KEY CLUSTERED,
    ПАРОЛЬ VARCHAR(MAX) NOT NULL,
    РОЛЬ VARCHAR(50) NOT NULL,
    НАИМЕНОВАНИЕ VARCHAR(50) NULL
)
GO

CREATE TABLE ТКАНЬ
(
    АРТИКУЛ VARCHAR(10) NOT NULL
        PRIMARY KEY CLUSTERED,
    НАИМЕНОВАНИЕ VARCHAR(100) NOT NULL,
    ЦВЕТ VARCHAR(50) NULL,
    РИСУНОК VARCHAR(50) NULL,
    ИЗОБРАЖЕНИЕ VARCHAR(50) NULL,
    СОСТАВ VARCHAR(MAX) NULL,
    ШИРИНА NUMERIC NOT NULL,
    ДЛИНА NUMERIC NOT NULL,
    ЦЕНА MONEY NOT NULL
)
GO

CREATE TABLE ТКАНИ_ИЗДЕЛИЯ
(
    АРТИКУЛ_ТКАНИ VARCHAR(10) NOT NULL
        REFERENCES ТКАНЬ(АРТИКУЛ),
    АРТИКУЛ_ИЗДЕЛИЯ VARCHAR(10) NOT NULL
        REFERENCES ИЗДЕЛИЕ(АРТИКУЛ)
)
GO

CREATE TABLE СКЛАД_ТКАНИ
(
    РУЛОН VARCHAR(10) NOT NULL
        PRIMARY KEY CLUSTERED,
    АРТИКУЛ_ТКАНИ VARCHAR(10) NOT NULL
        REFERENCES ТКАНЬ(АРТИКУЛ),
    ШИРИНА NUMERIC NOT NULL,
    ДЛИНА NUMERIC NOT NULL
)
GO

CREATE TABLE ФУРНИТУРА 
(
    АРТИКУЛ VARCHAR(10) NOT NULL
        PRIMARY KEY CLUSTERED,
    НАИМЕНОВАНИЕ VARCHAR(100) NOT NULL,
    ТИП VARCHAR(50) NOT NULL,
    ШИРИНА NUMERIC NOT NULL,
    ДЛИНА NUMERIC NULL,
    ВЕС NUMERIC NULL,
    ИЗОБРАЖЕНИЕ VARCHAR(50) NULL,
    ЦЕНА MONEY NOT NULL
)
GO

CREATE TABLE ФУРНИТУРА_ИЗДЕЛИЯ
(
    АРТИКУЛ_ФУРНИТУРЫ VARCHAR(10) NOT NULL
        REFERENCES ФУРНИТУРА(АРТИКУЛ),
    АРТИКУЛ_ИЗДЕЛИЯ VARCHAR(10) NOT NULL
        REFERENCES ИЗДЕЛИЕ(АРТИКУЛ),
    РАЗМЕЩЕНИЕ VARCHAR(200) NOT NULL,
    ШИРИНА NUMERIC NULL,
    ДЛИНА NUMERIC NULL,
    ПОВОРОТ NUMERIC NULL,
    КОЛИЧЕСТВО NUMERIC NOT NULL
)
GO

CREATE TABLE СКЛАД_ФУРНИТУРЫ
(
    ПАРТИЯ VARCHAR(10) NOT NULL
        PRIMARY KEY CLUSTERED,
    АРТИКУЛ_ФУРНИТУРЫ VARCHAR(10) NOT NULL
        REFERENCES ФУРНИТУРА(АРТИКУЛ),
    КОЛИЧЕСТВО NUMERIC NOT NULL
)
GO

CREATE TABLE ЗАКАЗ 
(
    НОМЕР VARCHAR(10) NOT NULL
        PRIMARY KEY CLUSTERED,
    ДАТА DATETIME NOT NULL,
    ЭТАП_ВЫПОЛНЕНИЯ VARCHAR(50) NOT NULL,
    ЗАКАЗЧИК VARCHAR(50) NOT NULL
        REFERENCES ПОЛЬЗОВАТЕЛЬ(ЛОГИН),
    МЕНЕДЖЕР VARCHAR(50) NOT NULL
        REFERENCES ПОЛЬЗОВАТЕЛЬ(ЛОГИН),
    СТОИМОСТЬ MONEY NULL 
)
GO

CREATE TABLE ЗАКАЗАННЫЕ_ИЗДЕЛИЯ 
(
    НОМЕР_ЗАКАЗА VARCHAR(10) NOT NULL
        REFERENCES ЗАКАЗ(НОМЕР),
    АРТИКУЛ VARCHAR(10) NOT NULL
        REFERENCES ИЗДЕЛИЕ(АРТИКУЛ),
    КОЛИЧЕСТВО NUMERIC NOT NULL
)
GO

RAISERROR('Database created...', 0, 1)
GO

-- Read the data from the excel file and write it into the database --

sp_configure 'show advanced options', 1;
RECONFIGURE;
GO
sp_configure 'Ad Hoc Distributed Queries', 1;
RECONFIGURE
GO

USE izdelie;
GO
SELECT * INTO TKANI_TEMP
FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0',
    'Excel 12.0; Database=номенклатура.xlsx', [Ткани$])
GO

USE izdelie;
GO
SELECT * INTO FURNI_TEMP
FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0',
    'Excel 12.0; Database=номерклатура.xlsx', [Фурнитура$])
GO

USE izdelie;
GO
SELECT * INTO IZD_TEMP
FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0',
    'Excel 12.0; Database=номерклатура.xlsx', [Изделия$])
GO

USE izdelie;
GO
INSERT INTO DBO.ТКАНЬ
    SELECT * FROM TKANI_TEMP
GO

USE izdelie;
GO
INSERT INTO DBO.ФУРНИТУРА
    SELECT * FROM FURNI_TEMP
GO

USE izdelie;
GO
INSERT INTO DBO.ИЗДЕЛИЕ
    SELECT * FROM IZD_TEMP
GO