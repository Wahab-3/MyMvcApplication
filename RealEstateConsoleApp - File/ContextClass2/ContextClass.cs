using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using RealEstateConsoleApp.Models;
namespace RealEstateConsoleApp
{
    public class ContextClass
    {
        public static List<Cartegory> cartigories = new List<Cartegory>()
        {
            new Cartegory{Id=01,Name="LandedProperty".ToLower(),Description="LandForsaleOrForRent"},
            new Cartegory{Id=02,Name="UncompletedProperty".ToLower(),Description="UncompletedPropertyForsaleOrForRent"}

        };
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer{Id=1,UserEmail="A".ToLower(),TagNumber="swderftgy"},
        };
        public static List<Manager> managers = new List<Manager>()
        {
            new Manager{Id=1,UserEmail="sola@gmail.com".ToLower()}
        };
        public static List<Transaction> transactions = new List<Transaction>();
        public static List<Role> roles = new List<Role>();

        public static List<Owner> owners = new List<Owner>()
        {
            new Owner{Id=01,UserEmail="Asder@gmail.com".ToLower(),TagNumber=$"Owner/wertt//f/00{1}"}
        };
        public static List<User> users = new List<User>()
        {
            new User {Id =01,Email = "abdulWahab@gmail.com".ToLower(),FirstName="abdulwahab",LastName="Jokosenumi",PhoneNumber=08080954101,Age=17,Address="odoeran",Gender=Gender.Male,RoleName="SuperAdmin",Password="superadmin".ToLower(),Wallet=0},
            new User {Id=02,Email ="Asder@gmail.com".ToLower(),FirstName="asake",LastName="kola",PhoneNumber=646373737782,Age=34,Address="abeokuta",Gender=Gender.Male,RoleName="Owner",Password="123".ToLower(),Wallet=0},
            new User {Id=03,Email="sola@gmail.com".ToLower(),FirstName="sola",LastName="kehinde",PhoneNumber=23456,Age=45,Address="wesdc",Gender=Gender.Male,RoleName="manager",Password="123456".ToLower(),Wallet=0},
            new User{Id=04,Email="A".ToLower(),FirstName="dfg",LastName="dfgh",PhoneNumber=345,Age=34,Address="sdfgyhui",Gender=Gender.Female,RoleName="Customer",Password="123".ToLower(),Wallet=0}

        };
        public static List<Property> properties = new List<Property>()
        {
            new Property{Id=01,CartegoryId=02,Location="oyo",Price=120000,IsAvailable=true,Description="2 Bed Room Uncompleted Building".ToLower(),OwnersTagNumber=$"Owner/wertt//f/00{1}",UserEmail="Asder@gmail.com".ToLower(),CartegoryName="UncompletedProperty".ToLower(),TypeOfLeases=TypeOfLeases.ForSale},
            new Property{Id=2,CartegoryId=01,Location="abk",Price=1200000,IsAvailable=true,Description="60 By 20 squaremeter of land",OwnersTagNumber=$"Owner/wertt//f/00{1}",UserEmail="Asder@gmail.com".ToLower(),CartegoryName="LandedProperty".ToLower(),TypeOfLeases=TypeOfLeases.ForRent}

        };

    }
}