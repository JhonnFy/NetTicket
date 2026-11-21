
USE ticketsdbqa;

DELIMITER $$

CREATE PROCEDURE CountAllEstados(
)
BEGIN
    SELECT COUNT(*) FROM estados;
END $$

DELIMITER $$

