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
![image](https://drive.google.com/uc?export=view&id=1pst95gYdKZcRnal7iGLq47HFKBkr4lsm)