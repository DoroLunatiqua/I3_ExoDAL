using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using DAL.Entities;
using D = DAL.Entities;

namespace BLL.Mappers
{
    internal static class Mapper
    {
        public static BLL.Entities.User ToBLL(this D.User user)
        {
            if(user is null) throw new ArgumentNullException(nameof(user));
            return new BLL.Entities.User(
                user.User_Id, 
                user.First_Name, 
                user.Last_Name, 
                user.Email, 
                user.Password, 
                user.CreatedAt, 
                user.DisabledAt);
        }

        public static D.User ToDAL(this BLL.Entities.User user) {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new D.User()
            {
                User_Id = user.User_Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                DisabledAt = (user.IsDisabled) ? new DateTime() : null
            };
        }

        public static BLL.Entities.Cocktail ToBLL(this D.Cocktail _cocktail) 
        {
            if(_cocktail is null) throw new ArgumentNullException(nameof(_cocktail));
            return new BLL.Entities.Cocktail(
                _cocktail.Cocktail_id,
                _cocktail.Name,
                _cocktail.Description,
                _cocktail.Instructions,
                DateOnly.FromDateTime(_cocktail.CreatedAt),
                _cocktail.CreatedBy
                );
        }

        public static D.Cocktail ToDAL(this BLL.Entities.Cocktail _cocktail) 
        {
            if (_cocktail is null) throw new ArgumentNullException(nameof (_cocktail));
            return new D.Cocktail()
            {
                Cocktail_id = _cocktail.Cocktail_id,
                Name = _cocktail.Name,
                Description = _cocktail.Description,
                Instructions = _cocktail.Instructions,
                CreatedAt = _cocktail.CreatedAt.ToDateTime(new TimeOnly()),
                CreatedBy = _cocktail.CreatedBy,

            };
        }
    }
}
