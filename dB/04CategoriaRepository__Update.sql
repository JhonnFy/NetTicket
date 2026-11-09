
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE CategoriaRepository_Update(
    IN p_Id INT,
    IN p_Nombre VARCHAR(100)
)
BEGIN
    UPDATE categorias SET nombre = p_Nombre
    WHERE id = p_Id;
END $$

DELIMITER $$
