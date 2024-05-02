//NULLABLE IS DISABLED
using System;
using System.Linq;

namespace Odev
{
    internal class Invoice
    {
        internal int PartNumber;
        internal string PartDescription;
        internal int Quantity;
        internal decimal Price;
        internal Invoice(int PartNumber,string PartDescription,int Quantity,decimal Price)
        {
            this.PartNumber = PartNumber;
            this.PartDescription = PartDescription;
            this.Quantity = Quantity;
            this.Price = Price;
        }
    }
    
    internal class Program
    {
        internal static void Main()
        {
            Invoice[] arrayOfInvoice = new Invoice[8];

            arrayOfInvoice[0]=new Invoice(83,"Electric sander",7,(decimal)57.98);
            arrayOfInvoice[1]=new Invoice(24,"Power saw",24,(decimal)99.99);
            arrayOfInvoice[2]=new Invoice(7,"Sledge hammer",11,(decimal)21.50);
            arrayOfInvoice[3]=new Invoice(77,"Hammer",76,(decimal)11.99);
            arrayOfInvoice[4]=new Invoice(39,"Lawn mower",3,(decimal)79.50);
            arrayOfInvoice[5]=new Invoice(68,"Screwdriver",106,(decimal)6.99);
            arrayOfInvoice[6]=new Invoice(56,"Jig saw",21,(decimal)11.00);
            arrayOfInvoice[7]=new Invoice(3,"Wrench",34,(decimal)7.50);

            IEnumerable<Invoice> sortedBYdescription = 
            from invoice in arrayOfInvoice orderby invoice.PartDescription ascending select invoice;
            Console.Write("\nObjects sorted by part description\n");
            foreach (Invoice invoice in sortedBYdescription)
            {
                Console.WriteLine($"{invoice.PartNumber} - {invoice.PartDescription} - {invoice.Quantity} - {invoice.Price}");
            }

            IEnumerable<Invoice> sortedBYprice = 
            from invoice in arrayOfInvoice orderby invoice.Price ascending select invoice;
            Console.Write("\nObjects sorted by price\n");
            foreach (Invoice invoice in sortedBYprice)
            {
                Console.WriteLine($"{invoice.PartNumber} - {invoice.PartDescription} - {invoice.Quantity} - {invoice.Price}");
            }

            var sortedBYquantity = 
            from invoice in arrayOfInvoice orderby invoice.Quantity ascending
            select new {invoice.PartDescription, invoice.Quantity};
            Console.Write("\nObjects sorted by quantity\n");
            foreach (var invoice in sortedBYquantity)
            {
                Console.WriteLine($"{invoice.PartDescription} - {invoice.Quantity}");
            }

            var sortedBYvalue = 
            from invoice in arrayOfInvoice let InvoiceTotal = invoice.Quantity*invoice.Price
            orderby InvoiceTotal ascending select new {invoice.PartDescription, InvoiceTotal};
            Console.Write("\nObjects sorted by value\n");
            foreach (var invoice in sortedBYvalue)
            {
                Console.WriteLine($"{invoice.PartDescription} - {invoice.InvoiceTotal}");
            }

            var selectBYvalue = 
            from invoice in sortedBYvalue
            where invoice.InvoiceTotal >= 200 && invoice.InvoiceTotal <= 500
            select invoice;
            Console.Write("\nObjects selected by value\n");
            foreach (var invoice in selectBYvalue)
            {
                Console.WriteLine($"{invoice.PartDescription} - {invoice.InvoiceTotal}");
            }
        }
    }
}
