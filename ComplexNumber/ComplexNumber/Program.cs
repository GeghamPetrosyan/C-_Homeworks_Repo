using System;

namespace ComplexNumber
{
    public class Complex
    {
        public double Real;
        public double Imaginary;

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public double AbsoluteValue()
        {
            return Math.Sqrt(Real * Real + Imaginary * Imaginary);
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        public static Complex operator *(Complex c, double scalar)
        {
            return new Complex(c.Real * scalar, c.Imaginary * scalar);
        }

        public static implicit operator double(Complex c)
        {
            return c.Real;
        }

        public static explicit operator int(Complex c)
        {
            return (int)c.Real;
        }

        public override string ToString()
        {
            if (Imaginary >= 0)
            {
                string resString;
                resString = Real.ToString() + "+" + Imaginary.ToString() + "i";
                return resString;
            }
            else
            {
                string resString;
                resString = Real.ToString() + Imaginary.ToString() + "i";
                return resString;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex complexNumber_1 = new Complex(3, 4);
            Complex complexNumber_2 = new Complex(-6, -9);

            Console.WriteLine(complexNumber_1.ToString());
            Console.WriteLine(complexNumber_2.ToString());



            Console.Write("Absolute value of complexNumber_1: ");
            Console.WriteLine(complexNumber_1.AbsoluteValue());
            Console.Write("Absolute value of complexNumber_2: ");
            Console.WriteLine(complexNumber_2.AbsoluteValue());

            Complex complexNumber_3 = complexNumber_1 + complexNumber_2;
            Console.WriteLine(complexNumber_3.ToString());

            Complex complexNumber_4 = complexNumber_1 - complexNumber_2;
            Console.WriteLine(complexNumber_4.ToString());

            double scalar = 3;
            Complex complexNumber_5 = complexNumber_1 * scalar;
            Console.WriteLine(complexNumber_5.ToString());

            double dubleRealPart = complexNumber_1;
            Console.WriteLine(dubleRealPart);
            int intRealPart = (int)complexNumber_2;
            Console.WriteLine(intRealPart);


        }
    }
}
