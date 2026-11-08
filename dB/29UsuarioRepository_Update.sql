
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE UsuarioRepository_Update(
    IN p_Id Int,
    IN p_Nombre VARCHAR(100),
    IN p_Email VARCHAR(100),
    IN p_Area VARCHAR(100)
)
BEGIN
    UPDATE usuarios 
    SET 
        nombre = p_Nombre,
        email = p_Email, 
        area = p_Area
    WHERE id = p_Id;
END $$

DELIMITER ;


