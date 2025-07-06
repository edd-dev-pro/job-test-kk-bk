# VentasAPI

API REST simple en .NET 8 para gestionar ventas.

## Cómo ejecutar

1. Clona este repositorio:
   ```bash
   git clone <URL_DEL_REPO>
   cd VentasKK/VentasApi
   ```
2. Configura la conexión en appsettings.json (cadena Default).

3. Aplica migraciones y crea la base de datos:
   ```bash
   dotnet ef database update
   ```
4. Arranca la APIArranca la API:
   ```bash
   dotnet run
   ```
   - HTTP: http://localhost:5000
   - HTTPS: https://localhost:5001

## Endpoints

- POST `/api/Auth/login` Inicia sesión y devuelve JWT.

- GET `/api/Ventas Lista` todas las ventas (público).

- POST `/api/Ventas Crea` venta nueva (requiere JWT).

- DELETE `/api/Ventas/all` Elimina todas las ventas (requiere JWT).
