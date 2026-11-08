
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE ComentarioRepository_Update(
    IN p_Id INT,
    IN p_Texto VARCHAR(100)
)
BEGIN
    UPDATE comentarios 
    SET texto = p_Texto 
    WHERE id = p_Id;
END $$

DELIMITER ;

