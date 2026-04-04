using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Element
{
    public int AtomicNumber { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    public Element() { }

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
    static string dataFile = "elements.json";

    static void Main()
    {
        LoadTable();

        while (true)
        {
            Console.Write("Enter atomic number: ");
            string input = Console.ReadLine()?.Trim();
            if (!int.TryParse(input, out int num))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            if (table.TryGetValue(num, out Element e))
            {
                Console.WriteLine($"Atomic No: {e.AtomicNumber}");
                Console.WriteLine($"Name: {e.Name}");
                Console.WriteLine($"Type: {e.Type}");
            }
            else
            {
                Console.WriteLine("Element not found. Enter a number between 1 and 30.");
            }

            Console.Write("Continue (y/n): ");
            string answer = Console.ReadLine()?.Trim().ToLower();
            if (answer == "n")
                break;
        }
    }

    static void LoadTable()
    {
        if (!File.Exists(dataFile))
        {
            SaveDefaultTable();
        }

        try
        {
            string json = File.ReadAllText(dataFile);
            List<Element> elements = JsonSerializer.Deserialize<List<Element>>(json) ?? new List<Element>();
            table.Clear();
            foreach (var element in elements)
            {
                table[element.AtomicNumber] = element;
            }
        }
        catch
        {
            SaveDefaultTable();
            LoadTable();
        }
    }

    static void SaveDefaultTable()
    {
        var elements = new List<Element>
        {
            new Element(1, "Hydrogen", "Non-metal"),
            new Element(2, "Helium", "Noble Gas"),
            new Element(3, "Lithium", "Alkali Metal"),
            new Element(4, "Beryllium", "Alkaline Earth"),
            new Element(5, "Boron", "Metalloid"),
            new Element(6, "Carbon", "Non-metal"),
            new Element(7, "Nitrogen", "Non-metal"),
            new Element(8, "Oxygen", "Non-metal"),
            new Element(9, "Fluorine", "Halogen"),
            new Element(10, "Neon", "Noble Gas"),
            new Element(11, "Sodium", "Alkali Metal"),
            new Element(12, "Magnesium", "Alkaline Earth"),
            new Element(13, "Aluminum", "Metal"),
            new Element(14, "Silicon", "Metalloid"),
            new Element(15, "Phosphorus", "Non-metal"),
            new Element(16, "Sulfur", "Non-metal"),
            new Element(17, "Chlorine", "Halogen"),
            new Element(18, "Argon", "Noble Gas"),
            new Element(19, "Potassium", "Alkali Metal"),
            new Element(20, "Calcium", "Alkaline Earth"),
            new Element(21, "Scandium", "Transition Metal"),
            new Element(22, "Titanium", "Transition Metal"),
            new Element(23, "Vanadium", "Transition Metal"),
            new Element(24, "Chromium", "Transition Metal"),
            new Element(25, "Manganese", "Transition Metal"),
            new Element(26, "Iron", "Transition Metal"),
            new Element(27, "Cobalt", "Transition Metal"),
            new Element(28, "Nickel", "Transition Metal"),
            new Element(29, "Copper", "Transition Metal"),
            new Element(30, "Zinc", "Transition Metal")
        };

        string json = JsonSerializer.Serialize(elements, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(dataFile, json);
    }
}