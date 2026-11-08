

USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE UsuarioRepository_Create(
    IN Nombre VARCHAR(100),
    IN Email VARCHAR(100),
    IN Area VARCHAR(100)
)
BEGIN
    INSERT INTO usuarios (nombre, email, area) 
    VALUES (Nombre,Email,Area);
    SELECT LAST_INSERT_ID() AS id;
END $$

DELIMITER ;

