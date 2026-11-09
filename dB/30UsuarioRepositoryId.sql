
USE ticketsdb;

CREATE PROCEDURE UsuarioRepositoryId(IN i INT)
SELECT Id, Nombre, Email, Area FROM usuarios
WHERE Id = i;

CALL UsuarioRepositoryId(1);
