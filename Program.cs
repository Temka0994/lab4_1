using System;

class TTriangle
{
    private double a, b, c;

    public TTriangle()
    {
        a = b = c = 0;          
    }

    public TTriangle(double sideA, double sideB, double sideC)
    {
        if (IsValidTriangle(sideA, sideB, sideC))
        {
            a = sideA;
            b = sideB; 
            c = sideC;
        }
        else
        {
            throw new ArgumentException("Неможливо створити трикутник із заданими сторонами.");
        }
    }

    public TTriangle(TTriangle otherTriangle)
    {
        a = otherTriangle.a;
        b = otherTriangle.b;
        c = otherTriangle.c;
    }

    public double A
    {
        get { return a; }
        set { a = value; }
    }

    public double B
    {
        get { return b; }
        set { b = value; }
    }

    public double C
    {
        get { return c; }
        set { c = value; }
    }

    public void Input()
    {
        Console.Write("Введiть сторону A: ");
        a = double.Parse(Console.ReadLine());
        Console.Write("Введiть сторону B: ");
        b = double.Parse(Console.ReadLine());
        Console.Write("Введiть сторону C: ");
        c = double.Parse(Console.ReadLine());

        if (!IsValidTriangle(a, b, c))
        {
            throw new ArgumentException("Неможливо створити трикутник iз введеними сторонами.");
        }
    }

    public void Display()
    {
        Console.WriteLine($"Сторона A: {a}, Сторона B: {b}, Сторона C: {c}");
    }

    public double GetArea()
    {
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    public double GetPerimeter()
    {
        return a + b + c;
    }

    public bool IsEqual(TTriangle otherTriangle)
    {
        return a == otherTriangle.a && b == otherTriangle.b && c == otherTriangle.c;
    }

    public static bool operator ==(TTriangle triangle1, TTriangle triangle2)
    {
        return triangle1.IsEqual(triangle2);
    }

    public static bool operator !=(TTriangle triangle1, TTriangle triangle2)
    {
        return !triangle1.IsEqual(triangle2);
    }

    public static TTriangle operator +(TTriangle triangle1, TTriangle triangle2)
    {
        return new TTriangle(triangle1.A + triangle2.A, triangle1.B + triangle2.B, triangle1.C + triangle2.C);
    }

    public static TTriangle operator -(TTriangle triangle1, TTriangle triangle2)
    {
        return new TTriangle(triangle1.A - triangle2.A, triangle1.B - triangle2.B, triangle1.C - triangle2.C);
    }

    public static TTriangle operator *(TTriangle triangle, double multiplier)
    {
        return new TTriangle(triangle.A * multiplier, triangle.B * multiplier, triangle.C * multiplier);
    }

    private static bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }
}

class TTrianglePrizm : TTriangle
{
    private double height;

    public TTrianglePrizm(double sideA, double sideB, double sideC, double prizmHeight) : base(sideA, sideB, sideC)
    {
        height = prizmHeight;
    }

    public double GetVolume()
    {
        return GetArea() * height;
    }

    public new void Display()
    {
        base.Display();
        Console.WriteLine($"Висота призми: {height}");
    }
}

class Program
{
    static void Main()
    {
        TTriangle triangle1 = new TTriangle();
        triangle1.Input();

        TTriangle triangle2 = new TTriangle(3, 4, 5);

        Console.WriteLine("\nТрикутник 1:");
        triangle1.Display();
        Console.WriteLine($"Площа: {triangle1.GetArea()}");
        Console.WriteLine($"Периметр: {triangle1.GetPerimeter()}");

        Console.WriteLine("\nТрикутник 2:");
        triangle2.Display();
        Console.WriteLine($"Площа: {triangle2.GetArea()}");
        Console.WriteLine($"Периметр: {triangle2.GetPerimeter()}");

        Console.WriteLine("\nПорівняння трикутникiв:");
        if (triangle1 == triangle2)
        {
            Console.WriteLine("Трикутники рiвнi.");
        }
        else
        {
            Console.WriteLine("Трикутники не рiвнi.");
        }

        Console.WriteLine("\nДодавання трикутникiв:");
        TTriangle sumTriangle = triangle1 + triangle2;
        sumTriangle.Display();

        Console.WriteLine("\nВіднімання трикутникiв:");
        TTriangle diffTriangle = triangle1 - triangle2;
        diffTriangle.Display();

        Console.WriteLine("\nМноження трикутника:");
        TTriangle multipliedTriangle = triangle1 * 2;
        multipliedTriangle.Display();

        Console.WriteLine("\nСтворення призми на основi трикутника 1:");
        TTrianglePrizm prizm = new TTrianglePrizm(triangle1.A, triangle1.B, triangle1.C, 6);
        prizm.Display();
        Console.WriteLine($"Об'єм призми: {prizm.GetVolume()}");
    }
}
