using System;
using System.Data; //potrzebna biblioteka do datatable
using System.Linq;
class Dodawanie
{
    public double Wykonaj(double a, double b)
    {
        return a + b;
    }
}
class Odejmowanie
{
    public double Wykonaj(double a, double b)
    {
        return a - b;
    }
}
class Mnozenie
{
    public double Wykonaj(double a, double b)
    {
        return a * b;
    }
}
class Dzielenie
{
    public double Wykonaj(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Nie można dzielić przez zero!");
            return 0;
        }
        else
            return a / b;
    }
}
class Potęgowanie
{
    public double Wykonaj(double a, double b)
    {
        return Math.Pow(a, b);
    }
}
class Pierwiastkowanie
{
    public double Wykonaj(double a)
    {
        if (a < 0)
        {
            Console.WriteLine("Nie można pierwiastkować liczby ujemnej!");
            return 0;
        }
        return Math.Sqrt(a);
    }
}
class Bezwzględna
{
    public double Wykonaj(double a)
    {
        return Math.Abs(a);
    }
}
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nKALKULATOR");
            Console.WriteLine("1. Dodawanie");
            Console.WriteLine("2. Odejmowanie");
            Console.WriteLine("3. Mnozenie");
            Console.WriteLine("4. Dzielenie");
            Console.WriteLine("5. Potęgowanie");
            Console.WriteLine("6. Pierwiastkowanie");
            Console.WriteLine("7. Wartość bezwzględna");
            Console.WriteLine("8. Oblicz równanie (np. 3 + (3/5)*4)");
            Console.WriteLine("9. Funkcja kwadratowa");
            Console.WriteLine("0. Wyjście");
            Console.Write("\nWybierz opcję: ");
            string wybor = Console.ReadLine(); switch (wybor)
            {
                case "1":
                    double a1 = PobierzLiczbe("Podaj pierwszą liczbę: ");
                    double b1 = PobierzLiczbe("Podaj drugą: ");
                    Console.WriteLine($"Wynik: {new Dodawanie().Wykonaj(a1, b1)}");
                    break;
                case "2":
                    double a2 = PobierzLiczbe("Podaj pierwszą liczbę: ");
                    double b2 = PobierzLiczbe("Podaj drugą: ");
                    Console.WriteLine($"Wynik: {new Odejmowanie().Wykonaj(a2, b2)}");
                    break;
                case "3":
                    double a3 = PobierzLiczbe("Podaj pierwszą liczbę: ");
                    double b3 = PobierzLiczbe("Podaj drugą: ");
                    Console.WriteLine($"Wynik: {new Mnozenie().Wykonaj(a3, b3)}");
                    break;
                case "4":
                    double a4 = PobierzLiczbe("Podaj pierwszą liczbę: ");
                    double b4 = PobierzLiczbe("Podaj drugą: ");
                    Console.WriteLine($"Wynik: {new Dzielenie().Wykonaj(a4, b4)}");
                    break;
                case "5":
                    double a5 = PobierzLiczbe("Podaj podstawę: ");
                    double b5 = PobierzLiczbe("Podaj wykładnik: ");
                    Console.WriteLine($"Wynik: {new Potęgowanie().Wykonaj(a5, b5)}");
                    break;
                case "6":
                    double a6 = PobierzLiczbe("Podaj liczbę do wypierwiastkowania: ");
                    Console.WriteLine($"Wynik: {new Pierwiastkowanie().Wykonaj(a6)}"); break;
                case "7":
                    double a7 = PobierzLiczbe("Podaj liczbę do wartosci bezwlędnej: ");
                    Console.WriteLine($"Wynik: {new Bezwzględna().Wykonaj(a7)}");
                    break;
                case "8":
                    Console.WriteLine("Podaj rownanie: ");
                    string rownanie = Console.ReadLine();
                    rownanie = rownanie.Replace(",", ".").Replace(" ", "");
                    double wynikRownania = Convert.ToDouble(new
                    DataTable().Compute(rownanie, null));
                    Console.WriteLine($"Wynik: {wynikRownania}");
                    break;
                case "9":
                    Console.WriteLine("Funkcja kwadratowa: a(x*x) + bx + c = 0");
                    double a;
                    do
                    {
                        a = PobierzLiczbe("Podaj a: ");
                        if (a == 0)
                        {
                            Console.WriteLine("Współczynnik 'a' nie może być zerem!");
                        }
                    } while (a == 0);
                    double b = PobierzLiczbe("Podaj b: ");
                    double c = PobierzLiczbe("Podaj c: ");
                    double delta = b * b - 4 * a * c;
                    Console.WriteLine($"Delta: {delta}");
                    if (delta < 0)
                        Console.WriteLine("Brak rozwiązan");
                    else if (delta == 0)
                        Console.WriteLine($"Jedno rozwiązanie: x = {-b / (2 * a)}");
                    else
                    {
                        double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                        double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                        Console.WriteLine($"Pierwsze rozwiązanie: x1 = {x1} "); Console.WriteLine($"Pierwsze rozwiązanie: x2 = {x2} ");
                    }
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Nieznana Opcja");
                    break;
                    static double PobierzLiczbe(string komunikat)
                    {
                        while (true)
                        {
                            Console.Write(komunikat);
                            string input = Console.ReadLine().Replace(",", ".");
                            if (double.TryParse(input, System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture, out double wynik))
                                return wynik;
                            Console.WriteLine("Nieprawidłowa liczba, spróbuj ponownie.");
                        }
                    }
            }
        }
    }
}