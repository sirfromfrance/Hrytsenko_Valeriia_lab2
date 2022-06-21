using System;
using System.IO;
using System.Text.Json;


namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Fractions f1 = new Fractions(2, 4);
            f1.ReduceFrac();
            Console.WriteLine("reduce fraction");
            f1.Write();
            Console.WriteLine("wether fraction is true");
            Console.WriteLine(f1.trueFrac(1, 4));
            Fractions f2 = new Fractions(4, 6);
            Console.WriteLine("summing fractions");
            Fractions f3 = f1.Sum(f2);
            f3.Write();
            Console.WriteLine("dividing fractions");
            f3 = f1.Dividing(f2);
            f3.Write();
            Console.WriteLine("multiply  fractions");
            f3 = f1.Multiplying(f2);
            f3.Write();
            Console.WriteLine("multiply  fractions");
            f3 = f1.Substraction(f2);
            f3.Write();
            if (f1.Equals(f2))
            {
                Console.WriteLine("The fractions are equal");
            }
            else
            {
                Console.WriteLine("The fractions are not equal");
            }
            Fractions FF = new Fractions(4, 8);
            FF.Save();

            FF.Write();




        }
        class Fractions
        {
            public int A { get; set; }
            public int B { get; set; }
            public void ReduceFrac()
            {
                int x = A;
                int y = B;

                for (int i = 2; x == A; i++)
                {
                    if (x % i == 0 && y % i == 0)
                    {
                        A = x / i;
                        B = y / i;
                    }
                }

            }
            public Fractions(int nom, int den)
            {
                A = nom;
                B = den;
            }
            public void Write()
            {
                Console.WriteLine($"{A}/{B}");
            }
            public bool trueFrac(int a, int b)
            {
                bool n = true;
                if (a > b)
                    n = false;
                return n;

            }
            public Fractions Sum(Fractions frac2)
            {
                Fractions Sm = new Fractions(A * frac2.B + frac2.A * B, B * frac2.B);
                Sm.ReduceFrac();
                return Sm;
            }
            public Fractions Dividing(Fractions frac2)
            {
                Fractions Div = new Fractions(A * frac2.B, B * frac2.A);
                Div.ReduceFrac();
                return Div;
            }
            public Fractions Multiplying(Fractions frac2)
            {
                Fractions Mult = new Fractions(A * frac2.A, B * frac2.B);
                Mult.ReduceFrac();
                return Mult;
            }
            public Fractions Substraction(Fractions frac2)
            {
                Fractions Substr = new Fractions(A * frac2.B - frac2.A * B, B * frac2.B);
                Substr.ReduceFrac();
                return Substr;
            }
            public void Save()
            {
                string Js = JsonSerializer.Serialize(this);
                Console.WriteLine(Js);
                File.WriteAllText(@"D:\fract.json", Js);
            }

        }

    }
}
