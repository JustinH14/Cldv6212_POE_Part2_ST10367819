using ICETASKS;

namespace ICETASKS
{
    public class InventoryItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }

        public InventoryItem(string name, decimal price, int quantity, string category)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
        }
    }

    using System.Collections.Generic;

public class Inventory
    {
        private Dictionary<string, List<InventoryItem>> _inventoryByCategory = new Dictionary<string, List<InventoryItem>>();

        public void AddItem(InventoryItem item)
        {
            if (!_inventoryByCategory.ContainsKey(item.Category))
            {
                _inventoryByCategory[item.Category] = new List<InventoryItem>();
            }
            _inventoryByCategory[item.Category].Add(item);
        }

        public void RemoveItem(InventoryItem item)
        {
            if (_inventoryByCategory.ContainsKey(item.Category) && _inventoryByCategory[item.Category].Contains(item))
            {
                _inventoryByCategory[item.Category].Remove(item);
            }
        }

        public void DisplayInventory()
        {
            foreach (var category in _inventoryByCategory.Keys)
            {
                Console.WriteLine($"Category: {category}");
                foreach (var item in _inventoryByCategory[category])
                {
                    Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

public class GroceryStore
{
    public Inventory Inventory { get; } = new Inventory();
    public InputValidator InputValidator { get; } = new InputValidator();
    public ErrorHandler ErrorHandler { get; } = new ErrorHandler();

    public void AddItem(string name, decimal price, int quantity, string category)
    {
        if (!InputValidator.ValidateName(name) || !InputValidator.ValidatePrice(price) || !InputValidator.ValidateQuantity(quantity))
        {
            ErrorHandler.HandleInvalidInput();
            return;
        }

        Inventory.AddItem(new InventoryItem(name, price, quantity, category));
    }

    public void RemoveItem(string name)
    {
        if (!InputValidator.ValidateName(name))
        {
            ErrorHandler.HandleInvalidInput();
            return;
        }

        Inventory.RemoveItem(new InventoryItem(name, 0, 0, "Unknown")); 
    }

    public void DisplayInventory()
    {
        Inventory.DisplayInventory();
    }
}
public class InputValidator
{
    public bool ValidateName(string name)
    {
        
        return true; 
    }

    public bool ValidatePrice(decimal price)
    {
        return true; 
    }

    public bool ValidateQuantity(int quantity)
    {
        
        return true; 
    }
}

public class ErrorHandler
{
    public void HandleInvalidInput()
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        GroceryStore store = new GroceryStore();
        store.AddItem("Apple", 1.99m, 50, "Fruits");
        store.DisplayInventory();
    }
}