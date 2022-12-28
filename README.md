# Installation

1. On any folder folder:

`git clone https://github.com/jmeza44/ProductsManagement.git`

2. Open on Visual Studio and modify the `appsettings.json` file (`secrets.json` if you prefer):

```json
"DefaultConnectionString": "Your_Connection_String"
```

3. Run the application (Automatic migrations)

# Products API - Code Challenge 🐱‍👤

Debes crear una aplicación en ASP.NET Web API (Una API REST, no se necesita crear el Front-End, solo el Back-End y las APIs) que nos permita registrar, modificar, eliminar y consultar productos, teniendo en cuenta las siguientes premisas:

* Debe poder buscar por el Identificador del producto y por la descripción del mismo (like o contains).
* Debe permitir actualizar un producto existente por medio de una llamada PUT, el body y el ID del producto en la URL.
* Atributos del Producto: Identificador único, Descripción, Tipo de Producto (Bienes, vehículos, terrenos, Apartamentos), Valor, Fecha Compra, Estado del Producto (Activo o Inactivo).
* En la API de consulta, se debe retornar una lista (arreglo tipo JSON) con los objetos productos y sus propiedades (Identificador único, Descripción, Tipo de Producto, Estado del Producto).
* La búsqueda por descripción del producto se debe realizar, utilizando una llamada GET y un QueryString con parámetros para la consulta (Como lo hace Google /search?q=ejemplo), debe permitir al usuario consultar todos los productos que contengan dentro de su descripción la palara ingresada en el filtro de búsqueda.

## Entregables

* Base de Datos, donde debe estar la entidad Producto; La entidad debe tener llaves primarias e índices. (Crear base de datos Local)
* Solución: APIs RESTs desarrollada en C# (ASP.Net Web API) testeadas con la herramienta Postman para la consulta, registro, eliminación y actualización de productos.
