using System;

namespace Workspace
{
    internal class Program
    {
        internal static void Main()
        {
            /*
            Rational rt1 = new Rational(154,217);

            Rational rt2 = new Rational(42,156);

            Rational rt3 = new Rational();
            rt3 = Rational.Add(rt1, rt2);
            
            Rational rt4 = new Rational();
            rt4 = Rational.Substract(rt1, rt2);
            
            Rational rt5 = new Rational();
            rt5 = Rational.Multiply(rt1, rt2);
            
            Rational rt6 = new Rational();
            rt6 = Rational.Divide(rt1, rt2);
            
            rt1.Display();
            rt2.Display();
            rt3.Display();
            rt4.Display();
            rt5.Display();
            rt6.Display();
            rt6.DisplayFloatingPoint(3);

            Rational rt7 = new Rational();
            rt7.Display();
            */
        }
    }

    internal class Rational
    {
        private int numerator;

        private int denominator;

        internal Rational()
        {
            this.numerator  = 2;
            this.denominator = 3;
        }

        internal Rational(int numerator, int denominator)
        {
            if(numerator > denominator)
            {
                for(int i = 2; i<numerator; i++)
                {
                    if(numerator%i == 0 && denominator%i == 0)
                    {
                        numerator = numerator/i;
                        denominator = denominator/i;
                        i = 1;
                    }
                }
            }
            else if(numerator < denominator)
            {
                for(int i = 2; i<denominator; i++)
                {
                    if(numerator%i == 0 && denominator%i == 0)
                    {
                        numerator = numerator/i;
                        denominator = denominator/i;
                        i = 1;
                    }
                }  
            }

            this.numerator = numerator;
            this.denominator = denominator;
        }

        public void Display()
        {
            Console.WriteLine("{0}/{1}",this.numerator,this.denominator);
        }

        public void DisplayFloatingPoint(int precisionLimit)
        {
            double result = (double)  ((double)this.numerator/(double) this.denominator);
            
            Console.WriteLine("{0}",Math.Round(result, precisionLimit));
        }

        public static Rational Add(Rational number1, Rational number2)
        {
            int new_numerator;
            int new_denominator;

            int temp_number1_numerator = number1.numerator;
            int temp_number1_denominator = number1.denominator;

            int temp_number2_numerator = number2.numerator;
            int temp_number2_denominator = number2.denominator;
            

            if(number1.denominator == number2.denominator)
            {
                new_numerator = temp_number1_numerator + temp_number2_numerator;
                new_denominator = temp_number1_denominator;
            }
            else
            {
                temp_number1_numerator = temp_number1_numerator * temp_number2_denominator;
                temp_number2_numerator = temp_number2_numerator * temp_number1_denominator;
                int temp = temp_number1_denominator;
                temp_number1_denominator = temp_number1_denominator * temp_number2_denominator;
                temp_number2_denominator = temp_number2_denominator * temp;

                new_numerator = temp_number1_numerator + temp_number2_numerator;
                new_denominator = temp_number1_denominator;
            }

            Rational result = new Rational(new_numerator, new_denominator);

            return result;
        }

        public static Rational Substract(Rational number1, Rational number2)
        {
            int new_numerator;
            int new_denominator;

            int temp_number1_numerator = number1.numerator;
            int temp_number1_denominator = number1.denominator;

            int temp_number2_numerator = number2.numerator;
            int temp_number2_denominator = number2.denominator;
            

            if(number1.denominator == number2.denominator)
            {
                new_numerator = temp_number1_numerator - temp_number2_numerator;
                new_denominator = temp_number1_denominator;
            }
            else
            {
                temp_number1_numerator = temp_number1_numerator * temp_number2_denominator;
                temp_number2_numerator = temp_number2_numerator * temp_number1_denominator;
                int temp = temp_number1_denominator;
                temp_number1_denominator = temp_number1_denominator * temp_number2_denominator;
                temp_number2_denominator = temp_number2_denominator * temp;

                new_numerator = temp_number1_numerator - temp_number2_numerator;
                new_denominator = temp_number1_denominator;
            }

            Rational result = new Rational(new_numerator, new_denominator);

            return result;
        }
        
        
        public static Rational Multiply(Rational number1, Rational number2)
        {
            int new_numerator;
            int new_denominator;

            new_numerator = number1.numerator * number2.numerator;
            new_denominator = number1.denominator * number2.denominator;

            
            Rational result = new Rational(new_numerator, new_denominator);

            return result;
        }

        public static Rational Divide(Rational number1, Rational number2)
        {
            int new_numerator;
            int new_denominator;

            new_numerator = number1.numerator * number2.denominator;
            new_denominator = number1.denominator * number2.numerator;

            
            Rational result = new Rational(new_numerator, new_denominator);

            return result;
        }
    }
}