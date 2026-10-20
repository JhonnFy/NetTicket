 
--  USE ticketsdb

-- 1. Liste cuántos tickets hay por cada estado. Muestre el nombre del estado y el total.
SELECT t.id, t.titulo, u.nombre AS Usuario, e.nombre AS Estado FROM tickets t
INNER JOIN usuarios u ON t.usuario_id = u.id
INNER JOIN estados e ON t.estado_id = e.id;

-- Liste cuántos tickets ha creado cada usuario Muestre el nombre del usuario y el total
SELECT 
    u.nombre, COUNT(*) AS Casos
    FROM tickets t
INNER JOIN usuarios u ON t.usuario_id = u.id
GROUP BY (u.nombre);

-- Liste los usuarios que NO han creado ningún ticket
SELECT 
    u.nombre
    FROM tickets t
RIGHT JOIN usuarios u ON t.usuario_id = u.id
WHERE t.id IS NULL

-- Liste los tickets que están en estado 'Abierto', mostrando el título y el nombre del estado.

SELECT 
    T.titulo, E.nombre  
     FROM tickets T
INNER JOIN estados E ON T.estado_id = E.id
WHERE E.nombre = 'Abierto';

-- Los 3 tickets más recientes
SELECT 
        t.id, t.titulo, t.fecha_creacion
    FROM tickets t
ORDER BY fecha_creacion DESC, t.id DESC
LIMIT 3;

--  Título del ticket, el nombre del usuario, el nombre de la categoría y el nombre del estado, de todos los tickets.

SELECT 
       t.titulo, u.nombre AS Usuario, c.nombre  AS Categoria, e.nombre AS Estado
    FROM tickets t
INNER JOIN usuarios u ON t.usuario_id = u.id
INNER JOIN categorias c ON t.categoria_id = c.id
INNER JOIN estados e ON t.estado_id = e.id
ORDER BY t.id ASC

