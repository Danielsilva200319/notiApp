# notiApp
# Creación de Proyecto Terminal
Primero que todo creamos la carpeta o repositorio en donde queremos nuestro proyecto, Luego le añadimos la solución al proyecto:

```
1. cd Proyecto
2. dotnet new sln
```
Luego comensamos creando los "classLib", es decir las clases pertinentes en nuestro proyecto que son:
## Creación de ClassLib
```
dotnet new classlib -o Core
dotnet new classlib -o Infrastructure
```
Sin embargo, nos falta crear lo más importante y es nuestra webApi:
```
dotnet new webapi -o Api
```
Le damos soluciones a las clases y al api:
```
dotnet sln add Api
dotnet sln add Core
dotnet sln add Infrastructure
```
Después hacemos las referencias en nuestro proyecto
```
dotnet add reference ..\Infrastructure\ = Esta referencia va en el folder de Api
dotnet add reference ..\Core\ = Esta va en el folder Infrastructure.
```
Luego, instalamos todos los paquetes necesarios para nuestro proyecto, 
tener en cuenta que algunos van en la Api y otros van en Infrastructure.

# VS Code
Asi tiene que estar en el VSCode cuando queremos ver nuestro proyecto

![Alt text](<Captura de pantalla 2023-10-17 124029.png>)

Nos metemos en Core y creamos una carpeta llamada "Entities" y le añadimos las clases que nos dan en el analisis de datos

![Alt text](<Captura de pantalla 2023-10-17 125429.png>)

En la carpeta Entities creamos una clase llamada "BaseEntity" para colocar los codigos que se ejecutan en todas las clases, por ejemplo, el Id

![Alt text](<Captura de pantalla 2023-10-17 125633.png>)

Después comenzamos añadiendo las informaciones necesarias para las clases, como el nombre, apellidos, email, etc.

![Alt text](image.png)

Luego de que ya hicimos ese procedimiento, creamos uan carpeta
llamada "Data" en donde le añadimos una clase llamada
"NotiAppContext", en donde colocamos todos los DbSet y proporcionamos un código que se utiliza para configuar el modelo de datos de la base de datos; se asegura de que las configuraciones definidas en clases específicas sean aplicadas a las entidades y relaciones en la base de datos. Esto es útil para mantener un código limpio y organizado, especialmente en aplicaciones con modelos de datos complejos.

![Alt text](<Captura de pantalla 2023-10-17 155638.jpg>)

Después de ya tener los DbSet, creamos una carpeta dentro de la carpeta Data llamada "Configration", en donde se pondra todos las clases que hicimos de Entities, pero con un adicional que es configuration, ahí, como su nombre lo dice vamos a configurar nuestras clases para saber que es lo que me va a mostrar la base de datos.

![Alt text](<Captura de pantalla 2023-10-17 160128.jpg>)

Ya que tenemos las configuraciones, lo coloamos en la base de datos "MySql" donde colocamos un código para poder subirlo desde la terminal. Eso lo creamos en la carpeta API, en la clase "Program.cs".

![Alt text](<Captura de pantalla 2023-10-17 161127.jpg>)

Luego creamos la union en los json para que me salga con el nombre que queremos y poder que la ejecución sea correcta.

![Alt text](<Captura de pantalla 2023-10-17 161354.jpg>)
También se coloca en el otro JSON del Api,
podemos Hacer una migración si queremos.

# Migracion y subir al MySql
Para hacer una migration y actualizar la base de datos tenemos que añadir dos códigos:

MIGRACIÓN:
```
dotnet ef migrations add InitialCreated --project \Infrastructure\ --startup-project \API\ --output-dir ./Data/Migrations
```
UPDATE:
```
dotnet ef database update --project \Infrastructure\ --startup-project \API\ 
```

Creamos una carpeta llamda "Interfaces" en Core, después creamos una interface en esa carpeta llamada "IGenericRepository"

![Alt text](image-1.png)

Después en Infrastructure creamos una carpeta llamada "Repositories" y colocamos una clase llamada "GenericRepository" en donde colocamos un código.

![Alt text](image-2.png)

luego comenzamos a crear las interfaces que nos faltan, es decir las interfaces de todas las entities, y aparte de las interfaces toca añadirle una clase en Repositories a cada una.

![Alt text](image-3.png)

colocarlo en todas las interfaces
![Alt text](image-4.png)

colocarlo en todas los repository   
![Alt text](image-5.png)