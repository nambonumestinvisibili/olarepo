SET STATISTICS TIME ON
--3

-- inne zapytanie 
SELECT c.PESEL, c.Nazwisko
FROM Czytelnik c WHERE c.Czytelnik_ID IN
(SELECT w.Czytelnik_ID 
	FROM Wypozyczenie w, Egzemplarz e, Ksiazka k 
	WHERE e.Egzemplarz_ID = w.Egzemplarz_ID 
			AND e.Ksiazka_ID = k.Ksiazka_ID)



-- Client processing time:		43.7
-- Total execution time:		44.4 --SHORTEST
-- Wait time on server replies:	0.7



SET STATISTICS TIME Off