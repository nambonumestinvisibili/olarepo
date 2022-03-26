

-- TASK 2




-- ORIGINAL
-- ID | Patient | PatientAdress                 | Appointment time and location | Price | Physican | Appointment cause





-- 1NF : 
-- ID | Patient | Address | Postal Code | City  | VisitDate | VisitPlace (Room) | Price | Physician | VisitType | VisitPurpose





-- 2NF : 

-- table patient
-- PatientID | Name | Address | Postal Code | City |
-- table visit
-- VisitID | FK PatientID |  VisitDate | VisitPlace (Room) | Price | Doctor | VisitType | VisitPurpose


-- 3NF:
-- PostalCode -> City
--  Doctor -> Room (if every doctor has its own room)
-- visit purpose -> visit type




