
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE CountAllUsuarios(
)
BEGIN
    SELECT COUNT(*) FROM usuarios;
END $$

DELIMITER $$