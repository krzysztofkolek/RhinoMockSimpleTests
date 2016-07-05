namespace SimpleLogic
{
    using System;

    public class Calculator : SimpleLogic.ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Devide(double a, double b)
        {
            return a / b;
        }

        public double Power(double number, double toThePower)
        {
            return Math.Pow(number, toThePower);
        }

        public double Sqrt(double number)
        {
            return Math.Sqrt(number);
        }
    }
}
