

CREATE PROCEDURE EstadosRepository()
SELECT Id, Nombre FROM estados;

CALL EstadosRepository;