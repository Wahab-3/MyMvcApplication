using System;
using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Repository.InterFace;

namespace RealEstateConsoleApp.Repository.Implementation
{
    public class PropertyRepository : IPropertyRepository
    {
        public void CreateProperty(Property property)
        {
            var context = ContextClass.properties;
            context.Add(property);
        }

        public Property GetPropertyById(int id)
        {
            var context = ContextClass.properties;
            foreach (var item in context)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Property> GetPropertyByDescription(string description)
        {
            var newList = new List<Property>();
            var context = ContextClass.properties;
            foreach (var item in context)
            {
                if (item.Description == description)
                {
                    newList.Add(item);
                }
            }
            return newList;

        }

        public List<Property> GetPropertyByLocation(string location)
        {
            var newList = new List<Property>();
            var context = ContextClass.properties;
            foreach (var item in context)
            {
                if (item.Location == location)
                {
                    newList.Add(item);
                }
            }
            return newList;

        }

        public List<Property> GetPropertyByPrice(double Price)
        {
            var newList = new List<Property>();
            var context = ContextClass.properties;
            foreach (var item in context)
            {
                if (item.Price >= Price)
                {
                    newList.Add(item);
                }
            }
            return newList;
        }

        public List<Property> GetAllProperty()
        {
            var context = ContextClass.properties;
            return context;
        }

        public List<Property> GetPropertyByCartegoryName(string CartegoryName)
        {
            var newList = new List<Property>();

            var context = ContextClass.properties;
            foreach (var item in context)
            {
                if (item.CartegoryName == CartegoryName)
                {
                    newList.Add(item);
                }
            }
            return newList;

        }

        public List<Property> GetPropertyByUserEmail(string UserEmail)
        {
            var newList = new List<Property>();
            var context = ContextClass.properties;
            foreach (var item in context)
            {
                if (item.UserEmail == UserEmail)
                {
                    newList.Add(item);
                }
            }
            return newList;

        }


    }
}