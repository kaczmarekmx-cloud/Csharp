using System;
using System.Collections.Generic;

class Program
{
    // Parsuje "3x^2 + 2x - 5" na listę (współczynnik, wykładnik)
    static List<(double wsp, double wyk)> Parsuj(string funkcja)
    {
        var lista = new List<(double, double)>();

        funkcja = funkcja.Replace(" ", "").Replace("-", "+-");
        string[] skladniki = funkcja.Split('+');

        foreach (string s in skladniki)
        {
            if (s == "" || s == "-") continue;

            double wsp = 1;
            double wyk = 0;

            if (s.Contains("x"))
            {
                int indeksX = s.IndexOf('x');
                string przed = s.Substring(0, indeksX);
                string po = s.Substring(indeksX + 1);

                // współczynnik
                if (przed == "" || przed == "+") wsp = 1;
                else if (przed == "-") wsp = -1;
                else wsp = double.Parse(przed, System.Globalization.CultureInfo.InvariantCulture);

                // wykładnik
                if (po == "") wyk = 1;
                else if (po.StartsWith("^"))
                    wyk = double.Parse(po.Substring(1), System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                wsp = double.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
                wyk = 0;
            }

            lista.Add((wsp, wyk));
        }

        return lista;
    }

    // Formatuje jeden człon np. 3, x^2 -> "3x^2"
    static string FormatujCzlon(double wsp, double wyk)
    {
        string w = wsp % 1 == 0
            ? ((int)Math.Abs(wsp)).ToString()
            : Math.Abs(wsp).ToString("0.###", System.Globalization.CultureInfo.InvariantCulture);

        if (wyk == 0) return w;
        if (wyk == 1) return $"{w}x";

        string e = wyk % 1 == 0 ? ((int)wyk).ToString() : wyk.ToString();
        return $"{w}x^{e}";
    }

    // Całkowanie nieoznaczone zwraca string np. "x^3 + x^2 - 5x + C"
    static string Nieoznaczone(List<(double wsp, double wyk)> skladniki)
    {
        string wynik = "";

        foreach (var (wsp, wyk) in skladniki)
        {
            double nowyWyk = wyk + 1;
            double nowyWsp = wsp / nowyWyk;

            string czlon = FormatujCzlon(nowyWsp, nowyWyk);

            if (wynik == "")
                wynik = nowyWsp >= 0 ? czlon : $"-{czlon}";
            else
                wynik += nowyWsp >= 0 ? $" + {czlon}" : $" - {czlon}";
        }

        return wynik + " + C";
    }

    // Całkowanie oznaczone zwraca liczbę F(b) - F(a)
    static double Oznaczone(List<(double wsp, double wyk)> skladniki, double a, double b)
    {
        double wynik = 0;

        foreach (var (wsp, wyk) in skladniki)
        {
            double nowyWyk = wyk + 1;
            double nowyWsp = wsp / nowyWyk;

            wynik += nowyWsp * Math.Pow(b, nowyWyk)
            - nowyWsp * Math.Pow(a, nowyWyk);
        }

        return wynik;
    }

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("   KALKULATOR CALKOWANIA");
            Console.WriteLine("1. Calkowanie oznaczone");
            Console.WriteLine("2. Calkowanie nieoznaczone");
            Console.WriteLine("0. Wyjscie");
            Console.Write("\nWybierz opcje: ");

            string wybor = Console.ReadLine();

            if (wybor == "0") return;

            if (wybor != "1" && wybor != "2")
            {
                Console.WriteLine("Nieznana opcja!");
                Console.ReadKey();
                continue;
            }

            Console.WriteLine("\nPrzykladowe funkcje:");
            Console.WriteLine("  3x^2 + 2x - 5");
            Console.WriteLine("  x^3 - 4x + 1");
            Console.Write("\nf(x) = ");

            string funkcja = Console.ReadLine();

            try
            {
                var skladniki = Parsuj(funkcja);

                if (wybor == "2")
                {
                    string wynik = Nieoznaczone(skladniki);
                    Console.WriteLine($"\nWynik: {wynik}");
                }
                else
                {
                    Console.Write("Podaj dolna granice a: ");
                    double a = double.Parse(
                        Console.ReadLine().Replace(",", "."),
                        System.Globalization.CultureInfo.InvariantCulture);

                    Console.Write("Podaj gorna granice b: ");
                    double b = double.Parse(
                        Console.ReadLine().Replace(",", "."),
                        System.Globalization.CultureInfo.InvariantCulture);

                    double wynik = Oznaczone(skladniki, a, b);
                    Console.WriteLine($"\nWynik: {wynik}");
                }
            }
            catch
            {
                Console.WriteLine("\nBlad! Sprawdz format funkcji.");
                Console.WriteLine("Poprawny format: 3x^2 + 2x - 5");
            }

            Console.WriteLine("\nNacisnij dowolny klawisz...");
            Console.ReadKey();
        }
    }
}