using System.Text;

class Users 
{
    public string? ID {get; set;}
    protected string? Password {get; set;}
    protected Random ran = new Random();
    public Users(){}

    public bool ValidateCredentials(string _ID, string Pass) 
    {
        Normal_Customer Ncustomer = new Normal_Customer();

        // First, check if the provided credentials match the Users class

        if (_ID == Ncustomer.Name && Pass == Password)
        {
            return true;
        }
        if (_ID == ID && Pass == Password)
        {
            return true;
        }

        // Check if Ncustomer is not null and its Name is not null

        return false;
    }
    public void CrateID_Pass()
    {
        Console.Clear();
        Console.WriteLine("It seems like you are new here...");
        if(ID == null)
        {
            string _ID = GenerateID(ran);
            Console.WriteLine($"Your ID is {_ID}");
            ID = _ID;
            Thread.Sleep(1000);
            Console.Clear();
        }
        if(Password == null)
        {
            Console.WriteLine("Write a new Password according to this rulers");
            PasswordC.Instructions();
            Console.CursorVisible = true;
            string? NewPassword = Console.ReadLine();
            if(NewPassword == null) {Console.WriteLine("Password was not valid"); return;}
            PasswordC pass = new PasswordC(NewPassword);
            Console.CursorVisible = false;

            if(pass.DisplayErrors())
            {
                Password = NewPassword;
            }

        }
    }
    private string GenerateID(Random ran)
    {
        int NumericID = ran.Next(1000,9000);

        StringBuilder stringID = new StringBuilder();
        for (int index = 0; index < 4; index++)
        {
            char a = (char)('a' + ran.Next(26));
            stringID.Append(a);
        }

        string NewID = NumericID.ToString() + stringID;
        return NewID;
    }
}

