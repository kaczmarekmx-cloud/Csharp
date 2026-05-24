using System;
using System.Linq;
class Program
{
    static double przyblizeniePI(int iteracja) // ZADANIE 1
    {
        double pi = 0;
        for (int i = 0; i < iteracja; i++)
        {
            pi += Math.Pow(-1, i) / (2 * i + 1); // Math.Pow dziala na podstawie liczba x
            //zwiekszona do mocy y
        }
        return pi * 4;
    }
    static string binarna(int n) // ZADANIE 2
    {
        if (n == 0) return "0";
        string result = "";
        while (n > 0)
        {
            result = (n % 2) + result;
            n /= 2;
        }
        return result;
    }
    static void przesunieciebit(int n) // ZADANIE 3
    {
        Console.WriteLine($"przesuniecie bit w lewo o dwa <<2: {binarna(n << 2),8} ({n << 2})"); //tą 8 dalem tylko zeby byla ladna spacja przed wynikiem
        Console.WriteLine($"przesuniecie bit w prawo o jeden >>1: {binarna(n >> 1),8} ({n >> 1})");
    }
    static void obrotbit(int n) // ZADANIE 4
    {
        string binary = binarna(n);
        string obrot = new string(binary.Reverse().ToArray());
        Console.WriteLine(obrot);
    }
    enum Kierunkowe
    {
        USA = 1,
        Niemcy = 49,
        Polska = 48,
        Francja = 33,
        Hiszpania = 34,
    }
    static void zgadnijKraj() // ZADANIE 5
    {
        Console.WriteLine("Podaj numer telefonu np. 48123456789");
        string numer = Console.ReadLine();
        foreach (Kierunkowe kraj in Enum.GetValues(typeof(Kierunkowe)))
        {
            string kod = ((int)kraj).ToString();
            if (numer.StartsWith(kod))
            {
                Console.WriteLine($"kraj: {kraj} ");
                return;
            }
        }
    }
    static void Main()
    {
        Console.WriteLine("Przyblizenie PI:");
        Console.WriteLine(przyblizeniePI(100)); // im wiecej zer dodamy tym dokladnosc przyblizenia rosnie np 100000 poniewaz iteracje beda wiecej razy wykonywane i dadza nam dokladniejszy wynik
        Console.WriteLine();
        Console.WriteLine("Podaj liczbe dziesietna: ");
        int dziesietna = int.Parse(Console.ReadLine());
        Console.WriteLine("Liczba binarna: ");
        Console.WriteLine(binarna(dziesietna)); // liczbe ktora wpiszemy w binarna(dziesietna) bedzie rozkladana na liczbe binarna
        Console.WriteLine(); przesunieciebit(dziesietna);
        Console.WriteLine();
        obrotbit(dziesietna);
        Console.WriteLine();
        zgadnijKraj();
        Console.WriteLine();
    }
}