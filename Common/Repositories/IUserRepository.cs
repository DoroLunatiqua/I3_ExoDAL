using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IUserRepository<TUser>
    {
        IEnumerable<TUser> Get();//ensemble des user (liste )
        TUser Get(Guid id); // recherche un seul parmis la liste grace a l'ID
        Guid Insert(TUser user); // creer 
        void Update(Guid id, TUser user);
        void Delete(Guid id);
        Guid CheckPassword(string email, string password);//specifique au login , fct qui verifie le pw
    }
}
