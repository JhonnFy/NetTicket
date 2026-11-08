
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE CategoriaRepository_Delete(
    IN p_Id INT
)
BEGIN
    DELETE FROM categorias
    WHERE id = p_Id;
END $$


DELIMITER ;

