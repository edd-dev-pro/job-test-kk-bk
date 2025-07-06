# VentasApi

Una API REST protegida con JWT para gestionar ventas.

## 📦 Estructura del proyecto

VentasKK/
├─ VentasApi/
│ ├─ Controllers/
│ ├─ Data/
│ ├─ Dtos/
│ ├─ Migrations/
│ ├─ Models/
│ ├─ Properties/
│ ├─ Services/
│ ├─ appsettings.json
│ ├─ Program.cs
│ └─ VentasApi.csproj
└─ VentasSolution.sln

markdown
Copy
Edit

## 🚀 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/)
- SQL Server (LocalDB o SQLEXPRESS)
- Git

## 🔧 Configuración

1. Clona este repositorio y sitúate en la carpeta raíz:

   ```bash
   git clone <tu-repo-url>
   cd VentasKK
   Restaura paquetes y genera la base de datos a partir de las migraciones:
   ```

bash
Copy
Edit
dotnet restore
dotnet ef database update
(Opcional) Para generar un script SQL completo:

bash
Copy
Edit
dotnet ef migrations script -o init.sql
▶️ Cómo ejecutar
Desde la raíz del proyecto:

bash
Copy
Edit
cd VentasApi
dotnet run
Por defecto el servidor escuchará en:

HTTP: http://localhost:5000

HTTPS: https://localhost:5001

📑 Endpoints
Autenticación
POST /api/Auth/login
Body JSON:

json
Copy
Edit
{
"username": "admin",
"password": "1234"
}
Devuelve un token JWT en { "token": "..." }.

Ventas (sin JWT)
GET /api/Ventas
Lista todas las ventas.

Ventas (con JWT)
POST /api/Ventas
Header: Authorization: Bearer <token>
Body JSON:

json
Copy
Edit
{
"concepto": "Descripción del producto",
"monto": 123.45
}
Crea una nueva venta.

DELETE /api/Ventas/all
Header: Authorization: Bearer <token>

Elimina todas las ventas.

🔒 Seguridad
Todos los endpoints POST y DELETE están protegidos por JWT.

La clave y emisores se configuran en appsettings.json bajo el nodo Jwt.

🧪 Pruebas manuales
Swagger UI: https://localhost:5001/swagger

Postman: crea un environment con la variable base_url = http://localhost:5000.

📂 Archivos importantes
appsettings.json — Cadena de conexión y JWT.

Program.cs — Configuración de servicios, EF Core, JWT y Kestrel.

init.sql — Script generado de migración (opcional).

VentasSolution.sln — Solution file de Visual Studio.
