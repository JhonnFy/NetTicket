

USE ticketsdb;

CREATE PROCEDURE ExisteEmail(
    IN p_Email VARCHAR(100)
)
SELECT COUNT(*) FROM usuarios
WHERE email = p_Email;

