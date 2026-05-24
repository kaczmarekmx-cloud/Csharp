using System;
using System.Data;

class Matrix
{
    private double[,] dane;
    public int Wiersze { get; }
    public int Kolumny { get; }

    public Matrix (int wiersze, int kolumny)
    {
        Wiersze = wiersze;
        Kolumny = kolumny;
        dane = new double[wiersze, kolumny];
    }
    
    public double this[int i, int j]
    {
        get => dane[i, j];
        set => dane[i, j] = value;
    }
    public static Matrix Wczytaj()
    {
        Console.Write("Podaj liczbe wierszy: ");
        int w = int.Parse(Console.ReadLine());
        Console.Write("Podaj liczbe kolumn: ");
        int k = int.Parse(Console.ReadLine());

        Matrix m = new Matrix(w, k);
        Console.WriteLine("Podaj elementy:");

        for (int i = 0; i < w; i++)
            for (int j = 0; j < k; j++)
            {
                Console.Write($"  [{i+1},{j+1}] = ");
                m[i, j] = double.Parse(
                    Console.ReadLine().Replace(",", "."),
                    System.Globalization.CultureInfo.InvariantCulture);
            }

        return m;
    }
    public void Wyswietl()
    {
        for (int i = 0; i < Wiersze; i++)
        {
            Console.Write("[ ");
            for (int j = 0; j < Kolumny; j++)
                Console.Write($"{dane[i, j]} ");
            Console.WriteLine("]");
        }
    }

    public static Matrix operator+(Matrix a, Matrix b)
    {
        if (a.Wiersze != b.Wiersze || a.Kolumny != b.Kolumny)
            throw new Exception("Macierze musza miec te same wymiary!");

            Matrix wynik = new Matrix(a.Wiersze, a.Kolumny);
            for (int i = 0; i < a.Wiersze; i++)
                for (int j = 0; j < a.Kolumny; j++)
                    wynik[i, j] = a[i, j] + b[i, j];

    return wynik;
    }
    
    public static Matrix operator*(Matrix a, Matrix b)
    {
        if (a.Kolumny != b.Wiersze)
            throw new Exception("Liczba kolumn A musi byc rowna liczbie wierszy B!");

        Matrix wynik = new Matrix(a.Wiersze, b.Kolumny);
        for (int i = 0; i < a.Wiersze; i++)
            for (int j = 0; j < b.Kolumny; j++)
                for (int k = 0; k < a.Kolumny; k++)
                    wynik[i, j] += a[i, k] * b[k, j];

        return wynik;
    }
    public Matrix Transpozycja()
    {
        Matrix wynik = new Matrix(Kolumny, Wiersze);
        for (int i = 0; i < Wiersze; i++)
            for (int j = 0; j < Kolumny; j++)
                wynik[j, i] = dane[i, j];

        return wynik;
    }
}
class Program
{
    static void Main()
    {
        Matrix a = null;
        Matrix b = null;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("   KALKULATOR MACIERZY ");
            Console.WriteLine("1. Wprowadz macierz A");
            Console.WriteLine("2. Wprowadz macierz B");
            Console.WriteLine("3. Dodaj A + B");
            Console.WriteLine("4. Mnozenie A * B");
            Console.WriteLine("5. Transpozycja macierzy");
            Console.WriteLine("0. Wyjscie");
            Console.Write("\nWybierz opcje: ");

            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                a = Matrix.Wczytaj();
                Console.WriteLine("\nMacierz A:");
                a.Wyswietl();
                break;

                case "2":
                b = Matrix.Wczytaj();
                Console.WriteLine("\nMacierz B:");
                b.Wyswietl();
                break;

                case "3":
                if (a == null || b == null)
                throw new Exception("Najpierw wprowadz obie macierze!");
                Console.WriteLine("\nWynik A + B:");
                (a + b).Wyswietl();
                break;
                
                case "4":
                if (a == null || b == null)
                throw new Exception("Najpierw wprowadz obie macierze!");
                Console.WriteLine("\nWynik A * B:");
                (a * b).Wyswietl();
                break;
            
                case "5":
                Console.WriteLine("Którą macierz chcesz transpozycjonować? :");
                string opcja = Console.ReadLine();
                if (opcja == "a" || opcja == "A")
                {
                    Console.WriteLine("Macierz A przed transpozycją");
                    a.Wyswietl();
                    Console.WriteLine();
                    Console.WriteLine("Macierz A po transpozycji");
                    a.Transpozycja().Wyswietl();
                }
                else if (opcja == "b" || opcja == "B")
                {
                    Console.WriteLine("Macierz B przed transpozycją");
                    b.Wyswietl();
                    Console.WriteLine();
                    Console.WriteLine("Macierz B po transpozycji");
                    b.Transpozycja().Wyswietl();
                }
                else
                {
                    Console.WriteLine("Nie ma takiej macierzy");
                    return;
                }
                break;

                case "0":
                return;
                
                default:
                Console.WriteLine("Nieznana opcja!");
                break;
            }

            Console.WriteLine("\nNacisnij dowolny klawisz...");
            Console.ReadKey();
        }
    }
}