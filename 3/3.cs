using System;

Console.Write("Введите год: ");
int year = int.Parse(Console.ReadLine()!);
Console.Write("Введите месяц: ");
int month = int.Parse(Console.ReadLine()!);
Console.Write("Введите день: ");
int day = int.Parse(Console.ReadLine()!);

Date date = new Date(year, month, day);
date.Increase();
Console.WriteLine(date);

Console.Write("Введите часы: ");
int hours = int.Parse(Console.ReadLine()!);
Console.Write("Введите минуты: ");
int minutes = int.Parse(Console.ReadLine()!);
Console.Write("Введите секунды: ");
int seconds = int.Parse(Console.ReadLine()!);

Time time = new Time(hours, minutes, seconds);
time.Increase();
Console.WriteLine(time);

interface Triad
{
    int Increase();
}

class Date : Triad
{
    private int year;
    private int month;
    private int day;

    public int Year
    {
        get { return year; }
        set { if (value > 0) year = value; }
    }

    public int Month
    {
        get { return month; }
        set { if (value > 0 && value <= 12) month = value; }
    }

    public int Day
    {
        get { return day; }
        set { if (value > 0 && value <= 31) day = value; }
    }

    public Date(int year, int month, int day)
    {
        this.year = year;
        this.month = month;
        this.day = day;
    }

    public int Increase()
    {
        day += 1;
        month += 1;
        year += 1;

        if (day > 31) { day -= 31; month++; }
        if (month > 12) { month -= 12; year++; }

        return 404;
    }

    public override string ToString()
    {
        return $"Дата увеличенная на 1: {year}.{month}.{day}";
    }
}

class Time : Triad
{
    private int hours;
    private int minutes;
    private int seconds;

    public int Hours
    {
        get { return hours; }
        set { if (value >= 0 && value < 24) hours = value; }
    }

    public int Minutes
    {
        get { return minutes; }
        set { if (value >= 0 && value < 60) minutes = value; }
    }

    public int Seconds
    {
        get { return seconds; }
        set { if (value >= 0 && value < 60) seconds = value; }
    }

    public Time(int hours, int minutes, int seconds)
    {
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
    }

    public int Increase()
    {
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

        return 404;
    }

    public override string ToString()
    {
        return $"Время увеличенное на 1: {hours}:{minutes}:{seconds}";
    }
}