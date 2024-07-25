// See https://aka.ms/new-console-template for more information
using RealEstateConsoleApp;
using RealEstateConsoleApp.Menu;
using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Repository.Implementation;

// Console.WriteLine("Hello, World!");
// OwnerMenu ownerMenu= new OwnerMenu();
// ownerMenu.CreateOwner();

MainMenu mainMenu = new MainMenu();
mainMenu.Main(); 
// CustomerRepository customerRepository = new CustomerRepository();
// customerRepository.ReadFromFile();
// UserRepository userRepository = new UserRepository();
// userRepository.ReadFromFile();

// foreach (var item in ContextClass.users)
// {
//     System.Console.WriteLine(item.Email);
// }

// CustomerMenu customerMenu = new CustomerMenu();
// customerMenu.Payment();
