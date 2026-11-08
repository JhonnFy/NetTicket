
USE ticketsdb;

CREATE PROCEDURE TicketRepository()
SELECT 
       t.id, t.titulo, t.descripcion, u.nombre, c.nombre, e.nombre, t.fecha_creacion
    FROM tickets t
INNER JOIN usuarios u ON t.usuario_id = u.id
INNER JOIN categorias c ON  t.categoria_id = c.id
INNER JOIN estados e ON t.estado_id = e.id;


CALL TicketRepository();