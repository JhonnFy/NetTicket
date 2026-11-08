
USE ticketsdb;

DELIMITER $$

CREATE PROCEDURE CountAllTickets(
)
BEGIN
    SELECT COUNT(*) FROM tickets;
END;

DELIMITER $$

