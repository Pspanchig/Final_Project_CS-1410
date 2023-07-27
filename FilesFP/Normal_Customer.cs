class Normal_Customer : Users
{
    public string? Name {get; set;}
    public string? Email {get; set;}
    public int TypeofCustomer{get; set;}
    public List<IProducts> ListOfProducts = new List<IProducts>();

    public Normal_Customer(){}

    public void PurchaseProduct(IProducts products, DateTime Time)
    {
        Time = DateTime.Now;
        ListOfProducts.Add(products);
    }
    public void DisplayProducts()
    {
        Console.Clear();
        if(ListOfProducts.Count < 1)
        {
           Console.WriteLine("You don't have any product right now :()");
           Thread.Sleep(1000);
           return;

        }
        int index = 1;
        string lines = string.Concat(Enumerable.Repeat("-", 35));
        Console.WriteLine(lines);
        Console.WriteLine("Your products are: \n");
        Console.WriteLine(lines);
        foreach (var product in ListOfProducts)
        {
            Console.WriteLine($"{index}- Name: {product.Name}, Product ID: {product.ID}, Time it was bouhgt: {product.Time}");
            index++;
        }
        Console.WriteLine(lines);
    }
    public void CheckName_Email()
    {
        Console.Clear();
        if(Name == null)
        {
            Console.WriteLine($"Please Write your user name user{ID}");
            string? input0 = Console.ReadLine();
            if(input0 != null)
            {
                Name = input0;
            }   
            else
            Console.WriteLine("You gotta give me a name");
        }
        if(Email == null)
        {
            
            if(Name != null)
            {
                Email = Name + "@gmail.com";
                Console.WriteLine($"Your user email is {Email}");
                Thread.Sleep(1000);
            }   
            else
            Console.WriteLine("You gotta give me a name");
        }
    }
    public int customerType()
    {
        Console.WriteLine("What class of Customer are you?");
        Console.WriteLine("A) retail customer");
        Console.WriteLine("B) wholesale customer\n");
        string? input = Console.ReadLine()?.ToLower();
        
        TypeofCustomer = input?.ToLower() switch
        {
            "a" => TypeofCustomer = 1,
            "b" => TypeofCustomer = 2,
            _ => TypeofCustomer = 0
        };
        return TypeofCustomer;
    }

    public void RemoveProducts()
    {
        string lines = string.Concat(Enumerable.Repeat("-", 35));
        if(ListOfProducts.Count  <= 0)
        {
            Console.WriteLine("There's nothing to be removed");
            Thread.Sleep(1000);
        }
        else
        {
            DisplayProducts();
            Console.WriteLine("Write the index of the product you want to remove");
            Console.WriteLine(lines);
            string? inputt = Console.ReadLine();
            if (int.TryParse(inputt, out int index))
            {    
                index -= 1;                      
                if (index >= 0 && index < ListOfProducts.Count)
                {
                    string? productName = ListOfProducts[index].Name;
                    ListOfProducts.RemoveAt(index);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{productName} has been successfully removed");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Index");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1000);
                }
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input. Please enter a valid index.");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
            }
        }
    }
    public void OpenEshop(int start, Company_user Cuser)
    {
        Cuser.ShowListOfProducts();
        Console.WriteLine("a) Buy \nb) Go back");
        Console.WriteLine("------------------------------------");
        ConsoleKey key = Console.ReadKey(true).Key;
        switch(key)
        {
            case ConsoleKey.A:
                Console.WriteLine("Write the index of the product you want to buy");
                string? inputt = Console.ReadLine();
                if (int.TryParse(inputt, out int index))
                {
                    index -= 1;
                    if (index >= 0 && index < Cuser.ListOfProducts.Count)
                    {
                        PurchaseProduct(Cuser.ListOfProducts[index], DateTime.Now);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Index");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input. Please enter a valid index.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1000);

                }
            break;
            case ConsoleKey.B:
            break;

        }

        
    }
}
