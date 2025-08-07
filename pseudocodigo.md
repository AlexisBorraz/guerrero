INICIAR programa Guerrero


// Variables iniciales
fuerza ← 10
resistencia ← 10
energia ← 100
experiencia ← 0
nivel ← 1

REPETIR
    MOSTRAR menú:
        1. Ver estado
        2. Entrenar fuerza
        3. Entrenar resistencia
        4. Descansar
        5. Pelear
        6. Salir
    LEER opcion

    SI opcion = 1 ENTONCES
        MOSTRAR nivel, fuerza, resistencia, energia, experiencia

    SI opcion = 2 ENTONCES
        PEDIR horas
        SI energia suficiente ENTONCES
            aumentar fuerza
            gastar energía
            ganar experiencia
        SINO
            MOSTRAR "No tienes energía"
        FIN SI

    SI opcion = 3 ENTONCES
        PEDIR horas
        SI energia suficiente ENTONCES
            aumentar resistencia
            gastar energía
            ganar experiencia
        SINO
            MOSTRAR "No tienes energía"
        FIN SI

    SI opcion = 4 ENTONCES
        PEDIR horas
        aumentar energía

    SI opcion = 5 ENTONCES
        SI energía suficiente ENTONCES
            generar enemigo
            COMPARAR estadísticas
            SI ganas ENTONCES
                ganar experiencia extra
            SINO
                ganar poca experiencia
            FIN SI
            gastar energía
        SINO
            MOSTRAR "Estás muy cansado para pelear"
        FIN SI

    SI experiencia >= 100 ENTONCES
        subir de nivel
        aumentar fuerza y resistencia
        restar 100 a experiencia
    FIN SI

HASTA que opcion = 6

FINALIZAR programa
