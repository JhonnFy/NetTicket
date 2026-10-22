
# Sistema de Gestión de Tickets

Sistema completo de gestión de tickets de soporte IT, desarrollado con arquitectura por capas e integrado con una base de datos MySQL.
**MySQL** y una aplicación de consola desarrollada en **.NET (C#)** que consume los datos.

El sistema permite gestionar el ciclo completo de un ticket: registro de usuarios,
creación de solicitudes, clasificación por categoría y estado, y seguimiento mediante
comentarios.

---

## Funcionalidades

### Gestión de tickets
- Registro y gestión de usuarios (nombre, email, área)
- Creación de tickets con título, descripción, categoría y estado
- Clasificación por categorías (Red, Hardware, Software)
- Seguimiento de estados (Abierto, En Proceso, Cerrado)
- Historial de comentarios por ticket

### Consultas y reportes
- Tickets por estado
- Tickets por usuario
- Usuarios sin tickets asignados
- Tickets filtrados por estado
- Tickets más recientes
- Detalle completo de tickets (usuario + categoría + estado)

### Desde la aplicación .NET (cliente de consola)
- Listar todos los tickets con su usuario, categoría y estado
- Crear nuevos tickets desde la aplicación
- Cambiar el estado de un ticket
- Agregar comentarios a un ticket
- Ver el detalle de un ticket con todos sus comentarios

---

## Arquitectura

El proyecto está separado en dos capas independientes:

### 1. Base de datos (MySQL)
- 5 tablas relacionadas con claves foráneas
- Modelo relacional con integridad referencial
- Scripts versionados para crear y poblar la base
- Dump completo para restaurar en cualquier máquina

### 2. Aplicación .NET (C#)
Aplicación de consola que se conecta a MySQL mediante `MySqlConnector` y expone
las operaciones de gestión de tickets a través de un menú interactivo.

Estructura del proyecto:

```
SistemaTickets/
├── Program.cs                  → Menú principal y flujo de la aplicación
├── Models/                     → Clases que representan las tablas (POCO)
│   ├── Ticket.cs
│   ├── Usuario.cs
│   ├── Categoria.cs
│   ├── Estado.cs
│   └── Comentario.cs
├── Data/
│   ├── Conexion.cs             → Cadena de conexión a MySQL
│   └── TicketRepository.cs     → Métodos CRUD contra la base de datos
└── SistemaTickets.csproj
```

Separación de responsabilidades:
- **Models** → estructura de los datos
- **Data** → acceso a la base de datos (consultas SQL parametrizadas)
- **Program** → interacción con el usuario (menú de consola)

---

## Tecnologías

| Capa | Tecnología |
|---|---|
| Base de datos | MySQL 8.0 |
| Backend | C# / .NET 9 |
| Conector | MySqlConnector (NuGet) |
| Administración de BD | MySQL Workbench |
| Control de versiones | Git / GitHub |

---

## Modelo de datos

### Tablas

| Tabla | Descripción |
|---|---|
| `Usuarios` | Personas que crean tickets y comentarios |
| `Categorias` | Tipo de ticket (Red, Hardware, Software) |
| `Estados` | Estado actual del ticket (Abierto, En Proceso, Cerrado) |
| `Tickets` | Solicitudes de soporte |
| `Comentarios` | Seguimiento y respuestas de cada ticket |

### Relaciones

- Un **usuario** puede crear muchos **tickets** (1:N)
- Un **ticket** pertenece a una **categoría** (N:1)
- Un **ticket** tiene un **estado** (N:1)
- Un **ticket** puede tener muchos **comentarios** (1:N)
- Un **comentario** pertenece a un **usuario** (N:1)

---

## Estructura del repositorio

```
SistemaTickets/
├── README.md
├── db/
│   ├── 01_create_database.sql
│   ├── 02_create_tables.sql
│   ├── 03_insert_data.sql
│   ├── 04_consultas.sql
│   ├── TicketsDb_dump.sql
│   └── diagrama.png
└── src/
    └── SistemaTickets/
        ├── Program.cs
        ├── Models/
        ├── Data/
        └── SistemaTickets.csproj
```
---

## Reglas de arquitectura por capas

| Regla | Cómo se garantiza |
|---|---|
| `Program` solo llama a `Services` | Disciplina: nunca `new TicketRepository()` en `Program` |
| `Services` llama a `Data` | El servicio tiene el repositorio inyectado o lo instancia |
| Nadie más toca `Data` | Si otra capa lo toca, se rompe el flujo |

---
