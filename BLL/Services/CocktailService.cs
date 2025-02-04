using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Mappers;

namespace BLL.Services
{
    public class CocktailService : ICocktailRepository<BLL.Entities.Cocktail>

    {

        private ICocktailRepository<DAL.Entities.Cocktail> _cocktail;
        private IUserRepository<DAL.Entities.User> _userService;
        public CocktailService(ICocktailRepository<DAL.Entities.Cocktail> cocktail,
            IUserRepository<DAL.Entities.User>userService)
        {
            _cocktail = cocktail;
            _userService = userService;
        }   

        public IEnumerable<Cocktail> Get()
        {
            //return _cocktail.Get().Select(dal => dal.ToBLL());
            IEnumerable<Cocktail> cocktails = _cocktail.Get().Select(dal => dal.ToBLL());
            foreach (Cocktail cocktail in cocktails)
            {
                if (cocktail.CreatedBy is not null) 
                {
                    cocktail.Creator = _userService.Get((Guid)cocktail.CreatedBy).ToBLL();
                }
            }
            return cocktails;
        }

        public Cocktail Get(Guid cocktail_id)
        {
            //return _cocktail.Get(id).ToBLL();
            Cocktail cocktail = _cocktail.Get(cocktail_id).ToBLL();
            if (cocktail.Creator is not null) 
            {
                cocktail.Creator = _userService.Get((Guid)cocktail.CreatedBy).ToBLL();
            }
            return cocktail;
        }

        public IEnumerable<Cocktail> GetByUser(Guid userId)
        {
            return _cocktail.GetByUser(userId).Select(dal => dal.ToBLL());
        }

        public Guid Insert(Cocktail user)
        {
            return _cocktail.Insert(user.ToDAL());
        }

        public void Update(Guid id, Cocktail user)
        {
            _cocktail.Update(id, user.ToDAL());
        }
        public void Delete(Guid id)
        {
           _cocktail.Delete(id);

        }
    }
}
