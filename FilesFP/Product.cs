class Product : IProducts
{
    public string? ID { get; set; }
    public string? Name { get; set; }
    public DateTime Time {get; set;}
    
    public Product(string? id, string? name)
    {
        ID = id;
        Name = name;
        Time = DateTime.Now;

    }

    public virtual void DisplayInformation()
    {
        Console.WriteLine($"Groceries Product ID: {ID}, Name: {Name}, Purchased at: {Time.Hour}:{Time.Minute} O'clock");
    }
}

