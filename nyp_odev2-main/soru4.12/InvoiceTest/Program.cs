using System;
using iTextSharp.text;
using iTextSharp.text.pdf;

internal class Invoice    // we created a class for Invoice elements
{
    private string part_number;
    internal string PartNumber
    {
        get => part_number;
        set => part_number = value;
    }

    private string part_description;
    internal string PartDescription
    {
        get => part_description;
        set => part_description = value;
    }

    private decimal item_price;
    internal decimal PricePerItem
    {
        get
        {
            return item_price;
        }
        set
        {
            if (value >= 0)
                item_price = value;
        }
    }

    private int quantity;
    internal int Quantity 
    {
        get
        {
            return quantity;
        }
        set
        {
            if (value >= 0)
                quantity = value;
        }
    }

    internal Invoice(string PartNumber, string PartDescription, double PricePerItem, int Quantity)
    {

        this.PartNumber = PartNumber;
        this.PartDescription = PartDescription;
        this.PricePerItem = Convert.ToDecimal(PricePerItem);
        this.Quantity = Quantity;
    }

    protected internal decimal GetInvoiceAmount() // we created a method to calculate the price for each item sold
    {
        return item_price * (decimal)quantity;
    }

    protected internal void PrintItemInfo() // we created a method to show the item informations
    {
        Console.WriteLine(part_number + " - " + part_description + " - " + item_price + " USD");
    }

    public override string ToString()
    {
        return $"{part_number} - {part_description} - {quantity} pcs * {item_price} USD" +
                 $"= {this.GetInvoiceAmount()} USD";
    }
}


public class Program
{
    public static void Main()
    {
        Invoice[] products = new Invoice[10];
        products[0] = new Invoice("P001", "Aluminium Carabiner", 0.40, 0);
        products[1] = new Invoice("P002", "Stainless Steel Corner Bracket", 0.12, 0);
        products[2] = new Invoice("P003", "Work Gloves", 0.45, 0);
        products[3] = new Invoice("P004", "Plastic Chain", 0.20, 0);
        products[4] = new Invoice("P005", "Stainless Steel Spring", 0.30, 0);
        products[5] = new Invoice("P006", "PTFE Seal Thread Tape", 0.16, 0);
        products[6] = new Invoice("P007", "Silver Door Handle", 0.21, 0);
        products[7] = new Invoice("P008", "Mini Tool Kit", 3.25, 0);
        products[8] = new Invoice("P009", "Middle Tool Kit", 21.40, 0);
        products[9] = new Invoice("P010", "Professional Tool Kit", 149.99, 0);

        // We first print our product list
        Console.WriteLine("- - - OUR PRODUCT LIST - - -");
        Console.WriteLine("\n PN - NAME - PRICE");

        for (int i = 0; i < products.Length; i++)
        {
            products[i].PrintItemInfo();
        }
        Console.WriteLine("\n");

        // We create a new file name for invoice PDF
        string invoiceID = "invoice" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string invoicePath = invoiceID + ".pdf";

        bool bought = false;

        while (true)
        {
            if (!bought)
                Console.Write("Do you want to buy anything? (y/n) : ");
            else
                Console.Write("Do you want to buy another thing? (y/n) : ");
            string choice = Console.ReadLine();

            if (choice == "y" || choice == "Y")
            {
                
                Console.Write("What do you want to buy? Only use PN : ");
                string PN = Console.ReadLine();

                int index = -1; // Initial value is below zero to indicate an error state
                for (int i = 0; i < products.Length; i++)
                {
                    // We use linear search to determine the index of desired item
                    if (products[i].PartNumber.Equals(PN))
                    {
                        index = i;
                        break;
                    }
                }

                if (index < 0)
                {
                    Console.WriteLine("No items found with given PN.");
                }
                else
                {
                    Console.Write("Enter the desired amount of {0}: ", products[index].PartDescription);
                    try
                    {
                        products[index].Quantity += Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("You must enter an integer.");
                    }
                    if (products[index].Quantity > 0)
                    {
                        bought = true;
                    }
                }
                Console.Write("\n");
            }
            else
            {
                break;
            }
        }

        Console.Write("\nSee You Again\n");

        if (bought) // An invoice file will be generated if anything is sold.
        { 
            iTextSharp.text.Document theReport = new iTextSharp.text.Document();
            PdfWriter.GetInstance(theReport, new FileStream(invoicePath, FileMode.Create));
            theReport.AddAuthor("Group 2");
            theReport.AddCreationDate();
            theReport.AddCreator("Group 2");
            theReport.AddSubject("Group 2 - Homework 2");

            if (theReport.IsOpen() == false)
                theReport.Open();


            iTextSharp.text.Paragraph headParagraph = new Paragraph("Hardware Store");

            headParagraph.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
        
            theReport.Add(new Paragraph(headParagraph));
            theReport.Add(new Paragraph(" "));

            theReport.Add(new Paragraph());


            // Only the sold items will be on the invoice.
            decimal total_price = 0;
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Quantity > 0)
                {
                    theReport.Add(new Paragraph(products[i].ToString()));
                    total_price += products[i].GetInvoiceAmount();
                }
            }
            
            iTextSharp.text.Paragraph theTotaL = new Paragraph("Total Price : " + total_price.ToString() + " USD");
            theTotaL.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            theReport.Add(new Paragraph(" "));
            theReport.Add(new Paragraph(" "));
            theReport.Add(new Paragraph(theTotaL));
            
            theReport.Close();
            Console.WriteLine("Your invoice is here -> " + invoicePath);
        }
    }
}