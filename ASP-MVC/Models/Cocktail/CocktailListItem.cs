using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Cocktail
{
    public class CocktailListItem
    {
        [ScaffoldColumn(false)]
        public Guid Cocktail_id { get; set; }
        [DisplayName("Nom du Cocktail : ")]
        public string Cocktail_name { get; set; }
        [DisplayName("Description : ")]
        public string Cocktail_description { get; set; }
    }
}
