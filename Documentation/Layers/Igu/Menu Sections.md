# NetTicket — Documentación

## Tablas y relaciones

### Tablas

| Tabla | FK | Operaciones disponibles |
|---|---|---|
| `Categorias` | — | Create, Read, ReadId, Update, Delete |
| `Estados` | — | Create, Read, ReadId, Update, Delete |
| `Usuarios` | — | Create, Read, ReadId, Update, Delete |
| `Tickets` | `usuario_id`, `categoria_id`, `estado_id` | Create, Read, ReadId, Update |
| `Comentarios` | `ticket_id`, `usuario_id` | Create, Read, ReadId, Update |

### Relaciones

- `tickets.usuario_id` → `usuarios.id`
- `tickets.categoria_id` → `categorias.id`
- `tickets.estado_id` → `estados.id`
- `comentarios.ticket_id` → `tickets.id`
- `comentarios.usuario_id` → `usuarios.id`

**Nota:** `Tickets` y `Comentarios` no tienen `Delete` porque sus FK lo bloquean (requieren definir política de borrado).

---

## Menú de consola

### Menú principal

```
Options Menu TicketsDb

Select A Table To Customize:
1 → Categorias
2 → Comentarios
3 → Estados
4 → Tickets
5 → Usuarios
6 → Exit Menu

‼Enter Your Choice‼ →
```

### Submenú: Categorías

```
Welcome To Categorias:
1 → Create
2 → Read
3 → ReadId
4 → Update
5 → Delete
6 → Return To Main Menu

‼Enter Your Choice‼ →
```

### Submenú: Comentarios

```
Welcome To Comentarios:
1 → Create
2 → Read
3 → ReadId
4 → Update
5 → Return To Main Menu

‼Enter Your Choice‼ →
```

### Submenú: Estados

```
Welcome To Estados:
1 → Create
2 → Read
3 → ReadId
4 → Update
5 → Delete
6 → Return To Main Menu

‼Enter Your Choice‼ →
```

### Submenú: Tickets

```
Welcome To Tickets:
1 → Create
2 → Read
3 → ReadId
4 → Update
5 → Return To Main Menu

‼Enter Your Choice‼ →
```

### Submenú: Usuarios

```
Welcome To Usuarios:
1 → Create
2 → Read
3 → ReadId
4 → Update
5 → Delete
6 → Return To Main Menu

‼Enter Your Choice‼ →
```
