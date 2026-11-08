
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE TicketRepository_Update(
    IN p_Id INT,
    IN p_Titulo VARCHAR(100),
    IN p_Descripcion VARCHAR(100)
)
BEGIN
    UPDATE tickets 
    SET titulo = p_Titulo, descripcion = p_Descripcion
    WHERE id = p_Id;
END $$

DELIMITER $$


