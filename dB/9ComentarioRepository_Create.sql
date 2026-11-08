
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE ComentarioRepository_Create(
        IN TicketId INT,
        IN UsuarioId INT,
        IN Texto VARCHAR(100)
    )
BEGIN
        INSERT INTO comentarios (ticket_id,usuario_id,texto)
        VALUES (TicketId,UsuarioId,Texto);
        SELECT LAST_INSERT_ID() AS id_insertado;
END $$

DELIMITER ;


