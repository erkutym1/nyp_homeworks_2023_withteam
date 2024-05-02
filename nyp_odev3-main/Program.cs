// See https://aka.ms/new-console-template for more information
internal class Diomond
{
    internal static int Main()
    {
        int dioSize= 9;
        char ast= '*';
        char spc= ' ';
        int i=dioSize;
        /*for(int i=dioSize;i>=-dioSize;i-=2)
        {
            while(i>0)
            {
                for(int j=i;j>(i+1)/2;j--)
                {
                    Console.Write($"{spc}");
                }
                for(int k=0;k<dioSize-i+1;k++)
                {
                    Console.Write($"{ast}");
                }
                Console.Write("\n");
                Console.Write("\n{0}",i);
            }
            while(i<0)
            {
                for(int j=1;j>-i)
            } 
        }*/
            while(i>0)
            {
                for(int j=i;j>(i+1)/2;j--)
                {
                    Console.Write($"{spc}");
                }
                for(int k=0;k<dioSize-i+1;k++)
                {
                    Console.Write($"{ast}");
                }
                Console.Write("\n");
                i-=2;
            }
            while(i>=-dioSize)
            {
                for(int j=1;j<(-i+3)/2;j++)
                {
                    Console.Write($"{spc}");
                }
                for(int k=0;k<dioSize+i-1;k++)
                {
                    Console.Write($"{ast}");
                }
                Console.Write("\n");
                i-=2;
            }
        return 0;
    }
}
