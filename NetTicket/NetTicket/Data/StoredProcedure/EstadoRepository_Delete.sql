
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE EstadoRepository_Delete(
    IN p_Id INT
)
BEGIN
    DELETE FROM estados 
    WHERE id = p_Id;
END ;

DELIMITER ;
