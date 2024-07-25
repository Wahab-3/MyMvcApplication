using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateConsoleApp.Models;
namespace RealEstateConsoleApp
{
    public class ContextClass
    {
        public static List<Cartegory> cartigories = new List<Cartegory>()
        {
            new Cartegory(01,"LandedProperty".ToLower(),"LandForsaleOrForRent"),
            new Cartegory(02,"UncompletedProperty".ToLower(),"UncompletedPropertyForsaleOrForRent")

        };
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer(1,"A".ToLower(),"swderftgy"),
        };
        public static List<Manager> managers = new List<Manager>()
        {
            new Manager(1,"sola@gmail.com".ToLower()),
        };
        public static List<Transaction> transactions = new List<Transaction>();
        public static List<Role> roles = new List<Role>();

        public static List<Owner> owners = new List<Owner>()
        {
            new Owner(01,"Asder@gmail.com".ToLower(),$"Owner/wertt//f/00{1}")
        };
        public static List<User> users = new List<User>()
        {
            new User (01,"abdulWahab@gmail.com".ToLower(),"abdulwahab","Jokosenumi",08080954101,17,"odoeran",Gender.Male,"SuperAdmin","superadmin".ToLower(),0),
            new User (02,"Asder@gmail.com".ToLower(),"asake","kola",646373737782,34,"abeokuta",Gender.Male,"Owner","123".ToLower(),0),
            new User (03,"sola@gmail.com".ToLower(),"sola","kehinde",23456,45,"wesdc",Gender.Male,"manager","123456".ToLower(),0),
            new User(04,"A".ToLower(),"dfg","dfgh",345,34,"sdfgyhui",Gender.Female,"Customer","123".ToLower(),0)

        };
        public static List<Property> properties = new List<Property>()
        {
            new Property(01,02,"oyo",120000,true,"2 Bed Room Uncompleted Building".ToLower(),$"Owner/wertt//f/00{1}","Asder@gmail.com".ToLower(),"UncompletedProperty".ToLower(),TypeOfLeases.ForSale),
            new Property(02,01,"abk",1200000,true,"60 By 20 squaremeter of land",$"Owner/wertt//f/00{1}","Asder@gmail.com".ToLower(),"LandedProperty".ToLower(),TypeOfLeases.ForRent)

        };

    }
}