
# Sistema de Gestión de Tickets

Sistema completo de gestión de tickets de soporte IT, desarrollado con **Arquitectura Por Capas** integrado con una base de datos 
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


## Repositorios (Data Layer) — CRUD completo

Cada repositorio implementa el patrón CRUD completo usando Stored Procedures en MySQL, con tests automáticos.

### Métodos implementados por repositorio

| Método | Operación | Retorna | SP usado |
|---|---|---|---|
| `ObtenerTodos()` | SELECT todos | `List<T>` | `{Entidad}Repository` |
| `ObtenerPorId(int id)` | SELECT por id | `T?` (o `null`) | `{Entidad}RepositoryId` |
| `Create(...)` | INSERT | `T?` (con id) | `{Entidad}Repository_Create` |
| `Update(int id, ...)` | UPDATE | `bool` | `{Entidad}Repository_Update` |
| `Delete(int id)` | DELETE | `bool` | `{Entidad}Repository_Delete` |

### Repositorios implementados

- ✅ `CategoriaRepository`
- ✅ `EstadoRepository`
- ✅ `UsuarioRepository`
- ✅ `ComentarioRepository`
- ✅ `TicketRepository`

### Patrón de conexión

Todos los repositorios reciben `Conexion` por constructor (inyección de dependencias manual):

```csharp
private readonly Conexion _conexion;

public XRepository(Conexion conexion)
{
    _conexion = conexion;
}

// Dentro de cada método:
using var cn = _conexion.ObtenerConexion();
cn.Open();
```

### Tests

Cada repositorio tiene tests con MSTest que prueban contra la DB real:

- `TestObtenerTodos` — verifica que trae datos
- `TestObtenerPorId` — verifica que trae uno o null
- `TestCreate` — verifica INSERT + id generado
- `TestUpdate` — verifica UPDATE + lectura posterior
- `TestDelete` — verifica DELETE + ausencia posterior

---

## Lecciones aprendidas durante el desarrollo

### Stored Procedures en Workbench

- **`DELIMITER $$` falla en el editor de Workbench** (error 1064). Solución: usar la interfaz gráfica (Stored Procedures → Create) o ejecutar el script con `mysql.exe` desde CMD.
- **El `DELIMITER` final debe ser `DELIMITER ;`**, no `$$`.

### Parámetros del SP

- **Nunca nombrar un parámetro igual que una columna.** En MySQL (Windows, case-insensitive), `WHERE id = Id` compara la columna consigo misma → actualiza/borra TODAS las filas.
- **Usar prefijo `p_`:** `p_Id`, `p_Nombre`, `p_Texto`.

### INSERT + id generado

- **`cmd.LastInsertedId` no funciona con SPs** (bug conocido de `MySqlConnector`).
- **Solución:** el SP hace `INSERT` + `SELECT LAST_INSERT_ID() AS id_insertado`, y en C# se usa `ExecuteScalar()`.

### Ejecución según operación

| Operación | Método | Devuelve |
|---|---|---|
| SELECT (varias filas) | `ExecuteReader()` | `MySqlDataReader` |
| SELECT (un valor) | `ExecuteScalar()` | `object` (primer valor) |
| INSERT / UPDATE / DELETE | `ExecuteNonQuery()` | `int` (filas afectadas) |

### DELETE y FKs

- **`DELETE FROM tabla WHERE id = X` borra la FILA completa**, no columnas.
- **Falla si otra tabla referencia esa fila por FK.**
- **`comentarios` es la única tabla "hoja"** (nadie la referencia) → su DELETE siempre funciona.
- **Los ids borrados no se reutilizan** (`AUTO_INCREMENT` sigue avanzando).

### Tests

- **No usar `try/catch` en tests** → si el `Assert` falla, el `catch` lo oculta y el test "pasa" falsamente.
- **`Console.WriteLine` en MSTest** aparece en "Standard Output" del resultado.
- **`Assert.AreEqual(esperado, real)`** compara; no imprime.
