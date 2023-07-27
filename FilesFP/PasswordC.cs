class PasswordC
{
    public string? InputPassword { get; private set; }
    private string text = "";

    private bool NotDigit = false;
    private bool NotLower = false;
    private bool NotCapital = false;
    bool hasUpperCase = false;
    bool hasLowerCase = false;
    bool hasDigit = false;
    public PasswordC(string password)
    {
        this.InputPassword = password;
    }

    public static void Instructions()
    {
        Console.WriteLine("Your Passwords must be at least 6 letters long and no more than 20 letters long.");
        Console.WriteLine("Passwords must contain at least one uppercase letter, one lowercase letter, and one number");
        Console.WriteLine("Passwords cannot contain a capital T or an ampersand (&) because Ingelmar in IT has decreed it.\n");
    }

    private void Errors(string Text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(Text);
        Console.ForegroundColor = ConsoleColor.White;
    }
    private void Right(string Text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(Text);
        Console.ForegroundColor = ConsoleColor.White;
    }
    public bool DisplayErrors()
    {
        if (InputPassword!.Length < 6)
        {
            text = "Your password should be at least 6 characters long";
            Errors(text);
            return false;
        }
        else if (InputPassword.Length > 20)
        {
            text = "Your password should have less than 20 characters";
            Errors(text);
            return false;
        }

        bool hasT = false;
        bool hasAmpersand = false;

        foreach (char letter in InputPassword)
        {
            if (letter == 'T')
            {
                hasT = true;
            }
            if (letter == '&')
            {
                hasAmpersand = true;
            }
        }

        if (hasT)
        {
            text = "Your password cannot contain the letter T";
            Errors(text);
            return false;
        }

        if (hasAmpersand)
        {
            text = "Your password cannot contain the ampersand character (&)";
            Errors(text);
            return false;
        }

        foreach (char letter in InputPassword)
        {
            if (char.IsUpper(letter))
            {
                hasUpperCase = true;
            }
            if (char.IsLower(letter))
            {
                hasLowerCase = true;
            }
            if (char.IsDigit(letter))
            {
                hasDigit = true;
            }
        }

        if (!hasUpperCase)
        {
            text = "Your password does not contain an uppercase letter";
            Errors(text);
            return false;
        }

        if (!hasLowerCase)
        {
            text = "Your password does not contain a lowercase letter";
            Errors(text);
            return false;
        }

        if (!hasDigit)
        {
            text = "Your password does not contain a digit";
            Errors(text);
            return false;
        }
        return true;
    }

}