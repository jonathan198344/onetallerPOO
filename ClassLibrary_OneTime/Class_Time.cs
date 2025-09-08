using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Time t1 = new Time();
            Time t2 = new Time(5);
            Time t3 = new Time(5, 10);
            Time t4 = new Time(5, 10, 34);
            Time t5 = new Time(23, 58, 34, 666);

            Time[] tiempos = { t1, t2, t3, t4, t5 };

            Console.WriteLine("Tiempos iniciales:");
            foreach (var t in tiempos)
            {
                Console.WriteLine(t.ToString());
            }

            Console.WriteLine("\nSumando cada tiempo con t3:");
            foreach (var t in tiempos)
            {
                var suma = t.Add(t3);
                bool pasaOtroDia = suma.IsOtherDay(t4);
                Console.WriteLine($"{t.ToString()} + {t3.ToString()} = {suma.ToString()} - ¿Pasa al otro día con t4? {pasaOtroDia}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}