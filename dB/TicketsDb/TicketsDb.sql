
-- CREATE DATABASE TicketsDb

-- USE TicketsDb

-- Tablas
-- Usuarios, Categorias, Estados,  Tickets, Comentarios


-- CREATE TABLE Usuarios(
--     id INT PRIMARY KEY AUTO_INCREMENT ,
--     nombre VARCHAR(100) NOT NULL,
--     email VARCHAR(100) NOT NULL UNIQUE,
--     area VARCHAR(100)
-- )

-- CREATE TABLE Categorias(
--     id INT PRIMARY KEY AUTO_INCREMENT,
--     nombre VARCHAR(100) NOT NULL
-- )

-- CREATE TABLE Estados(
--     id INT PRIMARY KEY AUTO_INCREMENT,
--     nombre VARCHAR(50) NOT NULL
-- )

-- CREATE TABLE Tickets(
--     id INT PRIMARY KEY AUTO_INCREMENT,
--     titulo VARCHAR(100) NOT NULL,
--     descripcion TEXT,
--     usuario_id  INT NOT NULL,
--     categoria_id INT NOT NULL,
--     estado_id INT NOT NULL,
--     fecha_creacion DATETIME DEFAULT CURRENT_TIMESTAMP,
--     FOREIGN KEY (usuario_id) REFERENCES Usuarios(id),
--     FOREIGN KEY (categoria_id) REFERENCES Categorias(id),
--     FOREIGN KEY (estado_id) REFERENCES Estados(id)
-- )

CREATE TABLE Comentarios(
    
)

