using System;
using System.Collections.Generic;

class Element
{
    public int AtomicNumber;
    public string Name;
    public string Type;

    public Element(int num, string name, string type)
    {
        AtomicNumber = num;
        Name = name;
        Type = type;
    }
}

class Program
{
    static Dictionary<int, Element> table = new Dictionary<int, Element>();

    static void Main()
    {
        table.Add(1, new Element(1, "Hydrogen", "Non-metal"));
        table.Add(2, new Element(2, "Helium", "Noble Gas"));
        table.Add(3, new Element(3, "Lithium", "Alkali Metal"));
        table.Add(4, new Element(4, "Beryllium", "Alkaline Earth"));
        table.Add(5, new Element(5, "Boron", "Metalloid"));
        table.Add(6, new Element(6, "Carbon", "Non-metal"));
        table.Add(7, new Element(7, "Nitrogen", "Non-metal"));
        table.Add(8, new Element(8, "Oxygen", "Non-metal"));
        table.Add(9, new Element(9, "Fluorine", "Halogen"));
        table.Add(10, new Element(10, "Neon", "Noble Gas"));
        table.Add(11, new Element(11, "Sodium", "Alkali Metal"));
        table.Add(12, new Element(12, "Magnesium", "Alkaline Earth"));
        table.Add(13, new Element(13, "Aluminum", "Metal"));
        table.Add(14, new Element(14, "Silicon", "Metalloid"));
        table.Add(15, new Element(15, "Phosphorus", "Non-metal"));
        table.Add(16, new Element(16, "Sulfur", "Non-metal"));
        table.Add(17, new Element(17, "Chlorine", "Halogen"));
        table.Add(18, new Element(18, "Argon", "Noble Gas"));
        table.Add(19, new Element(19, "Potassium", "Alkali Metal"));
        table.Add(20, new Element(20, "Calcium", "Alkaline Earth"));
        table.Add(21, new Element(21, "Scandium", "Transition Metal"));
        table.Add(22, new Element(22, "Titanium", "Transition Metal"));
        table.Add(23, new Element(23, "Vanadium", "Transition Metal"));
        table.Add(24, new Element(24, "Chromium", "Transition Metal"));
        table.Add(25, new Element(25, "Manganese", "Transition Metal"));
        table.Add(26, new Element(26, "Iron", "Transition Metal"));
        table.Add(27, new Element(27, "Cobalt", "Transition Metal"));
        table.Add(28, new Element(28, "Nickel", "Transition Metal"));
        table.Add(29, new Element(29, "Copper", "Transition Metal"));
        table.Add(30, new Element(30, "Zinc", "Transition Metal"));

        while (true)
        {
            Console.Write("Enter atomic number: ");
            int num = int.Parse(Console.ReadLine());

            if (table.ContainsKey(num))
            {
                Element e = table[num];
                Console.WriteLine($"Atomic No: {e.AtomicNumber}");
                Console.WriteLine($"Name: {e.Name}");
                Console.WriteLine($"Type: {e.Type}");
            }

            Console.Write("Continue (y/n): ");
            if (Console.ReadLine() == "n") break;
        }
    }
}