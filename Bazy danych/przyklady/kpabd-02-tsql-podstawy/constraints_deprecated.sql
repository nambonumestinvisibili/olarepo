USE Test;
GO

-- czyszczenie
DROP TABLE IF EXISTS [dbo].[Dane];
GO
sp_unbindefault 'DT_plec'
GO
sp_unbindrule 'DT_plec'
GO
DROP RULE IF EXISTS R_plec;
GO
DROP DEFAULT IF EXISTS DF_plec
GO
sp_droptype DT_plec;
GO

-- dodajemy nowy typ
sp_addtype DT_plec, 'char(1)'
GO

-- tworzymy nowa warto�� domy�ln� i now� regu��
CREATE DEFAULT DF_plec AS '?'
GO

CREATE RULE R_plec AS @value in ('m','k','?')
GO

-- tworzymy tabelk�
CREATE TABLE [dbo].[Dane] (
	[id] [int] NOT NULL PRIMARY KEY,
	[imie] [varchar] (20) NULL ,
	[nazwisko] [varchar] (30)  ,
	[pesel] [char] (11) NULL ,
	[dataurodzenia] [datetime] NULL ,
	[plec] [DT_plec]
);
GO

-- dowi�zujemy do typu DT_plec warto�� domy�ln� DF_plec i regu�� R_plec
sp_bindefault DF_plec, 'DT_plec', FUTUREONLY
GO

sp_bindrule R_plec, 'DT_plec', FUTUREONLY
GO

-- wstawiamy dwa rekordy
INSERT INTO Dane(id, imie, nazwisko, pesel, dataurodzenia)
    VALUES(1, 'Anna', 'Deresz', '12345678901', '19500202')
INSERT INTO Dane(id, imie, nazwisko, pesel, dataurodzenia, plec)
    VALUES(2, 'Kasia', 'Ekola', '12345678901', '19500202','f')

-- zauwa�amy, �e ani warto�� domy�lna, ani regu�a dowi�zane uprzednio nie dzia�aj�
-- jest to spowodowane opcj� FUTUREONLY
SELECT * FROM Dane
-- pucujemy tabelk�
DELETE FROM Dane

-- odwi�zujemy od DT_plec warto�� domy�ln� i regu��
sp_unbindefault 'DT_plec'
GO

sp_unbindrule 'DT_plec'
GO

-- dowi�zujemy do typu DT_plec warto�� domy�ln� DF_plec i regu�� R_plec, ale bez opcji FUTUREONLY
sp_bindefault DF_plec, 'DT_plec'
GO

sp_bindrule R_plec, 'DT_plec'
GO

-- wstawiamy dwa rekordy
INSERT INTO Dane(id, imie, nazwisko, pesel, dataurodzenia)
    VALUES(1, 'Anna', 'Deresz', '12345678901', '19500202')
--INSERT INTO Dane(id, imie, nazwisko, pesel, dataurodzenia, plec)
--    VALUES(2, 'Kasia', 'Ekola', '12345678901', '19500202','f') -- bledne ze wzgl�du na 'f'
INSERT INTO Dane(id, imie, nazwisko, pesel, dataurodzenia, plec)
    VALUES(2, 'Kasia', 'Ekola', '12345678901', '19500202','k')

-- zauwa�amy, �e na kolumnie plec dzia�aj� zar�wno warto�� domy�lna jak i regu�a 
SELECT * FROM Dane
