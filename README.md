# PruebaVistasDinamicas
Prueba de como crear vistas razor al vuelo sin los invonvenientes de crear un virtualPathProvider custom

Hay varios artículos que explican como crear vistas razor dinámicas. 

La mayoría incluye crear un VirtualPathProvider y/o un ViewEngine.

Yo no se si toda esta gente lo ha usado realmente. Lo primero que pasa cuando lo usas en un proyecto real, 
es que estas vistas no tienen acceso a toda la configuración del /Views/Web.Config y ahí empiezan los problemas


Esta prueba se basa en la idea de ahorrarnos todas estas complicaciones escribiendo la vista directamente a disco
para que luego Razor la procese "normalmente"
