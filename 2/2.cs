using System;
Console.WriteLine("=== Работа с рациональными дробями ===");

Console.Write("Введите числитель первой дроби: ");
int a = int.Parse(Console.ReadLine()!);
Console.Write("Введите знаменатель первой дроби: ");
int b = int.Parse(Console.ReadLine()!);

Console.Write("Введите числитель второй дроби: ");
int c = int.Parse(Console.ReadLine()!);
Console.Write("Введите знаменатель второй дроби: ");
int d = int.Parse(Console.ReadLine()!);

Rational plus = new Rational(a, b, c, d);
string sum = plus.Sum();
Console.WriteLine($"{a}/{b} + {c}/{d} = {sum}");
string sub = plus.Sub();
Console.WriteLine($"{a}/{b} - {c}/{d} = {sub}");
string mul = plus.Mul();
Console.WriteLine($"{a}/{b} * {c}/{d} = {mul}");
string div = plus.Div();
Console.WriteLine($"{a}/{b} / {c}/{d} = {div}");
string srav = plus.Srav();
Console.WriteLine(srav);

abstract class Drobi
{
    public abstract string Sum();
    public abstract string Sub();
    public abstract string Mul();
    public abstract string Div();
    public abstract string Srav();
}

class Rational : Drobi
{
    private double a; private double b; private double c; private double d;
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
    public double D
    {
        get { return d; }
        set { d = value; }
    }
    public Rational(double A, double B, double C, double D)
    {
        this.A = A;
        this.B = B;
        this.C = C;
        this.D = D;
    }

    public override string Sum()
    {
        double numerator = A * D + C * B;
        double denominator = B * D;
        return Reduce(numerator, denominator);
    }
    public override string Sub()
    {
        double numerator = A * D - C * B;
        double denominator = B * D;
        return Reduce(numerator, denominator);
    }
    public override string Mul()
    {
        double numerator = A * C;
        double denominator = B * D;
        return Reduce(numerator, denominator);
    }
    public override string Div()
    {
        double numerator = A * D ;
        double denominator = B * C;
        return Reduce(numerator, denominator);
    }
    public override string Srav()
    {
        double drob1 = (double)A / B;
        double drob2 = (double)C / D;

        if (drob1 < drob2)
        {
            return $"{A}/{B} < {C}/{D}";
        }
        else if (drob2 < drob1)
        {
            return $"{A}/{B} > {C}/{D}";
        }
        else
        {
            return $"{A}/{B} = {C}/{D}";
        }
    }
    private string Reduce(double numerator, double denominator)
    {
        double gcd = GCD((int)Math.Abs(numerator), (int)Math.Abs(denominator));
        numerator /= gcd;
        denominator /= gcd;
        return $"{numerator}/{denominator}";
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}