
USE ticketsdbqa;

CREATE PROCEDURE TicketRepository()
SELECT 
    t.id, t.titulo, t.descripcion, 
    t.usuario_id, t.categoria_id, t.estado_id, 
    t.fecha_creacion
FROM tickets t
INNER JOIN usuarios u ON t.usuario_id = u.id
INNER JOIN categorias c ON t.categoria_id = c.id
INNER JOIN estados e ON t.estado_id = e.id;

CALL TicketRepository();

