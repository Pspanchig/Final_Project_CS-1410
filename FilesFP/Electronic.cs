class Electronic : Product
{
    public Electronic(string? id, string? name) : base(id, name){}
    public override void DisplayInformation()
    {
        Console.WriteLine($"Electronic Product ID: {ID}, Name: {Name}");
    }
}
