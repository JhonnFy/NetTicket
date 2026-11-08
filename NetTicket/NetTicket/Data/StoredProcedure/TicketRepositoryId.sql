CREATE PROCEDURE TicketRepositoryId(IN i INT)
SELECT Id, Titulo, Descripcion, usuario_id AS UsuarioId, categoria_id AS CategoriaId, estado_id AS EstadoId, fecha_creacion AS FechaCreacion FROM  tickets
WHERE Id = i;

CALL TicketRepositoryId(1);