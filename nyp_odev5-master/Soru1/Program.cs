using System;


namespace Workspace
{
    public class Hemisphere
    {
        private double radius = 1;
        public double Radius
        {
            get{return radius;}

            set
            {
                if(value > 0 && value < 12)
                {
                    radius = value;
                }
            }
        }

        private double volume;
        public double Volume
        {
            get
            {
                volume = (1*this.radius*this.radius*this.radius*Math.PI)/3;
                return volume;
            }
        }
        

        private double curvedSurfaceArea;
        public double CurvedSurfaceArea
        {
            get
            {
                curvedSurfaceArea = this.radius*this.radius*Math.PI;
                return curvedSurfaceArea;
            }
        }

        private double totalSurfaceArea;
        public double TotalSurfaceArea
        {
            get
            {
                totalSurfaceArea = this.radius*this.radius*Math.PI*3;
                return totalSurfaceArea;
            }
        }
        
        internal Hemisphere()
        {}
    }
    public class Program
    {
        internal static void Main()
        {
            Hemisphere hemisphere1 = new Hemisphere();

            Hemisphere hemisphere2 = new Hemisphere();
            hemisphere2.Radius = 8;

            //hemisphere1.Radius = 13;

            Console.WriteLine("Volume1:            {0}  ||  Volume2:            {1}",hemisphere1.Volume,hemisphere2.Volume);
            Console.WriteLine("CurvedSurfaceArea1: {0}   ||  CurvedSurfaceArea2: {1}",hemisphere1.CurvedSurfaceArea,hemisphere2.CurvedSurfaceArea);
            Console.WriteLine("TotalSurfaceArea1:  {0}    ||  TotalSurfaceArea2:  {1}",hemisphere1.TotalSurfaceArea,hemisphere2.TotalSurfaceArea);

            //hemisphere1.Volume = 12;  
        }
    }
}