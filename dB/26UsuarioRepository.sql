
CREATE PROCEDURE UsuarioRepository()
SELECT Id, Nombre, Email, Area FROM usuarios;


CALL UsuarioRepository;
