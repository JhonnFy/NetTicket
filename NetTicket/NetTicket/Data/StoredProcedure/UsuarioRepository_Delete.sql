
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE UsuarioRepository_Delete(
    IN p_Id INT
)
BEGIN
    DELETE FROM usuarios 
    WHERE id = p_Id;
END $$


DELIMITER ;
