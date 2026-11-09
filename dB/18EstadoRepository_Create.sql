
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE EstadoRepository_Create (IN Nombre Varchar(100))
BEGIN
    INSERT INTO estados (nombre) VALUES (Nombre);
    SELECT LAST_INSERT_ID() AS id, Nombre AS nombre;
END $$

DELIMITER $$


