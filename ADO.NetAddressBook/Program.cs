namespace ADO.NetAddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to contact management program");
            AddressBookADO Book = new AddressBookADO();

            ShowOptions();

            void ShowOptions()
            {
                Console.Write("\n Select Option : 1.Display Contacts  \n ");
                Console.WriteLine();
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Book.GetContactDetails();
                        ShowOptions();
                        break;
                    default:
                        Console.WriteLine("Enter correct choice");
                        break;
                }
            }
        }
    }
}