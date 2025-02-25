# Coin Price Dashboard

## Descripción

**Coin Price Dashboard** es una aplicación web diseñada para mostrar en tiempo real los precios de criptomonedas. Los usuarios pueden buscar monedas específicas y recibir actualizaciones constantes de su valor. La aplicación hace uso de diversas tecnologías y servicios de backend y frontend para asegurar un funcionamiento eficiente y en tiempo real.

## Tecnologías Utilizadas

### Backend:
- **.NET C#**: Framework principal para el desarrollo del backend.
- **Background Service**: Utilizado para realizar tareas en segundo plano, como la actualización periódica de los precios de las monedas.
- **SignalR**: Permite la comunicación en tiempo real entre el servidor y los clientes para enviar actualizaciones de precios de monedas específicas en función de las búsquedas de los usuarios.
- **MemoryCache**: Se usa para almacenar en memoria los datos de la API de criptomonedas, lo que mejora la eficiencia de las consultas y reduce la latencia en las actualizaciones de precios.

### Frontend:
- **Angular**: Framework de frontend utilizado para la interfaz de usuario, donde se muestra de manera dinámica la información de las monedas seleccionadas por los usuarios.

## Funcionalidades

- **Búsqueda de monedas**: Los usuarios pueden buscar y seleccionar monedas específicas, como Bitcoin, Ethereum, entre otras.
- **Actualización en tiempo real**: Usando SignalR, la aplicación actualiza los precios de las monedas que los usuarios han buscado, en tiempo real.
- **Actualización en segundo plano**: Mediante un servicio en segundo plano (`BackgroundService`), la aplicación realiza solicitudes periódicas a la API de criptomonedas para obtener los precios más recientes de todas las monedas.
- **Uso de MemoryCache**: Para optimizar el rendimiento, los datos de las monedas obtenidos de la API se almacenan en memoria, evitando la necesidad de realizar llamadas repetitivas a la API.

# Comentario
- Este codigo esta hecho para demostrar lo aprendido y al ser bastante simple puede ayudar a otros desarrolladores a conocer y aprender como utilizar websockets y servicios en segundo plano en sus proyectos.
