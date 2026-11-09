INSERT INTO usuarios (nombre, email, area) values ('Juan Pérez','juan@mail.com','Sistemas');
INSERT INTO usuarios (nombre, email, area) values ('Ana Gómez','ana@mail.com','Contabilidad');
INSERT INTO usuarios (nombre, email, area) values ('Carlos Ruiz','carlos@mail.com','Recursos Humanos');

INSERT INTO categorias (nombre) values ('Red');
INSERT INTO categorias (nombre) values ('Hardware');
INSERT INTO categorias (nombre) values ('Software');

INSERT INTO estados  (nombre) values ('Abierto');
INSERT INTO estados  (nombre) values ('En Proceso');
INSERT INTO estados  (nombre) values ('Cerrado');

INSERT INTO tickets  (titulo,descripcion,usuario_id,categoria_id,estado_id) values ('No hay internet en piso 3','Los equipos no conectan a la red',1,1,1);
INSERT INTO tickets  (titulo,descripcion,usuario_id,categoria_id,estado_id) values ('Impresora no imprime','La impresora del área no responde',2,2,2);
INSERT INTO tickets  (titulo,descripcion,usuario_id,categoria_id,estado_id) values ('Error al abrir Excel','Excel se cierra al abrir archivos',3,3,3);
INSERT INTO tickets  (titulo,descripcion,usuario_id,categoria_id,estado_id) values ('Correo no sincroniza','Outlook no actualiza correos',1,3,1);

INSERT INTO comentarios (ticket_id,usuario_id,texto) values (1,1,'Revisé el cableado y está conectado');
INSERT INTO comentarios (ticket_id,usuario_id,texto) values (1,2,'Sigue sin funcionar en mi equipo');
INSERT INTO comentarios (ticket_id,usuario_id,texto) values (2,3,'Se reinició la impresora y ya imprime');
INSERT INTO comentarios (ticket_id,usuario_id,texto) values (3,1,'Se reinstaló Office y quedó solucionado');



