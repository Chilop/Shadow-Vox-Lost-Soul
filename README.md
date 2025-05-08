## generacion de terreno

para generar terreno en el sistema de generacion de este proyecto necesitas crear una nueva escena y entrar a la carpeta assets
![image](https://github.com/user-attachments/assets/6bfb759a-8856-4c63-827c-02d3c087a056)

luego a la carpeta level creation

![image](https://github.com/user-attachments/assets/b02ba23d-032a-42a0-a87b-81ca8aca7f17)

luego a terrain

![image](https://github.com/user-attachments/assets/f6b9cde2-8ca0-4c2c-b247-abc173d3a0e5)

arrastras a escena el elemento 32*32 referemce modificando su transform a x0,y0,z0

![image](https://github.com/user-attachments/assets/5d303c14-3fee-4d90-9041-f316c90c7650)

estando en el editor dentro del area de referencia arrastrar al suelo uno de estos bloques dependiendo de que quieras usar de suelo

![image](https://github.com/user-attachments/assets/62b5e0f7-f9a4-471b-89b6-181e3cec3137) ![image](https://github.com/user-attachments/assets/fefd19f7-ba2b-41f0-b72f-fa395ba6324f)

modificas el transform del suelo para que abarque todo el suelo(importante el eje Y no debe ser un numero entero siendo de preferencia multiplo de 0.5)

![image](https://github.com/user-attachments/assets/86902d61-7799-482b-bd2c-d74b2315a5d8)

de ally modificar y poner todos los bloques que quieras en las posiciones que quieras del tipo que quieras (excepto debug) se recomienda evitar que queden espacios vacios en el mapa y si vas a hacer un gran cubo de preferencia hacerlo hueco,
tambien se recomienda lo mismo que el eje y tenga .5 en los decimales  y los ejes X y Z esten sin decimales como numeros enteros

![image](https://github.com/user-attachments/assets/2d952c9e-3cc7-46dc-a74b-7bc92efe63ec)

una vez hecho esto instanciar a un jugador(para eso consultar a chilo que es quien se encarga del jugador en si ) y darle play, detalles para pasar a otro nivel seran añadidos en un futuro







