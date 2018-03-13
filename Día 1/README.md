###Presentación
Para romper el hielo, ponernos en sintonía y dar tiempo de preparar el entorno se hizo una pequeña presentación (ppt anexo).

Comenzó con una pequeña introducción sobre mi experiencia en sistemas, enfocado a la parte de backend, con algunas experiencias.

Se presentó una línea de tiempo con algunos eventos que influyeron para que se creara Core (La creciente corriente open source, el aprovechamiento de procesamiento paralelo, cambios de liderazgo y cultura en Microsoft, el desarrollo de virtualización y la nuve, entre otros).

La lína concluyó con lo que es la filosofía detrás del desarrollo de net core (Apertura, [programación asíncrona](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/), paralela y funcional, infraestructura en la nube).

También se incluyo una breve explicación sobre el [middleware](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?tabs=aspnetcore2x), parte fundamental en la nueva arquitectura de Core, así como la [inyección de dependencias](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection).

Con dos animaciónes de mostró la diferencia entre un manejo asíncrono de un request y uno síncrono.

###Aplicación
Para demostrar una aplicación de Net Core se utilizó visual studio 2017, donde:

1. Se creo un nuevo proyecto basado en una aplicación web con net core, incluyendo el manejo de sesiones de usuario usando una base de datos.
1. Se dió una breve descripción del contenido de las carpetas y utilidad de los archivos generados, algunos fueron
   1. Dependencias Nuget incluídas
   1. Archivo de propiedades para los ambientes de desarrollo
   1. Folder de recursos estáticos
   1. Controladores y Contexto en la carpeta `Data`
   1. Archivos de configuración json y como se sobreescriben con las configuraciónes del ambiente.
   1. Como `Program` es un simple main que inicia toda la aplicación web
   1. Cuales son las configuraciones que se generan en `Startup` y como se configura el `Middleware` por defecto.
1. Se procedió a correr la aplicación, mostrando el index
   1. Se generó un error al no estar la base de datos con migraciones, para mostrar la diferencia entre los errrores en un ambiente de desarrollo y en uno de producción, editando el archivo `launchSettings`
1. Se mostró como se aplican las migraciones con el CLI de Net Core y se procedió a generar un usuario en la aplicación
1. Se generó un nuevo modelo, `BlogPost`, con el cuál se usó [scaffolding](https://code.msdn.microsoft.com/Scaffolding-ASPNet-Core-MVC-1e9183fd) para generar un CRUD básico.
   1. Se explicó cada uno de los archivos generados, las [razor pages](https://docs.microsoft.com/en-us/aspnet/core/mvc/razor-pages/?tabs=visual-studio) y sus `models`, con los métodos de transformación `on(HttpVerb)[Async]`, como `onPostAsync`
   1. También como las variables se enlazan a los formularios por medio de la anotación `BindProperty`
   1. Los nuevos "library tags" para las vistas razor, que permiten una integración más transparente con el Html
1. Se creó un `Middleware` en `Startup` para medir la velocidad de carga de las páginas
   1. Otro con un `Map`, para procesar peticiones a urls particulares, el cual rompe la cadena al no llamar `next`
   1. Se movió el `Middleware` a una clase separada y se creo un método de extensión para cumplir con el estándar de net core y mantener el código limpio
   
Como ejercicio, se platicó sobre las posibles arquitecturas para una aplicación en Net Core, con separación de las capas de Aplicación, Servicios y Repositorios y se intercambiaron experiencias profesionales.
Quedan algunas dudas pendientes que dejaré en los comentarios.