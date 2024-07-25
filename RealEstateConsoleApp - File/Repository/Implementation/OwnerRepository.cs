using RealEstateConsoleApp.Models;
using RealEstateConsoleApp___File;

namespace RealEstateConsoleApp.Repository.Implementation
{


    public class OwnerRepository : IOwnerRepository
    {

        string FilePath = Path.Combine(FileContext.FilePath, "Owner.txt");
     

        public Owner CreateOwner(Owner owner)
        {
            var context = ContextClass.owners;
            foreach (var item in context)
            {
                if (item.UserEmail == owner.UserEmail)
                {
                    return null;
                }
            }
            using (var str = new StreamWriter(FilePath, true))
            {
                str.WriteLine(owner.ToString());
            };
            context.Add(owner);
            return owner;
        }

        public List<Owner> GetAllOwner()
        {
            var context = ContextClass.owners;
            return context;
        }

        public Owner GetOwnerByEmail(string Email)
        {
            var context = ContextClass.owners;
            foreach (var item in context)
            {
                if (item.UserEmail == Email)
                {
                    return item;
                }
            }
            return null;
        }

        public Owner GetOwnerById(int id)
        {
            var context = ContextClass.owners;
            foreach (var item in context)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public Owner GetOwnerByTagNumber(string TagNumber)
        {
            var context = ContextClass.owners;
            foreach (var item in context)
            {
                if (item.TagNumber == TagNumber)
                {
                    return item;
                }
            }
            return null;
        }



        public void RefreshOwnerFile()
        {
            using (var strm = new StreamWriter(FilePath, false))
            {
                foreach (var item in ContextClass.owners)
                {
                    strm.WriteLine(item.ToString());
                }
            }
        }
      
    }
}