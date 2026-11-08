
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE CountAllCategorias(
)
BEGIN
    SELECT COUNT(*) FROM categorias;
END $$

DELIMITER $$
