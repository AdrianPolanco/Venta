***Documentación del funcionamiento de la capa de API***

Mi trabajo consistio en trabajar las tablas de Usuario y Ventas, por tanto, las rutas y entidades con las que trabaja mi rama son esas dos.

***Controlador de Ventas (SalesController)***

Esta es una vista general del controlador de Ventas que cree: 

![salesGeneral](https://github.com/Abnerdotel/Venta/assets/116674818/87062cde-2e84-4fb6-913b-7748d2b4004b)

El primer endpoint es una ruta GET, para obtener todas las ventas registradas en la base de datos:
![getall](https://github.com/Abnerdotel/Venta/assets/116674818/b86fc26e-76aa-4245-b253-8cbd804d28bb)

El segundo endpoint es una ruta POST, que ingresa una nueva venta en la base de datos:

![post_sale1](https://github.com/Abnerdotel/Venta/assets/116674818/31ba989c-27ee-4b7b-945d-652564551207)
![post_sale2](https://github.com/Abnerdotel/Venta/assets/116674818/ff6a95c9-2e95-4b98-aa75-aaa5c8198747)

El tercer endpoint es otra ruta GET, pero para obtener una venta basada en su id: 
![get_sale_id](https://github.com/Abnerdotel/Venta/assets/116674818/1e4e65b1-feb2-49d2-a821-de2d1092b88e)

El cuarto endpoint es una ruta PUT, para actualizar una venta ya existente basandose en el id y un conjunto de datos correspondiente a los nuevos datos de la venta:
![put_1](https://github.com/Abnerdotel/Venta/assets/116674818/2c55c6e9-fef9-40df-83a3-5c8d71df9168)
![put_2](https://github.com/Abnerdotel/Venta/assets/116674818/0ebef4b2-a620-44ad-91f0-05323bb68449)

El quinto endpoint es una ruta DELETE, para eliminar una venta existente basandose en el id:

![delete_sale](https://github.com/Abnerdotel/Venta/assets/116674818/d86e5a67-5455-429c-acdb-caa4bd5154de)

El sexto endpoint es una ruta GET, para obtener las ventas ordenadas por fecha:

![sales_dates](https://github.com/Abnerdotel/Venta/assets/116674818/cfd71e96-77f6-4617-b6f3-1b946f7e0fdf)

El septimo y ultimo endpoint de este controlador es otra ruta GET, para obtener las ventas por su monto total: 
![get_totals](https://github.com/Abnerdotel/Venta/assets/116674818/4437fd7b-d746-4a03-a976-f4e6556c5213)

***Controlador de Usuario (UserController)***

En este controlador tengo ocho endpoints relacionados a la tabla Usuario:

![users](https://github.com/Abnerdotel/Venta/assets/116674818/d4c6e051-9ed5-4fc9-894e-de0d22590114)

El primer endpoint es una ruta GET, para obtener todos los usuarios en la base de datos:
![users_get](https://github.com/Abnerdotel/Venta/assets/116674818/74c69982-d74a-410b-bf26-80d8b325e46b)


El segundo endpoint es una ruta POST, que registra un nuevo usuario en la base de datos:
![post_user1](https://github.com/Abnerdotel/Venta/assets/116674818/0c9f02ac-e747-4ce2-ba17-d0fed6b3247a)
![post_user2](https://github.com/Abnerdotel/Venta/assets/116674818/72400035-6130-4e0d-a9e4-57f3f50952c7)

El tercer endpoint es otra ruta GET, pero para obtener un usuario basado en su id: 
![user_id](https://github.com/Abnerdotel/Venta/assets/116674818/eca09754-f5fb-4df3-99a5-7d8f210f0dfa)


El cuarto endpoint es una ruta PUT, para actualizar un usuario ya existente basandose en el id y un conjunto de datos correspondiente a los nuevos datos dl usuario:
![put_user1](https://github.com/Abnerdotel/Venta/assets/116674818/45dfad57-02e1-4123-8be6-4fc354709730)
![put_user2](https://github.com/Abnerdotel/Venta/assets/116674818/dd6b6d6f-efc4-473a-a62b-7c419eaf587d)


El quinto endpoint es una ruta DELETE, para eliminar un usuario existente basandose en el id:
![delete_user](https://github.com/Abnerdotel/Venta/assets/116674818/0356afb8-49a9-4c05-b5e2-5a5e97577df7)


El sexto endpoint es una ruta GET, para obtener los usuarios ordenados por fecha de registro:

![user_dates](https://github.com/Abnerdotel/Venta/assets/116674818/87d09551-aca8-403b-b840-acd3b6920227)


El septimo endpoint es una ruta GET, para obtener los usuarios ordenados por sus roles: 

![user_roles](https://github.com/Abnerdotel/Venta/assets/116674818/e550dcac-7292-494c-b222-2353c644d63b)

El octavo y ultimo endpoint de este controlador es una ruta GET, para obtener los usuarios por nombre, en orden alfabetico:
![usernames](https://github.com/Abnerdotel/Venta/assets/116674818/90ebc490-a2e0-48f1-8d79-f2c25b8a4abf)

*** Video sobre el proyecto final ***

https://www.youtube.com/watch?v=1yEYJTn50F8
