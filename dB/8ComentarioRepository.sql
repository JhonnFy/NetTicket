
CREATE PROCEDURE ComentarioRepository()
SELECT Id, ticket_id AS TicketId, usuario_id AS UsuarioId, texto, fecha FROM comentarios;


CALL ComentarioRepository()