﻿// See https://aka.ms/new-console-template for more information
using AddressBook_ADO.NET;

Console.WriteLine("Welcome to AddressBook ADO.NET!");

AddressBookData addressBookData = new AddressBookData();
addressBookData.Create_Database();