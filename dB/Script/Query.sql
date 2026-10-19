 
--  USE ticketsdb


-- Listar todos los tickets con el nombre del usuario y el estado:
SELECT t.id, t.titulo, u.nombre AS Usuario, e.nombre AS Estado FROM tickets t
INNER JOIN usuarios u ON t.usuario_id = u.id
INNER JOIN estados e ON t.estado_id = e.id


-- Contar cuántos tickets hay por estado:

