using System.ComponentModel;

namespace ASP_MVC.Models.Cocktail
{
    public class CocktailCreateForm
    {

        [DisplayName("Nom du Cocktail : ")]
        public string NameCocktail { get; set; }

        [DisplayName("Description : ")]
        public string DescriptionCocktail { get; set;}

        [DisplayName ("Instruction : ")]
        public string InstructionCocktail { get; set;}
    }
}
