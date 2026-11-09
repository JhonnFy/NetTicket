
USE ticketsdb;

CREATE PROCEDURE ComentariosRepositoryId(IN i INT)
SELECT Id, ticket_id AS TicketId, usuario_id AS UsuarioId, texto, fecha FROM comentarios
WHERE Id = i;


CALL ComentariosRepositoryId(1);