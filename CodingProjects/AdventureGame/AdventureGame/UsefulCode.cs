class UsefulCode
{
    public void tryParse()
    {
        int number; 

        while(true)
        {
            System.Console.WriteLine("Enter a number. Only a number");
            string userInput = Console.ReadLine();

            if(int.TryParse(userInput, out number))
            {
                Console.WriteLine($"Valid number: {number}");
                break;
            }
        }
        
    }
}