using System;

namespace onikinoktaon
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Shape[] shapes = new Shape[4];
            shapes[0] = new Circle(2);
            shapes[1] = new Cube(5);
            shapes[2] = new Sphere(2);
            shapes[3] = new Square(5);

            for (int i = 0; i < shapes.Length; i++)
            {
                Console.Write("{0}\n", shapes[i].GetType().Name);
                shapes[i].PrintAV();
                Console.Write("\n");
            }
        }
    }

    internal class Circle : TwoDimensionalShape
    {
        internal Circle()
        {}
        
        internal Circle(double diameter) : base(diameter, diameter)
        {}

        internal override double Area
        {
            get
            {
                return Math.PI*Dimensions[0]*Dimensions[0];
            }
        }
    }
    internal class Square : TwoDimensionalShape
    {
        internal Square()
        {}

        internal Square(double side1) : base(side1, side1)
        {}

        internal override double Area
        {
            get
            {
                return Dimensions[0]*Dimensions[1];
            }
        }
    }
    internal class Sphere : ThreeDimensionalShape
    {
        internal Sphere()
        {}

        internal Sphere(double diameter) : base(diameter, diameter, diameter)
        {}

        internal override double Area
        {
            get
            {
                return 4*Math.PI*Dimensions[0]*Dimensions[0];
            }
        }
        internal override double Volume
        {
            get
            {
                return (4/3)*Math.PI*Math.Pow(Dimensions[0],3);
            }
        }
    }
    internal class Cube : ThreeDimensionalShape
    {
        internal Cube()
        {}
        
        internal Cube(double side1) : base(side1, side1, side1)
        {}

        internal override double Area
        {
            get
            {
                return 6*Dimensions[0]*Dimensions[0];
            }
        }

        internal override double Volume
        {
            get
            {
                return Dimensions[0]*Dimensions[1]*Dimensions[2];
            }
        }
    }

    internal abstract class Shape
    {
        internal abstract double[] Dimensions {get; set;}

        internal Shape()
        {}
        internal Shape(params double[] dimensions)
        {
            Dimensions = dimensions;
        }

        internal abstract void PrintAV();
    }

    internal abstract class TwoDimensionalShape : Shape
    {
        internal override double[] Dimensions {get; set;}

        internal TwoDimensionalShape()
        {}
        internal TwoDimensionalShape(double dimension1, double dimension2) : base(dimension1, dimension2)
        {}

        internal abstract double Area {get;}

        internal override void PrintAV()
        {
            Console.Write("Area : {0}\n", Area);
        }
    }

    internal abstract class ThreeDimensionalShape : Shape
    {
        internal override double[] Dimensions {get; set;}

        internal ThreeDimensionalShape()
        {}
        internal ThreeDimensionalShape(double dimension1, double dimension2, double dimension3) :
                        base(dimension1, dimension2, dimension3)
        {}

        internal abstract double Area {get;}
        internal abstract double Volume {get;}

        internal override void PrintAV()
        {
            Console.Write("Area : {0}\nVolume : {1}\n", Area, Volume);
        }
    }
}