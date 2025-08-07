using System;

class Guerrero
{
    // Estadísticas del guerrero
    static int fuerza = 10;
    static int resistencia = 10;
    static int energia = 100;
    static int experiencia = 0;
    static int nivel = 1;

    const int energiaMaxima = 100;
    const int limiteHoras = 6;

    static void Main()
    {
        int opcion;

        do
        {
            MostrarMenu();
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("!!Opción no válida¡¡ Intenta de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1: VerEstado(); break;
                case 2: Entrenar("fuerza"); break;
                case 3: Entrenar("resistencia"); break;
                case 4: Descansar(); break;
                case 5: Pelear(); break;
                case 6: Console.WriteLine("¡Gracias por jugar!"); break;
                default: Console.WriteLine("Opción no válida."); break;
            }

            RevisarNivel();

        } while (opcion != 6);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Ver estado");
        Console.WriteLine("2. Entrenar fuerza");
        Console.WriteLine("3. Entrenar resistencia");
        Console.WriteLine("4. Descansar");
        Console.WriteLine("5. Pelear");
        Console.WriteLine("6. Salir");
        Console.Write("Selecciona una opción: ");
    }

    static void VerEstado()
    {
        Console.WriteLine("\n ESTADO DEL GUERRERO:");
        Console.WriteLine($"Nivel: {nivel}");
        Console.WriteLine($"Fuerza: {fuerza}");
        Console.WriteLine($"Resistencia: {resistencia}");
        Console.WriteLine($"Energía: {energia}/{energiaMaxima}");
        Console.WriteLine($"Experiencia: {experiencia}/100");
    }

    static void Entrenar(string tipo)
    {
        Console.Write($"\n¿Cuántas horas deseas entrenar {tipo}? (máximo {limiteHoras}): ");
        if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 1 || horas > limiteHoras)
        {
            Console.WriteLine("Número de horas no válido.");
            return;
        }

        int costoEnergia = horas * 10;
        if (energia < costoEnergia)
        {
            Console.WriteLine("No tienes suficiente energía para entrenar.");
            return;
        }

        energia -= costoEnergia;
        experiencia += horas * 5;

        if (tipo == "fuerza")
        {
            fuerza += horas * 2;
            Console.WriteLine($"Entrenaste fuerza durante {horas} horas. +{horas * 2} fuerza.");
        }
        else if (tipo == "resistencia")
        {
            resistencia += horas * 2;
            Console.WriteLine($"Entrenaste resistencia durante {horas} horas. +{horas * 2} resistencia.");
        }
    }

    static void Descansar()
    {
        Console.Write("\n¿Cuántas horas deseas descansar? (máximo 6): ");
        if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 1 || horas > limiteHoras)
        {
            Console.WriteLine("Número de horas no válido.");
            return;
        }

        int energiaRecuperada = horas * 15;
        energia += energiaRecuperada;
        if (energia > energiaMaxima)
            energia = energiaMaxima;

        Console.WriteLine($"Descansaste {horas} horas. +{energiaRecuperada} energía.");
    }

    static void Pelear()
    {
        if (energia < 20)
        {
            Console.WriteLine("Estás demasiado agotado para pelear.");
            return;
        }

        energia -= 20;

        Random rnd = new Random();
        int enemigoFuerza = rnd.Next(5, 15);
        int enemigoResistencia = rnd.Next(5, 15);
        Console.WriteLine("\n¡Un enemigo aparece!");
        Console.WriteLine($"Enemigo - Fuerza: {enemigoFuerza}, Resistencia: {enemigoResistencia}");

        bool victoria = (fuerza > enemigoFuerza && resistencia > enemigoResistencia);

        if (victoria)
        {
            experiencia += 25;
            Console.WriteLine("¡Has ganado la batalla! +25 experiencia.");
        }
        else
        {
            experiencia += 10;
            Console.WriteLine("Has perdido, pero aprendiste algo. +10 experiencia.");
        }
    }

    static void RevisarNivel()
    {
        while (experiencia >= 100)
        {
            experiencia -= 100;
            nivel++;
            fuerza += 2;
            resistencia += 2;
            Console.WriteLine($"\n¡Subiste al nivel {nivel}!");
            Console.WriteLine("+2 fuerza y +2 resistencia por subir de nivel.");
        }
    }
}
