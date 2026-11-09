
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE EstadoRepository_Update(
    IN p_Id INT,
    IN p_Nombre VARCHAR(100)
)
BEGIN
    UPDATE estados  SET nombre = p_Nombre
    WHERE Id = p_Id;
END $$

DELIMITER $$