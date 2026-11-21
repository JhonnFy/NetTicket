
USE ticketsdbqa;

INSERT INTO usuarios (nombre, email, area) values ('TEST Gabriel Garcia Marquez','test.gabriel@mail.com','Novela');
INSERT INTO usuarios (nombre, email, area) values ('TEST Isabel Allende','test.isabel@mail.com','Novela');
INSERT INTO usuarios (nombre, email, area) values ('TEST Jorge Luis Borges','test.borges@mail.com','Cuento');
INSERT INTO usuarios (nombre, email, area) values ('TEST Julio Cortazar','test.cortazar@mail.com','Cuento');
INSERT INTO usuarios (nombre, email, area) values ('TEST Mario Vargas Llosa','test.vargas@mail.com','Novela');
INSERT INTO usuarios (nombre, email, area) values ('TEST Pablo Neruda','test.neruda@mail.com','Poesia');
INSERT INTO usuarios (nombre, email, area) values ('TEST Octavio Paz','test.paz@mail.com','Poesia');
INSERT INTO usuarios (nombre, email, area) values ('TEST Federico Garcia Lorca','test.lorca@mail.com','Teatro');
INSERT INTO usuarios (nombre, email, area) values ('TEST Sor Juana Ines de la Cruz','test.juana@mail.com','Poesia');
INSERT INTO usuarios (nombre, email, area) values ('TEST Ruben Dario','test.dario@mail.com','Poesia');

INSERT INTO categorias (nombre) values ('TEST Novela');
INSERT INTO categorias (nombre) values ('TEST Poesia');
INSERT INTO categorias (nombre) values ('TEST Ensayo');
INSERT INTO categorias (nombre) values ('TEST Cuento');
INSERT INTO categorias (nombre) values ('TEST Teatro');

INSERT INTO estados (nombre) values ('TEST Pendiente');
INSERT INTO estados (nombre) values ('TEST En Revision');
INSERT INTO estados (nombre) values ('TEST Aprobado');
INSERT INTO estados (nombre) values ('TEST Rechazado');
INSERT INTO estados (nombre) values ('TEST Publicado');


INSERT INTO tickets (titulo,descripcion,usuario_id,categoria_id,estado_id) values ('TEST Prestamo de novela','El usuario solicita prestamo de novela por una semana',1,1,1);
INSERT INTO tickets (titulo,descripcion,usuario_id,categoria_id,estado_id) values ('TEST Devolucion de poesia','El usuario devuelve libro de poesia en buen estado',2,2,2);
INSERT INTO tickets (titulo,descripcion,usuario_id,categoria_id,estado_id) values ('TEST Reserva de ensayo','El usuario reserva ensayo para consulta en sala',3,3,3);
INSERT INTO tickets (titulo,descripcion,usuario_id,categoria_id,estado_id) values ('TEST Libro danado','El usuario reporta libro con paginas rotas',1,4,1);
INSERT INTO tickets (titulo,descripcion,usuario_id,categoria_id,estado_id) values ('TEST Solicitud de nuevo libro','El usuario solicita la compra de un nuevo titulo',2,5,2);


INSERT INTO comentarios (ticket_id,usuario_id,texto) values (1,1,'TEST Se aprobo el prestamo de la novela');
INSERT INTO comentarios (ticket_id,usuario_id,texto) values (1,2,'TEST El libro fue devuelto en buen estado');
INSERT INTO comentarios (ticket_id,usuario_id,texto) values (2,3,'TEST La reserva del ensayo quedo confirmada');
INSERT INTO comentarios (ticket_id,usuario_id,texto) values (3,1,'TEST El libro danado fue reemplazado');

