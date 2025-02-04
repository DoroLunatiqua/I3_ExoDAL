using ASP_MVC.Models.Cocktail;

namespace ASP_MVC.Mappers
{
    internal static class CocktailMapper
    {
        public static CocktailListItem ToListItem(this BLL.Entities.Cocktail cocktail) 
        {
            if (cocktail == null) throw new ArgumentNullException(nameof(cocktail));
            return new CocktailListItem()
            {
                Cocktail_id=cocktail.Cocktail_id,
                Cocktail_name=cocktail.Name,
                Cocktail_description=(cocktail.Description is null)? null : cocktail.Description,
            };
        }

        public static CocktailDetails ToCocktailDetails(this BLL.Entities.Cocktail cocktail) 
        {
            if (cocktail == null) throw new ArgumentNullException(nameof(cocktail));
            return new CocktailDetails() 
            {
                CocktailName=cocktail.Name,
                CocktailDescription=cocktail.Description,
                CocktailInstructions=cocktail.Instructions,
                CreatedAt=cocktail.CreatedAt,

            } ;
        }
    }
}
