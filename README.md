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

# Para mvc Razor

dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
 

 # Para la autenticación
 https://ajaxhispano.com/ask/autenticacion-personalizada-en-asp-net-core-94222/

 Falta evaluar la autorización pero de momento ya funciona


 Se agrega el servico de códigos postales


 # NewtonSoft

 dotnet add package Newtonsoft.Json --version 13.0.1

 # Base de datos

 dotnet ef database drop

dotnet ef migrations remove

Application startup exception: System.IO.IOException: The configured user limit (128) on the number of inotify instances has been reached.

echo fs.inotify.max_user_instances=524288 | sudo tee -a /etc/sysctl.conf && sudo sysctl -p

# Worker service

https://medium.com/@daniel.sagita/backgroundservice-for-a-long-running-work-3debe8f8d25b

https://stackoverflow.com/questions/6481304/how-to-use-a-backgroundworker

Se utiliza un backgroung worker por que es mas facil de administrar ya que puedes hacer que no se encimen los hilos con isBusy en caso que se requiera que se haga de uno en uno

# How should I inject a DbContext instance into an IHostedService?
https://stackoverflow.com/questions/48368634/how-should-i-inject-a-dbcontext-instance-into-an-ihostedservice