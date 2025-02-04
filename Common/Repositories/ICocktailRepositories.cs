using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface ICocktailRepository<TCocktail> : ICRUDRepository<TCocktail, Guid>
    {
        //IEnumerable<TCocktail> Get();//ensemble des user (liste )
        IEnumerable<TCocktail> GetByUser(Guid userId);
       // TCocktail Get(Guid id); // recherche un seul parmis la liste grace a l'ID
        //Guid Insert(TCocktail user); // creer 
        //void Update(Guid id, TCocktail user);
        //void Delete(Guid id);

    }
}
