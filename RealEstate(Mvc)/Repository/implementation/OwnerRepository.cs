using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using RealEstate_Mvc_.Context;
using RealEstate_Mvc_.Repository.Interface;
using RealEstateMvc.Models.Entities;
using System.Data.SqlClient;

namespace RealEstate_Mvc_.Repository.implementation
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ContextClass _context;
        public OwnerRepository(ContextClass context)
        {
            _context = context;
        }

        public bool Check(string StaffNumber)
        {
            var exist = _context.Owners.Any(u => u.StaffNumber == StaffNumber && u.IsDeleted == false);
            return exist;
        }

        public Owner Create(Owner Owner)
        {
            var owner = _context.Owners.Add(Owner);
            _context.SaveChanges();
            return Owner;
        }

        public List<Owner> GetAll()
        {
            var owners = _context.Owners
                .Include(a => a.Properties)
                   .Where(a => a.IsDeleted == false)
                .ToList();
            return owners;
        }

        public Owner GetByEmail(string Email)
        {
            var owner = _context.Owners
               .Include(a => a.Properties)
               .FirstOrDefault(u =>u.Email == Email && u.IsDeleted == false);
            return owner;
        }

        public Owner GetById(string Id)
        {
            var owner = _context.Owners
                .Include(a => a.Properties)
                .FirstOrDefault(a => a.Id == Id && a.IsDeleted == false);
            return owner;
        }

        public Owner GetByStaffNumber(string StaffNumber)
        {
            var owners = _context.Owners
                .Include(a => a.Properties)
                .FirstOrDefault(a => a.StaffNumber == StaffNumber && a.IsDeleted == false);
            return owners;
        }

        public Owner Update(Owner Owner)
        {
            var owner = _context.Owners.Update(Owner);
            _context.SaveChanges();
            return Owner;
        }
    }
}