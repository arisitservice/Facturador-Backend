# Deploy en EC2 con Docker y PostgreSQL

## Requisitos previos
- Instancia EC2 con al menos 1GB de RAM (t3.micro es suficiente para PostgreSQL + API)
- Docker instalado en la EC2
- Código en un repositorio Git accesible desde la EC2

---

## 1. Clonar el repositorio en EC2

```bash
cd /var/www/back
git clone <url-del-repo> Facturador-Backend
cd Facturador-Backend
```

---

## 2. Crear el archivo `.env`

```bash
nano /var/www/back/Facturador-Backend/.env
```

Contenido:
```env
ConnectionStrings__Biller=Host=postgres;Port=5432;Database=Biller;Username=postgres;Password=YourStrongPassw0rd;SSL Mode=Disable
```

Proteger el archivo:
```bash
chmod 600 /var/www/back/Facturador-Backend/.env
```

> El host es `postgres` (nombre del contenedor), no `localhost`.

---

## 3. Crear la red Docker

```bash
docker network create facturador-net
```

---

## 4. Levantar PostgreSQL

```bash
docker run -d \
  --name postgres \
  -e "POSTGRES_PASSWORD=YourStrongPassw0rd" \
  -e "POSTGRES_DB=Biller" \
  -p 5432:5432 \
  postgres:16
```

Conectar a la red:
```bash
docker network connect facturador-net postgres
```

---

## 5. Buildar la imagen de la API

Desde la raíz del proyecto:
```bash
docker build -f Biller.Presentation.Api/Dockerfile -t facturador-api .
```

---

## 6. Correr la API

```bash
docker run -d \
  --name facturador-api \
  -p 8080:8080 \
  --env-file /var/www/back/Facturador-Backend/.env \
  --network facturador-net \
  facturador-api
```

---

## 7. Verificar que todo funciona

```bash
docker logs facturador-api
```

Buscar el mensaje:
```
Now listening on: http://[::]:8080
```

Probar un endpoint:
```bash
curl -v -X POST http://localhost:8080/api/v1/Receptores/Create \
  -H "Content-Type: application/json" \
  -d '{}'
```

Respuesta esperada: `HTTP/1.1 400 Bad Request` (validación corriendo = API operativa).

---

## Levantar en QA

Para que la API use `appsettings.QA.json` en vez de `appsettings.json`, agregá la variable `ASPNETCORE_ENVIRONMENT=QA` al `docker run`:

```bash
docker run -d \
  --name facturador-api \
  -p 8080:8080 \
  -e ASPNETCORE_ENVIRONMENT=QA \
  --env-file /var/www/back/Facturador-Backend/.env \
  --network facturador-net \
  facturador-api
```

> El `.env` sigue siendo necesario si tiene variables adicionales. La connection string de QA viene de `appsettings.QA.json` y apunta a `Host=postgres` (contenedor en la misma red).

---

## Actualizar el deploy (nuevas versiones)

```bash
cd /var/www/back/Facturador-Backend
git pull
docker build -f Biller.Presentation.Api/Dockerfile -t facturador-api .
docker stop facturador-api && docker rm facturador-api
docker run -d \
  --name facturador-api \
  -p 8080:8080 \
  --env-file /var/www/back/Facturador-Backend/.env \
  --network facturador-net \
  facturador-api
```

---

## 8. Abrir el puerto 8080 en AWS

Para acceder a la API desde fuera de la EC2:

1. Ve a **EC2 → Instances** → seleccioná tu instancia
2. Click en la pestaña **Security**
3. Click en el **Security Group** vinculado
4. **Inbound rules → Edit inbound rules**
5. **Add rule:**
   - Type: `Custom TCP`
   - Port: `8080`
   - Source: `0.0.0.0/0`
6. **Save rules**

---

## Notas

- El `.env` nunca se commitea al repo (está en `.gitignore`)
- Swagger solo está disponible en modo `Development`. En producción usar los endpoints directamente.
- El Security Group de EC2 debe tener el puerto `8080` abierto para acceso externo.
