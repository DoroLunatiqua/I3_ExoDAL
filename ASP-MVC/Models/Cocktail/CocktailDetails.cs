using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Cocktail
{
    public class CocktailDetails
    {
        [ScaffoldColumn(false)]

        public Guid CocktailId { get; set; }
        [DisplayName("Nom du Cocktail : ")]
        public string CocktailName { get; set; }

        [DisplayName (" Description : ")]
        public string CocktailDescription { get; set; }

        [DisplayName ("Instructions : ")]
        public string CocktailInstructions { get; set; }

        [DisplayName("Date de Création :  ")]
        [DataType(DataType.Date)]
        public DateOnly CreatedAt { get; set; }



    }
}
