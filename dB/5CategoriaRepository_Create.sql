DELIMITER $$

CREATE PROCEDURE CategoriaRepository_Create(IN Nombre VARCHAR(100))
BEGIN
    INSERT INTO categorias (nombre) VALUES (Nombre);
    SELECT LAST_INSERT_ID() AS id, Nombre AS nombre;
END $$

DELIMITER ;



Esos sp se ejecutan con el rayo