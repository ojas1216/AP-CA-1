using System;
using System.Collections.Generic;

class Element
{
    public int number;
    public string name;
    public string type;

    public Element(int n, string nm, string t)
    {
        number = n;
        name = nm;
        type = t;
    }
}

class Program
{
    static Dictionary<int, Element> table = new Dictionary<int, Element>();

    static void Main()
    {
        Console.WriteLine("Hi there! Happy to help!");

        // First 30 elements
        table.Add(1, new Element(1, "Hydrogen", "Nonmetal"));
        table.Add(2, new Element(2, "Helium", "Noble Gas"));
        table.Add(3, new Element(3, "Lithium", "Metal"));
        table.Add(4, new Element(4, "Beryllium", "Metal"));
        table.Add(5, new Element(5, "Boron", "Metalloid"));
        table.Add(6, new Element(6, "Carbon", "Nonmetal"));
        table.Add(7, new Element(7, "Nitrogen", "Nonmetal"));
        table.Add(8, new Element(8, "Oxygen", "Nonmetal"));
        table.Add(9, new Element(9, "Fluorine", "Nonmetal"));
        table.Add(10, new Element(10, "Neon", "Noble Gas"));
        table.Add(11, new Element(11, "Sodium", "Metal"));
        table.Add(12, new Element(12, "Magnesium", "Metal"));
        table.Add(13, new Element(13, "Aluminium", "Metal"));
        table.Add(14, new Element(14, "Silicon", "Metalloid"));
        table.Add(15, new Element(15, "Phosphorus", "Nonmetal"));
        table.Add(16, new Element(16, "Sulfur", "Nonmetal"));
        table.Add(17, new Element(17, "Chlorine", "Nonmetal"));
        table.Add(18, new Element(18, "Argon", "Noble Gas"));
        table.Add(19, new Element(19, "Potassium", "Metal"));
        table.Add(20, new Element(20, "Calcium", "Metal"));
        table.Add(21, new Element(21, "Scandium", "Metal"));
        table.Add(22, new Element(22, "Titanium", "Metal"));
        table.Add(23, new Element(23, "Vanadium", "Metal"));
        table.Add(24, new Element(24, "Chromium", "Metal"));
        table.Add(25, new Element(25, "Manganese", "Metal"));
        table.Add(26, new Element(26, "Iron", "Metal"));
        table.Add(27, new Element(27, "Cobalt", "Metal"));
        table.Add(28, new Element(28, "Nickel", "Metal"));
        table.Add(29, new Element(29, "Copper", "Metal"));
        table.Add(30, new Element(30, "Zinc", "Metal"));

        char ch;

        do
        {
            Console.Write("Provide atomic number of the element: ");
            int num = int.Parse(Console.ReadLine());

            if (table.ContainsKey(num))
            {
                Element e = table[num];
                Console.WriteLine("Atomic Number: " + e.number);
                Console.WriteLine("Name: " + e.name);
                Console.WriteLine("Class: " + e.type + " (basic information)");
            }
            else
            {
                Console.WriteLine("Element not found");
            }

            Console.Write("Do you want to know more elements [y/n]? ");
            ch = Console.ReadLine()[0];

        } while (ch == 'y');

        Console.WriteLine("Thanks!");
    }
}