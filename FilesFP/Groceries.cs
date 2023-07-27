class Groceries : Product
{        

    public Groceries(string? id, string? name) : base(id, name){}
    public override void DisplayInformation()
    {
        Console.WriteLine($"Groceries Product ID: {ID}, Name: {Name}, Purchased at: {Time.Hour}:{Time.Minute} O'clock");
    }
}

