
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE TicketRepository_Create(
    IN Titulo VARCHAR(100),
    IN Descripcion VARCHAR(100),
    IN UsuarioId INT,
    IN CategoriaId INT, 
    IN EstadoId INT
)
BEGIN  
    INSERT INTO tickets (titulo,descripcion,usuario_id,categoria_id,estado_id) 
    VALUES (Titulo,Descripcion,UsuarioId,CategoriaId,EstadoId);
    SELECT LAST_INSERT_ID() AS id_insertado; 
END $$

DELIMITER ;
