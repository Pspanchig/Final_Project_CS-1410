class Company_user : Users
{
    public string? Name {get; set;}
    private string? Email {get; set;}
    private DateTime Time {get; set;}

    public List<Normal_Customer>ListOfCustomers = new List<Normal_Customer>();
    public List<Product>ListOfProducts = new List<Product>();
    public List<Company_user>ListOfEmployees = new List<Company_user>();

    public void AddEmployee(Company_user employee)
    {
        ListOfEmployees.Add(employee);
    }
    public void AddCustomer(Normal_Customer customer)
    {
        ListOfCustomers.Add(customer);
    }
    public void ShowListOfProducts()
    {
        Console.Clear();        
        var groupedProducts = ListOfProducts.GroupBy(p =>
        {
            if (p is Electronic) return "Electronic";
            if (p is Groceries) return "Groceries";
            if (p is Tool) return "Tool";
            if (p is Toy) return "Toy";
            return "Other";
        });

        foreach (var group in groupedProducts)
        {
            string category = group.Key;
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"{category} section:");
            Console.WriteLine("--------------------------------------");

            int index = 1;
            foreach (var product in group)
            {
                Console.WriteLine($"{index}- {product.Name} {product.ID} {product.Time}");
                index++;
            }
        }

        if (!groupedProducts.Any(group => group.Key == "Electronic"))
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("There's no Electronics");
            Console.WriteLine("--------------------------------------");
        }
        if (!groupedProducts.Any(group => group.Key == "Groceries"))
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("There's no Groceries");
            Console.WriteLine("--------------------------------------");
        }
        if (!groupedProducts.Any(group => group.Key == "Tool"))
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("There's no Tools");
            Console.WriteLine("--------------------------------------");
        }
        if (!groupedProducts.Any(group => group.Key == "Toy"))
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("There's no Toys");
            Console.WriteLine("--------------------------------------");
        }
    }
    public void ShowListOfEmployees()
    {        
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------------");
        int index = 1;
        foreach(var employee in ListOfEmployees)
        {
            Console.WriteLine($"{index}- Name: {employee.Name}, Email: {employee.Email}");
            index++;
        }
        Console.WriteLine("--------------------------------------------------------------");
    }
    public void ShowListOfCustomers()
    {
        Console.Clear();
        if(ListOfCustomers.Count < 1)
        {
            Console.WriteLine("--------------------------------------------------------------");            
            Console.WriteLine("You don't have customers :(");
            Console.WriteLine("--------------------------------------------------------------");    
            Thread.Sleep(1000);
            return;
        }

        Console.WriteLine("--------------------------------------------------------------");
        int index = 1;
        foreach(var customer in ListOfCustomers)
        {
            Console.WriteLine($"{index}- Name: {customer.Name}, Email: {customer.Email}");
            index++;
        }
        Console.WriteLine("--------------------------------------------------------------");
    }
    public void BringNewCustomers()
    {
        Console.WriteLine("Do you want to bring a new customer?");
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("a) Yes");
        Console.WriteLine("b) Return");
        ConsoleKey key= Console.ReadKey(true).Key;
        switch(key)
        {
            case ConsoleKey.A:
                Console.Clear();
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("New customer's name:");
                Console.WriteLine("--------------------------------------------------------------");
                string? inputName = Console.ReadLine();
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("New customer's email:");
                Console.WriteLine("--------------------------------------------------------------");
                string? inputEmail = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(inputName) && !string.IsNullOrWhiteSpace(inputEmail))
                {
                    Normal_Customer newcustomer =  new Normal_Customer();
                    newcustomer.Name = inputName;
                    newcustomer.Email = inputEmail;
                    AddCustomer(newcustomer);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Succesfuly added");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Impossible to add");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1000);
                }
            break;
            case ConsoleKey.B:
            break;
        }
        
    }
    public void HireEmployee()
    {
        Console.WriteLine("Do you want to hire a new Employee?");
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("a) Yes");
        Console.WriteLine("b) Return");
        ConsoleKey key= Console.ReadKey(true).Key;
        switch(key)
        {
            case ConsoleKey.A:
                Console.Clear();
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("New employee's name:");
                Console.WriteLine("--------------------------------------------------------------");
                string? inputName = Console.ReadLine();
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("New employee's email:");
                Console.WriteLine("--------------------------------------------------------------");
                string? inputEmail = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(inputName) && !string.IsNullOrWhiteSpace(inputEmail))
                {
                    Company_user newuser =  new Company_user();
                    newuser.Name = inputName;
                    newuser.Email = inputEmail;
                    AddEmployee(newuser);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Succesfuly added");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Impossible to add");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1000);
                }
            break;
            case ConsoleKey.B:
            break;
        }
        
    }
    public void RemoveEmployees()
    {
        if(ListOfEmployees.Count  <= 0)
        {
            Console.WriteLine("There's nothing to be removed");
            Thread.Sleep(1000);
        }
        else
        {
            ShowListOfEmployees();
            Console.WriteLine("Write the index of the employee you want to remove");
            Console.WriteLine("-----------------------------------------------------");
            string? inputt = Console.ReadLine();
            if (int.TryParse(inputt, out int index))
            {    
                index -= 1;                      
                if (index >= 1 && index < ListOfEmployees.Count)
                {
                    string? EmployeetName = ListOfEmployees[index].Name;
                    ListOfEmployees.RemoveAt(index);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{EmployeetName} has been successfully removed");
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
    public void RemoveCustomers()
    {
        if(ListOfCustomers.Count  <= 0)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("There's nothing to be removed");
            Console.WriteLine("-----------------------------------------------------");
            Thread.Sleep(1000);
        }
        else
        {
            ShowListOfCustomers();
            Console.WriteLine("Write the index of the employee you want to remove");
            Console.WriteLine("-----------------------------------------------------");
            string? inputt = Console.ReadLine();
            if (int.TryParse(inputt, out int index))
            {    
                index -= 1;                      
                if (index >= 0 && index < ListOfCustomers.Count)
                {
                    string? Customer = ListOfCustomers[index].Name;
                    ListOfEmployees.RemoveAt(index);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Customer} has been successfully removed");
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
    public void RemoveProduct()
    {
        ShowListOfProducts();
            Console.WriteLine("Write the index of the product you want to remove");
            Console.WriteLine("-------------------------------");
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
                Email = Name + "@.employee.gmail.com";
                Console.WriteLine($"Your user email is {Email}");
                Thread.Sleep(1000);
            }   
            else
            Console.WriteLine("You gotta give me a name");
        }
    }
    public void AddProduct()
    {
        Console.WriteLine("Choose the product you want to add to the market:");
        Console.WriteLine("a) Groceries");
        Console.WriteLine("b) Electronics");
        Console.WriteLine("c) Tools");
        Console.WriteLine("d) Toys");

        ConsoleKey key = Console.ReadKey(true).Key;
        switch(key)
        {
            case ConsoleKey.A:

                Console.WriteLine("What is your product?");
                string? Name = Console.ReadLine();
                Groceries product = new Groceries(GenerateUniqueSerialNumber(), Name);
                ListOfProducts.Add(product);
                
            break;
            case ConsoleKey.B:
            
                Console.WriteLine("What is your product?");
                string? Name1 = Console.ReadLine();
                Electronic product1 = new Electronic(GenerateUniqueSerialNumber(), Name1);
                ListOfProducts.Add(product1);

            break;
            case ConsoleKey.C:
            
                Console.WriteLine("What is your product?");
                string? Name2 = Console.ReadLine();
                Tool product2 = new Tool(GenerateUniqueSerialNumber(), Name2);
                ListOfProducts.Add(product2);

            break;
            case ConsoleKey.D:
            
                Console.WriteLine("What is your product?");
                string? Name3 = Console.ReadLine();
                Toy product3 = new Toy(GenerateUniqueSerialNumber(), Name3);
                ListOfProducts.Add(product3);

            break;
        }

    }
    private string GenerateUniqueSerialNumber()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        const int serialNumberLength = 10;
        Random random = new Random();
        string serialNumber;
        HashSet<string> generatedSerialNumbers = new HashSet<string>();

        do
        {
            serialNumber = new string(Enumerable.Repeat(chars, serialNumberLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        } while (!generatedSerialNumbers.Add(serialNumber)); 

        return serialNumber;
    }

}