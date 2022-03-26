-- --Z1
DROP TABLE IF EXISTS UniSubjects
GO

CREATE TABLE UniSubjects (
    ID INT IDENTITY PRIMARY KEY,
    SubjectName VARCHAR(50),
    StudentsEnrolled INT 
)
GO

INSERT INTO UniSubjects
VALUES ('Discrete Math', 39),
('Numerical Analisis', 45),
('Object Oriented Programming', 70)
GO

-- --DIRTY READS



-- -- --T1
-- BEGIN TRANSACTION 
-- UPDATE UniSubjects SET StudentsEnrolled = 0 WHERE ID = 1
-- UPDATE UniSubjects SET StudentsEnrolled = 0 WHERE ID = 3
-- --lets imagine a case that we have to wait for some reason
-- WAITFOR DELAY '00:00:05'
-- SELECT 'DATA CHANGED'
-- SELECT * FROM UniSubjects 
-- --something went terribly bad, there is a need for rollback
-- ROLLBACK TRANSACTION
-- SELECT 'DATA ROLLBACKED'
-- SELECT * From UniSubjects








--NON-REPEATABLE READS
--T1
-- SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED --ALLOWS non-repeatable reads

-- BEGIN TRAN
-- SELECT * FROM UniSubjects
-- WAITFOR DELAY '00:00:05'
-- SELECT * FROM UniSubjects
-- COMMIT












-- -- PHANTOMS
BEGIN TRAN
SELECT * FROM UniSubjects
WAITFOR DELAY '00:00:05'
SELECT * FROM UniSubjects
COMMIT