# Sistema de Gestión de Tickets

Aplicación desarrollada en **.NET (C#)** con una base de datos **MySQL**, capaz de 
gestionar el ciclo completo de tickets de soporte IT: registro de usuarios, creación 
de solicitudes, asignación de categorías y estados, y seguimiento mediante comentarios.

## Funcionalidades

- Registro y gestión de usuarios (nombre, email, área)
- Creación de tickets con título, descripción, categoría y estado
- Clasificación por categorías (Red, Hardware, Software)
- Seguimiento de estados (Abierto, En Proceso, Cerrado)
- Historial de comentarios por ticket
- Consultas y reportes: tickets por estado, tickets por usuario, tickets sin asignar

## Arquitectura

- **Base de datos:** MySQL
- **Backend:** .NET (C#) — conexión vía `MySqlConnector`
- **Administración de datos:** MySQL Workbench

## Tecnologías

- C# / .NET
- MySQL
- MySqlConnector (NuGet)
- Git / GitHub