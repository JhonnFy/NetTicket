
USE ticketsdb;

CREATE PROCEDURE EstadosRepositoryId(IN i INT)
SELECT Id, Nombre FROM estados
WHERE id = i;

CALL EstadosRepositoryId(1);