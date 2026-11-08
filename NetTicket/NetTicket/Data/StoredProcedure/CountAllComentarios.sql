

USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE CountAllComentarios(
)
BEGIN
    SELECT COUNT(*) FROM comentarios;
END;

DELIMITER $$
