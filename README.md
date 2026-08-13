PlanificaPro

PlanificaPro es un sistema de gestión de menús semanales creado para organizar comidas, ingredientes y productos de compra.

El proyecto fue desarrollado utilizando C#, ASP.NET Core, Blazor, Entity Framework Core y SQL Server.

Funcionalidades

El sistema permite:

- Crear, editar y eliminar menús semanales.
- Registrar comidas y relacionarlas con un menú semanal.
- Registrar ingredientes y relacionarlos con una comida.
- Crear y administrar una lista de compras.
- Marcar productos como comprados.
- Guardar la información en una base de datos.

Estructura del proyecto

El Backend está separado en diferentes capas:

- **MenuSemanal.Domain:** contiene las entidades principales del sistema.
- **MenuSemanal.Application:** contiene los servicios y la lógica de la aplicación.
- **MenuSemanal.Infrastructure:** contiene el acceso y conexión a la base de datos.
- **MenuSemanal.API:** contiene los controladores y endpoints de la API.

También se encuentra:

- **MenuSemanal.Frontend:** contiene la interfaz de usuario desarrollada con Blazor.

Arquitectura

El proyecto utiliza una arquitectura distribuida.

El Frontend desarrollado con Blazor se comunica con la API mediante solicitudes HTTP. La API procesa las operaciones del sistema y utiliza Entity Framework Core para trabajar con la base de datos SQL Server.

De manera sencilla, el funcionamiento es:

Frontend Blazor → API → Base de Datos SQL Server

Entidades principales

El sistema trabaja principalmente con las siguientes entidades:

MenuSemanal

Permite registrar el nombre del menú, la fecha de inicio y la fecha de fin.

Comida

Permite registrar las comidas y asociarlas a un menú semanal.

Ingrediente

Permite registrar el nombre, cantidad y unidad de medida de los ingredientes y asociarlos a una comida.

ListaCompra

Permite registrar productos, cantidades, unidades de medida y especificar si el producto ya fue comprado.

Base de datos

El proyecto utiliza SQL Server como base de datos y Entity Framework Core para realizar el acceso a los datos.

Los registros creados desde el Frontend son enviados a la API y almacenados en la base de datos.

API

La API permite realizar las operaciones CRUD principales:

- GET para consultar.
- POST para crear.
- PUT para actualizar.
- DELETE para eliminar.

Los endpoints también pueden ser probados utilizando Swagger.

Tecnologías utilizadas

- C#
- .NET
- ASP.NET Core Web API
- Blazor
- Entity Framework Core
- SQL Server
- Swagger
- Git y GitHub
- Visual Studio

Objetivo

El objetivo de PlanificaPro es facilitar la organización de la alimentación semanal mediante un sistema que permita administrar menús, comidas, ingredientes y productos de compra.
