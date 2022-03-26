--Z1


-- DROP FUNCTION IF EXISTS exc1
-- GO

-- CREATE FUNCTION exc1(@days INT) RETURNS TABLE 
--     RETURN 
--         SELECT Reader.PESEL, COUNT(Bor.Czytelnik_ID) AS NoOfSpecimens

--         FROM TEST.dbo.Wypozyczenie AS Bor,
--              TEST.dbo.Czytelnik AS Reader
--         WHERE Bor.Liczba_Dni >= @days AND Reader.Czytelnik_ID = Bor.Czytelnik_ID
--         GROUP BY Reader.PESEL
-- GO

-- DECLARE @days INT
-- SET @days = 7

-- SELECT * FROM exc1(@days)
-- GO


-- -- helper
-- DROP PROCEDURE IF EXISTS exc1a
-- GO

-- CREATE PROCEDURE exc1a @days INT AS 
--     BEGIN 
--         SELECT *

--         FROM TEST.dbo.Wypozyczenie AS Wyp
--         WHERE Wyp.Liczba_Dni >= @days
        
--     END
-- GO
-- EXEC exc1a @days = 7
-- GO



--z2
-- DROP TABLE IF EXISTS Firstnames
-- GO
-- DROP TABLE IF EXISTS Lastnames
-- GO
-- DROP TABLE IF EXISTS Fldata
-- GO

-- CREATE TABLE Firstnames (
--     id INT PRIMARY KEY IDENTITY,
--     firstname VARCHAR(20)
-- )

-- CREATE TABLE Lastnames (
--     id INT PRIMARY KEY IDENTITY,
--     lastname VARCHAR(20)
-- )

-- CREATE TABLE Fldata (
--     firstname VARCHAR(20),
--     lastname VARCHAR(20),
--     CONSTRAINT PK_Fldata PRIMARY KEY (firstname, lastname)
-- )

-- GO

-- INSERT INTO Firstnames 
-- VALUES ('Angelika'), ('Przemek'), ('Iwona'), ('Kacper'), ('Dawid'), ('Filip'), ('Bernat'), ('Santi'), ('Kasia')

-- INSERT INTO Lastnames
-- VALUES ('Sadurski'), ('Holewa'), ('Puig'), ('Bączek'), ('Kostecka'), ('Potocki'), ('Charatonik'), ('Łukomska')

-- GO

-- DROP PROCEDURE IF EXISTS exc2 
-- GO

-- CREATE PROCEDURE exc2 @n INT AS
-- BEGIN
--     TRUNCATE TABLE Fldata

--     DECLARE @#Fnames INT
--     DECLARE @#Lnames INT
--     DECLARE @#PossiblePairings INT

--     SET @#Fnames = (Select Count(Firstnames.id) FROM Firstnames)
--     SET @#Lnames = (Select Count(Lastnames.id) FROM Lastnames)
--     SET @#PossiblePairings = @#Fnames * @#Lnames
    

--     IF (@n > @#PossiblePairings)
--         BEGIN;
--             THROW 60000, 'n is greater than all possible pairings',1
--         END

    

--     WHILE (@n > 0)
--         BEGIN
--              DECLARE @fname VARCHAR(20)
--              DECLARE @lname VARCHAR(20)
--              SET @fname = (SELECT TOP(1) firstname FROM Firstnames ORDER BY NEWID()) -- Because GUIDs are pretty random, the ordering means you get a random row.
--              SET @lname = (SELECT TOP 1 lastname FROM Lastnames ORDER BY NEWID())
--              IF NOT EXISTS (SELECT * FROM Fldata WHERE Fldata.firstname = @fname AND Fldata.lastname = @lname)
--                 BEGIN
--                     INSERT INTO Fldata VALUES (@fname, @lname)
--                     SET @n = @n - 1
--                 END
--         END
    
--     SELECT * FROM Fldata
-- END
-- go

-- EXEC exc2 10
-- GO


--z3

-- DROP PROCEDURE IF EXISTS exc3
-- GO

-- DROP TYPE IF EXISTS ReadersIds
-- GO

-- CREATE TYPE ReadersIds AS TABLE(rID INT)
-- GO


-- CREATE PROCEDURE exc3 @readers ReadersIds READONLY AS
-- BEGIN
--     SELECT Readers.rID, SUM(Wypozyczenie.Liczba_Dni)
--     FROM @readers as Readers, Czytelnik, Wypozyczenie
--     WHERE Czytelnik.Czytelnik_ID = Wypozyczenie.Czytelnik_ID
--           AND Readers.rID = Czytelnik.Czytelnik_ID
--     GROUP BY Readers.rID
-- END
-- GO

-- DECLARE @readers ReadersIds
-- INSERT INTO @readers VALUES (1), (2)

-- EXEC exc3 @readers
-- GO


-- --helper
-- SELECT Czytelnik.Czytelnik_ID, SUM(Wypozyczenie.Liczba_Dni)
--     FROM Czytelnik, Wypozyczenie
--     WHERE Czytelnik.Czytelnik_ID = Wypozyczenie.Czytelnik_ID
--     GROUP BY Czytelnik.Czytelnik_ID


--z4
-- DECLARE @SQL 
-- SET @SQL = N'

-- '