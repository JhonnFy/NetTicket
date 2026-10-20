 
--  USE ticketsdb


--  1. Liste cuántos tickets hay por cada estado. Muestre el nombre del estado y el total.
SELECT t.id, t.titulo, u.nombre AS Usuario, e.nombre AS Estado FROM tickets t
INNER JOIN usuarios u ON t.usuario_id = u.id
INNER JOIN estados e ON t.estado_id = e.id;

--  Liste cuántos tickets ha creado cada usuario Muestre el nombre del usuario y el total
SELECT 
    u.nombre, COUNT(*)
    FROM tickets t
INNER JOIN usuarios u ON t.usuario_id = u.id
GROUP BY (u.nombre);

