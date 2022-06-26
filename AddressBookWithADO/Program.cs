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
    case 3:
        AddressBookModel addressbook = new AddressBookModel();
        addressbook.FirstName = "Sangram";
        addressbook.LastName = "Behera";
        addressbook.Address = "Bhadrak";
        addressbook.City = "Bhadrak";
        addressbook.State = "Odisha";
        addressbook.Zip = "756137";
        addressbook.PhoneNumber = "7077445649";
        addressbook.Email = "sangram15.behera@gmail.com";
        addressBookData.AddContact(addressbook);
        Console.WriteLine("Record Inserted successfully");
        break;
    case 4:
        addressBookData.GetAllContact();
        break;
    case 5:
        string UpdatedAddress = addressBookData.updateEmployeeDetails();
        Console.WriteLine(UpdatedAddress);
        Console.WriteLine("Record Updated successfully");
        break;
    default:
        Console.WriteLine("Please choose the correct option!");
        break;
}