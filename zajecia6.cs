using System;

class Pracownik
{
    private string imie;
    private string nazwisko;
    private double pensja;

    public string Imie
    {
        get => imie;
        set => imie = value;
    }
    public string Nazwisko
    {
        get => nazwisko;
        set => nazwisko = value;
    }
    public double Pensja
    {
        get => pensja;
        set
        {
            if (value < 0) throw new Exception("Pensja nie moze byc ujemna!");
            pensja = value;
        }
    }
    public Pracownik(string imie, string nazwisko, double pensja)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        Pensja = pensja;
    }
    public virtual void Przedstaw()
    {
        Console.WriteLine($"Imie: {Imie} {Nazwisko}");
        Console.WriteLine($"Pensja: {Pensja} zl");
    }
    public virtual void Pracuj()
    {
        Console.WriteLine($"{Imie} {Nazwisko} pracuje.");
    }
    public virtual double ObliczPremie()
    {
        return Pensja * 0.1; // domyślnie 10% pensji
    }
}
class Dyrektor : Pracownik
{
    private string dzial;

    public string Dzial
    {
        get => dzial;
        set => dzial = value;
    }

    public Dyrektor(string imie, string nazwisko, double pensja, string dzial) : base(imie, nazwisko, pensja)
    {
        Dzial = dzial;
    }
    public override void Przedstaw()
    {
        Console.WriteLine($"Stanowisko: Dyrektor");
        Console.WriteLine($"Imie:       {Imie} {Nazwisko}");
        Console.WriteLine($"Dzial:      {Dzial}");
        Console.WriteLine($"Pensja:     {Pensja} zl");
    }
    public override void Pracuj()
    {
        Console.WriteLine($"Dyrektor {Imie} {Nazwisko} zarzadza dzialem {Dzial}.");
    }
    public override double ObliczPremie()
    {
        return Pensja * 0.21; // 21% powodzi sie dyrektorowi
    }
}

class Ksiegowy : Pracownik
{
    private string email;

    public string Email
    {
        get => email;
        set => email = value;
    }

    public Ksiegowy(string imie, string nazwisko, double pensja, string email) : base(imie, nazwisko, pensja)
    {
        Email = email;
    }
    public override void Przedstaw()
    {
        Console.WriteLine($"Stanowisko: Księgowy");
        Console.WriteLine($"Imie:       {Imie} {Nazwisko}");
        Console.WriteLine($"Email:      {Email}");
        Console.WriteLine($"Pensja:     {Pensja} zl");
    }
    public override void Pracuj()
    {
        Console.WriteLine($"Księgowy {Imie} {Nazwisko} ma adres email: {Email}.");
    }
    public override double ObliczPremie()
    {
        return Pensja * 0.14; // 14% Ksiegowy trochę mniej
    }
}
class Technik : Pracownik
{
    private string specjalizacja;

    public string Specjalizacja
    {
        get => specjalizacja;
        set => specjalizacja = value;
    }

    public Technik(string imie, string nazwisko, double pensja, string specjalizacja)
        : base(imie, nazwisko, pensja)
    {
        Specjalizacja = specjalizacja;
    }

    public override void Przedstaw()
    {
        Console.WriteLine($"Stanowisko:    Technik");
        Console.WriteLine($"Imie:          {Imie} {Nazwisko}");
        Console.WriteLine($"Specjalizacja: {Specjalizacja}");
        Console.WriteLine($"Pensja:        {Pensja} zl");
    }

    public override void Pracuj()
    {
        Console.WriteLine($"Technik {Imie} {Nazwisko} o specjalizacji: {Specjalizacja}.");
    }
    public override double ObliczPremie()
    {
        return Pensja * 0.7; // 7% no w końcu technik
    }
}

class Program
{
    static List<Pracownik> baza = new List<Pracownik>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== BAZA PRACOWNIKOW ===");
            Console.WriteLine("1. Dodaj dyrektora");
            Console.WriteLine("2. Dodaj ksiegowego");
            Console.WriteLine("3. Dodaj technika");
            Console.WriteLine("4. Wyswietl wszystkich pracownikow");
            Console.WriteLine("5. Zmien pensje pracownika");
            Console.WriteLine("0. Wyjscie");
            Console.Write("\nWybierz opcje: ");

            string wybor = Console.ReadLine();

            try
            {
                switch (wybor)
                {
                    case "1":
                        Console.Write("Imie: ");
                        string i1 = Console.ReadLine();
                        Console.Write("Nazwisko: ");
                        string n1 = Console.ReadLine();
                        Console.Write("Pensja: ");
                        double p1 = double.Parse(Console.ReadLine().Replace(",", "."));
                        Console.Write("Dzial: ");
                        string d1 = Console.ReadLine();
                        baza.Add(new Dyrektor(i1, n1, p1, d1));
                        Console.WriteLine("Dodano dyrektora!");
                        break;

                    case "2":
                        Console.Write("Imie: ");
                        string i2 = Console.ReadLine();
                        Console.Write("Nazwisko: ");
                        string n2 = Console.ReadLine();
                        Console.Write("Pensja: ");
                        double p2 = double.Parse(Console.ReadLine().Replace(",", "."));
                        Console.Write("Email: ");
                        string d2 = Console.ReadLine();
                        baza.Add(new Ksiegowy(i2, n2, p2, d2));
                        Console.WriteLine("Dodano ksiegowego!");
                        break;

                    case "3":
                        Console.Write("Imie: ");
                        string i3 = Console.ReadLine();
                        Console.Write("Nazwisko: ");
                        string n3 = Console.ReadLine();
                        Console.Write("Pensja: ");
                        double p3 = double.Parse(Console.ReadLine().Replace(",", "."));
                        Console.Write("Specjalizacja: ");
                        string d3 = Console.ReadLine();
                        baza.Add(new Technik(i3, n3, p3, d3));
                        Console.WriteLine("Dodano technika!");
                        break;

                    case "4":
                        if (baza.Count == 0)
                        {
                            Console.WriteLine("Baza jest pusta!");
                            break;
                        }
                        Console.WriteLine("\n--- Lista pracownikow ---");
                        for (int i = 0; i < baza.Count; i++)
                        {
                            Console.WriteLine($"\n[{i + 1}]");
                            baza[i].Przedstaw();
                            baza[i].Pracuj();
                            Console.WriteLine($"Premia: {baza[i].ObliczPremie()} zl");
                        }
                        break;

                    case "5":
                        if (baza.Count == 0)
                        {
                            Console.WriteLine("Baza jest pusta!");
                            break;
                        }
                        Console.WriteLine("Wybierz pracownika:");
                        for (int i = 0; i < baza.Count; i++)
                            Console.WriteLine($"{i + 1}. {baza[i].Imie} {baza[i].Nazwisko}");
                        Console.Write("Nr: ");
                        int nr = int.Parse(Console.ReadLine()) - 1;
                        Console.Write("Nowa pensja: ");
                        double nowaPensja = double.Parse(Console.ReadLine().Replace(",", "."),
                            System.Globalization.CultureInfo.InvariantCulture); baza[nr].Pensja = nowaPensja;
                        Console.WriteLine("Pensja zaktualizowana!");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Nieznana opcja!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Blad: {ex.Message}");
            }
            Console.WriteLine("\nNacisnij dowolny klawisz aby wrocic do menu");
            Console.ReadKey();
        }
    }
}