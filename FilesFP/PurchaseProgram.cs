class PurchaseProgram
{
    Users users;
    Users Companyusers;
    Company_user Cuser;
    Normal_Customer Ncustomer;
    public PurchaseProgram()
    {
        users = new Users();
        Companyusers  = new Users();
        Cuser = new Company_user();
        Ncustomer = new Normal_Customer();   
        Groceries Chococlate = new Groceries("ACEREGE", "Chocolate");
        Cuser.ListOfProducts.Add(Chococlate);
        Cuser.AddEmployee(Cuser);

    }
    public void Run()
    {      
        string lines = string.Concat(Enumerable.Repeat("-", 35));
        bool user = false;
        bool CompanyU = false;
        int start = 0;

        while (true)
        {           
            if(!user && !CompanyU)
            {
                Console.Clear();
                Texts(1);
                ConsoleKey key0 = Console.ReadKey(true).Key;
                switch(key0)
                {
                    //User///////////////////////////////////////////////////////////////////////
                    case ConsoleKey.A:
                    users.CrateID_Pass();
                    Console.Clear();
                    Console.CursorVisible = true;                    
                    Console.WriteLine($"Write your ID                 Saved ID {users.ID}" );
                    string? inputID = Console.ReadLine();
                    Console.WriteLine("Write your passwrod");
                    string? inputPassword = Console.ReadLine();
                    

                    bool login = users.ValidateCredentials(inputID!,inputPassword!);

                    if(login)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nSuccesfuly login");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(1000);
                        user = true;
                        CompanyU = false;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nlogin failed your ID or/and password are wrong");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(1000);
                    }
                    break;

                    // Company////////////////////////////////////////////////////////////////////
                    case ConsoleKey.B:
                        Companyusers.CrateID_Pass();
                        Console.Clear();
                        Console.CursorVisible = true;
                        Console.WriteLine($"Write your ID                 Saved ID {Companyusers.ID}" );
                        string? inputID1 = Console.ReadLine();
                        Console.WriteLine("Write your passwrod");
                        string? inputPassword1 = Console.ReadLine();

                        bool login1 = Companyusers.ValidateCredentials(inputID1!,inputPassword1!);

                        if(login1 == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nSuccesfuly login");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(1000);
                            user = false;
                            CompanyU = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nlogin failed your ID or/and password are wrong");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(1000);
                        }
                    break;

                    // EXIT//////////////////////////////////////////////////////////////////////////
                    case ConsoleKey.Escape:
                    return;
                }

            }
            if(user)         
            {
                Ncustomer.CheckName_Email();
                Console.Clear();
                Texts(2);
                ConsoleKey key1 = Console.ReadKey(true).Key;

                switch(key1)
                {
                    case ConsoleKey.A:     
                    if(start == 0)
                    {
                        start = Ncustomer.customerType();
                    }
                    if(start >= 1)
                    {           
                        Ncustomer.OpenEshop(start, Cuser);
                    }
                    break;
                    case ConsoleKey.B:
                    Ncustomer.DisplayProducts();
                    Console.ReadKey();
                    break;
                    case ConsoleKey.C:
                    Ncustomer.RemoveProducts();
                    break;
                    case ConsoleKey.D:
                    user = false;
                    break;
                }
            } 
            if(CompanyU)
            {
                Cuser.CheckName_Email();
                Console.Clear();
                Texts(3);

                ConsoleKey key2 = Console.ReadKey(true).Key;

                switch(key2)
                {
                    case ConsoleKey.A:
                        Console.Clear();
                        Texts(4);
                        ConsoleKey key3 = Console.ReadKey(true).Key;
                        switch(key3)
                        {
                            case ConsoleKey.A:
                            Cuser.AddProduct();
                            break;
                            case ConsoleKey.B:   
                            Cuser.RemoveProduct();
                            break;
                            case ConsoleKey.C:                        
                            break;
                        }
                    break;
                    case ConsoleKey.B:
                    Cuser.ShowListOfProducts();
                    Console.ReadKey();
                    break;
                    case ConsoleKey.C:    
                    Cuser.ShowListOfEmployees();   
                    Thread.Sleep(1000);
                    Cuser.HireEmployee();             
                    break;
                    case ConsoleKey.D:
                    Cuser.RemoveEmployees();
                    break;
                    case ConsoleKey.E:
                    Cuser.ShowListOfCustomers();  
                    Thread.Sleep(1000);
                    Cuser.BringNewCustomers(); 
                    break;
                    case ConsoleKey.F:
                    Cuser.RemoveCustomers();
                    break;
                    case ConsoleKey.G:
                    CompanyU = false;
                    break;
                }
            }

        }
    }   
    public void Texts(int N)
    {
        string lines = string.Concat(Enumerable.Repeat("-", 35));
        switch(N)
        {
            case 1:
                Console.WriteLine(lines);
                Console.WriteLine("Welcome! what are you?");
                Console.WriteLine("a) User");
                Console.WriteLine("b) Company User");
                Console.WriteLine(lines);
            break;
            
            case 2:
                Console.WriteLine(lines);
                Console.WriteLine("a) Open Eshop");
                Console.WriteLine("b) Display products information");
                Console.WriteLine("c) Remove products");
                Console.WriteLine("d) Exit");
                Console.WriteLine(lines);
            break;
            case 3:
                Console.WriteLine(lines);
                Console.WriteLine("a) Open Eshop");
                Console.WriteLine("b) Display current products");
                Console.WriteLine("c) Display current employees");
                Console.WriteLine("d) Remove employees");
                Console.WriteLine("e) Display current customers");
                Console.WriteLine("f) Ban customers");
                Console.WriteLine("g) Exit");
                Console.WriteLine(lines);
            break;
            case 4:
                Console.WriteLine(lines);
                Console.WriteLine("a) Add a product");
                Console.WriteLine("b) Delete a product");                
                Console.WriteLine("c) Exit");
                Console.WriteLine(lines);
            break;
        }
    }
}