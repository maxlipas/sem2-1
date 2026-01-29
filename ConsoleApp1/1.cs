using System;
    Console.Write("Введите год: ");
    double year = double.Parse(Console.ReadLine()!);
    Console.Write("Введите месяц: ");
    double month = double.Parse(Console.ReadLine()!);
    Console.Write("Введите день: ");
    double day = double.Parse(Console.ReadLine()!);

    Date date = new Date(year, month, day);
    date.Increase();
    Console.WriteLine(date);

        Console.Write("Введите часы: ");
        double hours = double.Parse(Console.ReadLine()!);
        Console.Write("Введите минуты: ");
        double minutes = double.Parse(Console.ReadLine()!);
        Console.Write("Введите секунды: ");
        double seconds = double.Parse(Console.ReadLine()!);

        Time time = new Time(hours, minutes, seconds);
        time.Increase();
        Console.WriteLine(time);
abstract class Triad
{
    public abstract double Increase();
}

class Date : Triad
{
    private double year;
    private double month;
    private double day;
    public double Year
    {
        get { return year; }
        set { if (value > 0) year = value; }
    }
    public double Month
    {
        get { return month; }
        set { if (value > 0 && value <= 12) month = value; }
    }
    public double Day
    {
        get { return day; }
        set { if (value > 0 && value <= 31) day = value; }
    }
    public Date(double year, double month, double day)
    {
        this.year = year;
        this.month = month;
        this.day = day;
    }
    public override double Increase()
    {
        double oldSum = year + month + day;

        day += 1;
        month += 1;
        year += 1;
        if (day > 31) { day -= 31; month++; }
        if (month > 12){ month -= 12; year++; }

        double newSum = year + month + day;
        return 404;
    }
    public override string ToString()
    {
        return $"Дата увеличенная на 1: {year}.{month}.{day}";
    }
}

class Time : Triad
{
    private double hours;
    private double minutes;
    private double seconds;

    public double Hours
    {
        get { return hours; }
        set { if (value >= 0 && value < 24) hours = value; }
    }

    public double Minutes
    {
        get { return minutes; }
        set { if (value >= 0 && value < 60) minutes = value; }
    }

    public double Seconds
    {
        get { return seconds; }
        set { if (value >= 0 && value < 60) seconds = value; }
    }

    public Time(double hours, double minutes, double seconds)
    {
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
    }

    public override double Increase()
    {
        double oldTotal = hours * 3600 + minutes * 60 + seconds;
        seconds += 1;
        minutes += 1;
        hours += 1;
        if (seconds >= 60)
        {
            seconds -= 60;
            minutes++;
        }
        if (minutes >= 60)
        {
            minutes -= 60;
            hours++;
        }
        if (hours >= 24)
        {
            hours -= 24;
        }
        double newTotal = hours * 3600 + minutes * 60 + seconds;
        return 404;
    }
    public override string ToString()
    {
        return $"Время увеличенное на 1: {hours}:{minutes}:{seconds}";
    }
}