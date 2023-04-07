// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Numerics;

class Program
{
    Random r;

    public static void Main(string[] args)
    {
        var p = new Program();

        Vector3 vec = new Vector3(3, 5, 7);
        
        var s = Console.ReadLine();
        var wh = s?.Split(' ').Select(x =>
        {
            int.TryParse(x, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result);
            return result;
        }).ToArray();
        /*
        List<Publication> publications = new List<Publication>();
        
        publications.Add(new Publication());
        publications.Add(new Anouncment());
        publications.Add(new Article());
        publications.Add(new News());

        foreach (var publication in publications)
        {
            publication.PostPublication();
        }*/

        while (true)
        {
            var cki = Console.ReadKey();
            Console.WriteLine(cki.KeyChar.ToString().ToUpper());
            Console.Clear();
            Draw();
        }
    }

    static void Draw()
    {
        Console.WriteLine("!!!!!!!!!!!!!");
        Console.WriteLine("!           !");
        Console.WriteLine("!           !");
        Console.WriteLine("!!!!!!!!!!!!!");
    }
    public void Proc20()
    {
        Console.WriteLine(TriangleP(5, 10));   
        Console.WriteLine(TriangleP(10, 5));   
        Console.WriteLine(TriangleP(3, 2.6f));   
    }


    public static void Tmp(int a)
    {
        var b = a switch
        {
            < 0 => -1,
            0 => 0,
            > 1 => 1,
        };

        switch (a)
        {
            case int tmp when a<0:
                break;
            
        }

    }
    public float TriangleP(float a, float h)
    {
        return (float)Math.Sqrt((a / 2) * (a / 2) + h * h);
    }

    public void Proc21(int a, int b, int c)
    {
        Console.WriteLine(SumRange(a, b));   
        Console.WriteLine(SumRange(b, c));   
        Console.WriteLine(SumRange(a, c));   
    }

    public int SumRange(int a, int b)
    {
        int counter = 0;
        if (a < b)
        {
            counter = (a + b) * (b - a + 1) / 2;
        }

        return counter;
    }

    public void Proc18(int a, int b, int c)
    {
        Console.WriteLine(CircleS(5));
        Console.WriteLine(CircleS(1.5f));
        Console.WriteLine(CircleS(15));
    }

    public float CircleS(float r)
    {
        return (float)Math.PI * r * r;
    }
    
    

    public void Proc24(int[] a)
    {
        int counter = 0;
        foreach (var num in a)
        {
            counter += (Even(num) ? 1 : 0);
        }
    }

    public bool Even(int k)
    {
        return k % 2 == 0;
    }

    public void Proc16(float a, float b)
    {
        var tmp = Sign(a) + Sign(b);
    }

    public int Sign(float x)
    {
        return x switch
        {
            < 0 => -1,
            0 => 0,
            > 0 => 1,
            _ => throw new ArgumentOutOfRangeException(nameof(x), x, null)
        };
    }

    public void Proc19(float[] r1, float[] r2)
    {
        for (int i = 0; i < r1.Length; i++)
        {
            RingS(r1[i], r2[i]);
        }
    }

    public float RingS(float r1, float r2)
    {
        if (r1 < r2)
            return 0;

        return CircleS(r1) - CircleS(r2);
    }
    
    //16, 19, 24
}

struct Vector3
{

    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }
    
    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Vector3() : this(0, 0, 0)
    {
    }

    public void WriteVector()
    {
        Console.WriteLine($"({X}, {Y}, {Z})");
    }

    public static Vector3 Zero()
    {
        return new Vector3(0, 0, 0);
    }
    
    public static Vector3 One()
    {
        return new Vector3(1, 1, 1);
    }
    
    public static Vector3 PositiveInfinity()
    {
        return new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
    }

    private float SquaredMagnitude()
    {
        return (X * X + Y * Y + Z * Z);
    }
    
    public float Magnitude()
    {
        return (float)Math.Sqrt(this.SquaredMagnitude());
    }
    

    public Vector3 Normalize()
    {
        var magnitude = Magnitude();
        if(magnitude != 0)
            return this / magnitude;
        return Zero();
    }


    public override bool Equals(object? obj)
    {
        return obj is Vector3 other && this == other;
    }
    

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

    #region Add
    public static Vector3 operator +(Vector3 vector, float other)
    {
        return new Vector3(vector.X+other, vector.Y+other, vector.Z+other);
    }
    public static Vector3 operator +(Vector3 vector, Vector3 other)
    {
        return new Vector3(vector.X+other.X, vector.Y+other.Y, vector.Z+other.Z);
    }
    #endregion
    
    #region Substract
    public static Vector3 operator -(Vector3 vector, float other)
    {
        return vector + (-other);;
    }
    public static Vector3 operator -(Vector3 vector, Vector3 other)
    {
        return vector + (-other);
    }
    public static Vector3 operator -(Vector3 vector)
    {
        return new Vector3(-vector.X, -vector.Y, -vector.Z);
    }
    #endregion
    
    #region Multiply
    public static Vector3 operator *(Vector3 vector, float other)
    {
        return new Vector3(vector.X*other, vector.Y*other, vector.Z*other);
    }
    public static Vector3 operator *(Vector3 vector, Vector3 other)
    {
        return new Vector3(vector.X*other.X, vector.Y*other.Y, vector.Z*other.Z);
    }
    #endregion
    
    #region Divide
    public static Vector3 operator /(Vector3 vector, float other)
    {
        return other != 0 ? new Vector3(vector.X/other, vector.Y/other, vector.Z/other) : Zero();
    }
    public static Vector3 operator /(Vector3 vector, Vector3 other)
    {
        if (other.X == 0 || other.Y == 0 || other.Z == 0)
            return Zero();
        return new Vector3(vector.X/other.X, vector.Y/other.Y, vector.Z/other.Z);
    }
    #endregion
    
    #region Bools
    public static bool operator ==(Vector3 vector, Vector3 other)
    {
        return (AdditionalMethods.EqualFloats(vector.X, other.X)
                &&AdditionalMethods.EqualFloats(vector.Y, other.Y)
                &&AdditionalMethods.EqualFloats(vector.Z, other.Z));
    }
    public static bool operator !=(Vector3 vector, Vector3 other)
    {
        return !(vector == other);
    }
    #endregion
    
    
    
    
    
    
    
    
    
    
    
    
}





internal static class AdditionalMethods
{
    public static float FloatMargin { get; private set; } = 0.01f;

    public static bool EqualFloats(float first, float other)
    {
        return Math.Abs(first - other) < FloatMargin;
    }
    #region Fibonachi
    public static int Fibonachi(int n)
    {
        if (n == 0 || n == 1) return n;

        return Fibonachi(n - 1) + Fibonachi(n - 2);
    }
    public static int Fibonachi(int a, int n)
    {
        return Fibonachi(n) - Fibonachi(a);
    }
    #endregion
}

struct Damage
{
    private float _physicalDamage;
    private float _fireDamage;
    private float _magicDamage;
    private float _tmp = 5;

    public Damage(float pd, float fd, float md = 1)
    {
        _physicalDamage = pd;
        _fireDamage = fd;
        _magicDamage = md;
    }
    public Damage()
    {
        _physicalDamage = 0;
        _fireDamage = 0;
        _magicDamage = 0;
    }
    public Damage(float pd, float fd, float md, float tmp)
    {
        _physicalDamage = pd;
        _fireDamage = fd;
        _magicDamage = md;
        _tmp = tmp;
    }


    public static Damage operator +(Damage damage, Damage other)
    {
        return new Damage(damage._physicalDamage + other._physicalDamage, damage._fireDamage + other._fireDamage,
            damage._magicDamage + other._magicDamage);
    }

    private float SumOfDamage()
    {
        return _physicalDamage + _fireDamage + _magicDamage;
    }

    public static float AvarageDamage(Damage dmg)
    {
        return dmg.SumOfDamage() / 3;
    }


    public float GetPhysicalDamage()
    {
        return _physicalDamage;
    }
    
    public static Damage Zero()
    {
        return new Damage(0,0,0);
    }
    
    
}


interface ITakable
{
    int mass { get; set; }
    void TakeIteam();
}
abstract class Item
{
    public int i1;
    protected int i2;
    private int i3;

    
}
class Weapon : Item, ITakable
{
    private Damage dmg;
    
    public void tv()
    {
        Console.WriteLine(i1);
        Console.WriteLine(i2);
    }
    
    public int mass { get; set; }
    
    public void TakeIteam()
    {
        throw new NotImplementedException();
    }
}
class Food : Item, ITakable
{
    public int mass { get; set; }
    
    public void TakeIteam()
    {
        throw new NotImplementedException();
    }
}
class Person
{
    private Item _item;
    
    
    public void tv()
    {
        Console.WriteLine(_item.i1);
    }
}



abstract class Publication
{
    public string title;


    public void PostPublication()
    {
        Console.WriteLine(title);
    }
}
class News : Publication
{

    public string text;
    public int date;
    public void PostPublication()
    {
        Console.WriteLine(title);
        Console.WriteLine(date);
        Console.WriteLine(text);
    }
}
class Article : Publication
{
    public string text;
    
    public void PostPublication()
    {
        Console.WriteLine(title);
        Console.WriteLine(text);
    }
}
class Anouncment : Publication
{
    public string text;
    public int upToDate;
    
    public void PostPublication()
    {
        Console.WriteLine(title);
        Console.WriteLine(upToDate);
        Console.WriteLine(text);
    }
}
