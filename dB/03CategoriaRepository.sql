
USE ticketsdb;

CREATE PROCEDURE CategoriaRepository()
SELECT Id, Nombre FROM categorias;

CALL CategoriaRepository()