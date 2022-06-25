// See https://aka.ms/new-console-template for more information
using AddressBook_ADO.NET;

Console.WriteLine("Welcome to AddressBook ADO.NET!");

AddressBookData addressBookData = new AddressBookData();
addressBookData.Create_Database();

Console.WriteLine("Select option\n1)Create AddrssBookServiceDatabase\n2)Create AddressBookTable");
int op = Convert.ToInt16(Console.ReadLine());
switch (op)
{
    case 1:
        addressBookData.Create_Database();
        break;
    case 2:
        addressBookData.CreateTables();
        break;
    default:
        Console.WriteLine("Please choose the correct option!");
        break;
}