# HelpDesk.Backend

En el RepositoryEf se conectara a una base de datos Mysql

dotnet add package Pomelo.EntityFrameworkCore.MySql

Se coloca en el AppDbContext la cadena de conexión provisionalmente, esto solo será para hacer la migración.

 "Server=localhost; Port=13306; Database=NameDataBase; Uid=root; Pwd=;";

 options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));


 dotnet add package Microsoft.EntityFrameworkCore.Design

 Finalmente generamos la migración

 dotnet ef migrations add InitialCreate

 Cargamos el script en la base de datos
 
 dotnet ef database update

 # Para borrar la base de datos
 dotnet ef database drop

 dotnet ef migrations remove

 