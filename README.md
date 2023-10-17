# notiApp
# Creación de Proyecto
Primero que todo creamos la carpeta o repositorio en donde queremos nuestro proyecto;
Luego comensamos creando los "classLib", es decir las clases pertinentes en nuestro proyecto que son:
## Creación de ClassLib
```
dotnet new classLib -o Core
dotnet new classLib -o Infrastructure
```
Sin embargo, nos falta crear lo más importante y es nuestra webApi:
```
    dotnet new webapi -o Api
```
