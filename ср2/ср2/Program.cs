namespace ср2;
using System;

public abstract class ThreeDShape
{
    protected double height;
    protected double width;
    protected double length;

    protected ThreeDShape(double height, double width, double length)
    {
        this.height = height;              // Инициализация высоты фигуры
        this.width = width;                // Инициализация ширины фигуры
        this.length = length;              // Инициализация длины фигуры
    }

    public abstract double GetSurfaceArea();   // Абстрактный метод для расчета площади поверхности
    public abstract double GetVolume();        // Абстрактный метод для расчета объема

    public override string ToString()
    {
        return $"Height: {height:0.00}; Width: {width:0.00}; Length: {length:0.00}";
    }
}

public class Cube : ThreeDShape
{
    public Cube(double sideLength)
        : base(sideLength, sideLength, sideLength)
    {
    }

    public override double GetSurfaceArea()
    {
        return 6 * length * length;          // Расчет площади поверхности куба
    }

    public override double GetVolume()
    {
        return length * length * length;     // Расчет объема куба
    }

    public override string ToString()
    {
        return $"Cube: {base.ToString()}; Surface Area: {GetSurfaceArea():0.000}; Volume: {GetVolume():0.000}";
    }
}

public class Sphere : ThreeDShape
{
    public Sphere(double radius)
        : base(radius * 2, radius * 2, radius * 2)
    {
    }

    public override double GetSurfaceArea()
    {
        return 4 * Math.PI * Math.Pow(length / 2, 2);    // Расчет площади поверхности сферы
    }

    public override double GetVolume()
    {
        return (4 / 3) * Math.PI * Math.Pow(length / 2, 3);    // Расчет объема сферы
    }

    public override string ToString()
    {
        return $"Sphere: {base.ToString()}; Surface Area: {GetSurfaceArea():0.000}; Volume: {GetVolume():0.000}";
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество Cube: ");
        int cubeCount = int.Parse(Console.ReadLine());

        Console.Write("Введите количество Sphere: ");
        int sphereCount = int.Parse(Console.ReadLine());

        ThreeDShape[] shapes = new ThreeDShape[cubeCount + sphereCount];

        Random random = new Random();

        for (int i = 0; i < cubeCount; i++)
        {
            double sideLength = random.NextDouble() * (10 - 1) + 1;
            shapes[i] = new Cube(sideLength);
        }

        for (int i = cubeCount; i < cubeCount + sphereCount; i++)
        {
            double radius = random.NextDouble() * (10 - 1) + 1;
            shapes[i] = new Sphere(radius);
        }

        foreach (ThreeDShape shape in shapes)
        {
            Console.WriteLine(shape.ToString());
        }

    }
}

