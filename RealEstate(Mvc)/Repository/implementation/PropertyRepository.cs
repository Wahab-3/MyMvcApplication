using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using RealEstate_Mvc_.Context;
using RealEstate_Mvc_.Repository.Interface;
using RealEstateMvc.Models.Entities;
using RealEstateMvc.Models.Enum;
using System.Data.SqlClient;
using System.Linq;

namespace RealEstate_Mvc_.Repository.implementation
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ContextClass _context;
        public PropertyRepository(ContextClass context)
        {
            _context = context;
        }

        public Property Create(Property property)
        {
            var property1 = _context.Properties.Add(property);
            _context.SaveChanges();
            return property;
        }

        public List<Property> GetAll()
        {
            var properties = _context.Properties
                .Include(a => a.Owner)
                .Include(a => a.Category)
                .Where(a => a.IsAvailable == true && a.IsDeleted == false)
                .ToList();
            return properties;
        }

        public List<Property> GetByAvailability()
        {
            var property = _context.Properties
                .Include(a => a.Owner)
                .Include(a => a.Category)
                .Where(a => a.IsAvailable == true && a.IsDeleted == false)
                .ToList();
            return property;
        }

        public List<Property> GetByCartegoryId(string CartegoryId)
        {
            var property = _context.Properties
                .Include(a => a.Owner)
                .Include(a => a.Category)
                .Where(u => u.CategoryId == CartegoryId && u.IsDeleted == false)
                .ToList();
            return property;
        }

        public List<Property> GetByDescription(string Description)
        {
            var property = _context.Properties
                .Include(a => a.Owner)
                .Include(a => a.Category)
                .Where(u => u.Description == Description && u.IsDeleted == false)
                .ToList();
            return property;
        }

        public List<Property> GetByLocation(string Location)
        {
            var property = _context.Properties
                .Include(a => a.Owner)
                .Include(a => a.Category)
                .Where(u => u.Location == Location && u.IsDeleted == false)
                .ToList();
            return property;
        }

        public List<Property> GetByOwnerId(string ownerId)
        {
            var property = _context.Properties
            .Include(a => a.Owner)
            .Include(a => a.Category)
                .Where(u =>ownerId == ownerId && u.IsDeleted == false)
                .ToList();
            return property;
        }

        public List<Property> GetByPrice(double Price)
        {
            var property = _context.Properties
                 .Include(a => a.Owner)
                 .Include(a => a.Category)
                 .Where(a => a.Price <= Price && a.IsDeleted == false)
                 .ToList();
            return property;
        }

        public Property GetById(string Id)
        {
            var property = _context.Properties
                 .Include(a => a.Owner)
                 .Include(a => a.Category)
                 .FirstOrDefault(a => a.Id == Id && a.IsDeleted == false);
            return property;
        }

        public List<Property> GetByTypeOfLease(TYpeOfLeases TypeOfLeases)
        {
            var property = _context.Properties
                 .Include(a => a.Owner)
                 .Include(a => a.Category)
                 .Where(a => a.TypeOfLeases == TypeOfLeases && a.IsDeleted == false)
                 .ToList();
            return property;
        }

        public Property Update(Property property)
        {
            var property1 = _context.Properties.Update(property);
            _context.SaveChanges();
            return property;
        }
    }
}