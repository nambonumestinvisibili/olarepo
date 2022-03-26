-- --Z1
-- --DIRTY READ
-- --T2
-- SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED --alows dirty reads
-- SELECT * FROM UniSubjects





--NON-REPEATABLE READS
--T2
-- SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED 

-- BEGIN TRAN
-- UPDATE UniSubjects SET StudentsEnrolled = 0 WHERE ID = 1
-- SELECT * FROM UniSubjects
-- COMMIT 




-- --PHANTOM
-- --T2

BEGIN TRAN 
DELETE FROM UniSubjects WHERE ID = 3
COMMIT








-- FOR TASK 1
--                          Dirty read          Non-repeatable read             Phantoms
-- read uncomitted          y                   y                               y
-- read uncomitted          n                   y                               y
-- repeatable read          n                   n                               y
-- serialisable             n                   n                               n
