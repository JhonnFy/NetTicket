
USE ticketsdb;

CREATE PROCEDURE CategoriaRepositoryId(IN i int )
SELECT id, nombre FROM categorias
WHERE id = i;

CALL CategoriaRepositoryId(1);
