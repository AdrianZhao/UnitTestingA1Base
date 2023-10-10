using System.Xml.Linq;
using UnitTestingA1Base.Models;

namespace UnitTestingA1Base.Data
{
    public class BusinessLogicLayer
    {
        private AppStorage _appStorage;

        public BusinessLogicLayer(AppStorage appStorage)
        {
            _appStorage = appStorage;
        }

        public HashSet<Recipe> GetRecipesByIngredient(int? id, string? name)
        {
            Ingredient ingredient;
            HashSet<Recipe> recipes = new HashSet<Recipe>();
            if (id != null)
            {
                ingredient = _appStorage.Ingredients.FirstOrDefault(i => i.Id == id);
                if (ingredient != null)
                {
                    HashSet<RecipeIngredient> recipeIngredients = _appStorage.RecipeIngredients.Where(rI => rI.IngredientId == ingredient.Id).ToHashSet();
                    recipes = _appStorage.Recipes.Where(r => recipeIngredients.Any(ri => ri.RecipeId == r.Id)).ToHashSet();
                }
            }
            if (recipes.Count == 0&& string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(id), "Can't find with the primary key.");
            }
            if (recipes.Count == 0 && !string.IsNullOrEmpty(name))
            {
                ingredient = _appStorage.Ingredients.FirstOrDefault(i => i.Name.Contains(name));
                if (ingredient != null)
                {
                    HashSet<RecipeIngredient> recipeIngredients = _appStorage.RecipeIngredients.Where(rI => rI.IngredientId == ingredient.Id).ToHashSet();
                    recipes = _appStorage.Recipes.Where(r => recipeIngredients.Any(ri => ri.RecipeId == r.Id)).ToHashSet();
                }
            }
            return recipes;
        }

        public HashSet<Recipe> GetRecipesByDietary(int? id, string? name)
        {
            HashSet<Recipe> recipes = new HashSet<Recipe>();
            if (id != null)
            {
                DietaryRestriction dietaryRestriction = _appStorage.DietaryRestrictions.FirstOrDefault(d => d.Id == id);
                if (dietaryRestriction != null)
                {
                    HashSet<IngredientRestriction> ingredientRestrictions = _appStorage.IngredientRestrictions.Where(ir => ir.DietaryRestrictionId == dietaryRestriction.Id).ToHashSet();
                    HashSet<Ingredient> ingredients = new HashSet<Ingredient>();
                    foreach (IngredientRestriction ingredientRestriction in ingredientRestrictions)
                    {
                        Ingredient ingredientToAdd = _appStorage.Ingredients.FirstOrDefault(i => i.Id == ingredientRestriction.IngredientId);
                        if (ingredientToAdd != null)
                        {
                            ingredients.Add(ingredientToAdd);
                        }
                    }
                    HashSet<RecipeIngredient> theRecipe = new HashSet<RecipeIngredient>();
                    foreach (Ingredient theIngredient in ingredients)
                    {
                        RecipeIngredient recipeIngredient = _appStorage.RecipeIngredients.FirstOrDefault(ri => ri.IngredientId == theIngredient.Id);
                        if (recipeIngredient != null)
                        {
                            theRecipe.Add(recipeIngredient);
                        }
                    }
                    foreach (RecipeIngredient recipeIngredient in theRecipe)
                    {
                        Recipe recipeToAdd = _appStorage.Recipes.FirstOrDefault(r => r.Id == recipeIngredient.RecipeId);
                        if (recipeToAdd != null)
                        {
                            recipes.Add(recipeToAdd);
                        }
                    }
                }
            }
            if (recipes.Count == 0 && string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(id), "Can't find with the primary key.");
            }
            if (recipes.Count == 0 && !string.IsNullOrEmpty(name))
            {
                DietaryRestriction dietaryRestriction = _appStorage.DietaryRestrictions.FirstOrDefault(d => d.Name.Contains(name));
                if (dietaryRestriction != null)
                {
                    HashSet<IngredientRestriction> ingredientRestrictions = _appStorage.IngredientRestrictions.Where(ir => ir.DietaryRestrictionId == dietaryRestriction.Id).ToHashSet();
                    HashSet<Ingredient> ingredients = new HashSet<Ingredient>();
                    foreach (IngredientRestriction ingredientRestriction in ingredientRestrictions)
                    {
                        Ingredient ingredientToAdd = _appStorage.Ingredients.FirstOrDefault(i => i.Id == ingredientRestriction.IngredientId);
                        if (ingredientToAdd != null)
                        {
                            ingredients.Add(ingredientToAdd);
                        }
                    }
                    HashSet<RecipeIngredient> theRecipe = new HashSet<RecipeIngredient>();
                    foreach (Ingredient theIngredient in ingredients)
                    {
                        RecipeIngredient recipeIngredient = _appStorage.RecipeIngredients.FirstOrDefault(ri => ri.IngredientId == theIngredient.Id);
                        if (recipeIngredient != null)
                        {
                            theRecipe.Add(recipeIngredient);
                        }
                    }
                    foreach (RecipeIngredient recipeIngredient in theRecipe)
                    {
                        Recipe recipeToAdd = _appStorage.Recipes.FirstOrDefault(r => r.Id == recipeIngredient.RecipeId);
                        if (recipeToAdd != null)
                        {
                            recipes.Add(recipeToAdd);
                        }
                    }
                }
            }
            return recipes;
        }

        public HashSet<Recipe> GetRecipesByIdOrName(int? id, string? name)
        {
            HashSet<Recipe> recipes = new HashSet<Recipe>();
            if (id != null)
            {
                recipes = _appStorage.Recipes.Where(r => r.Id == id).ToHashSet();
            }
            if (recipes.Count == 0 && string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(id), "Can't find with the primary key.");
            }
            if (recipes.Count == 0 && !string.IsNullOrEmpty(name))
            {
                recipes = _appStorage.Recipes.Where(r => r.Name.Contains(name)).ToHashSet();
            }
            return recipes;
        }

        public class CreateRecipeModel
        {
            public Recipe Recipe { get; set; }
            public HashSet<Ingredient> Ingredients { get; set; }
        }

        public void CreateNewRecipe(CreateRecipeModel crm)
        {
            if (_appStorage.Recipes.Any(r => r.Name == crm.Recipe.Name))
            {
                throw new InvalidOperationException($"The recipe name '{crm.Recipe.Name}' has been used.");
            }
            if (crm.Ingredients.Count() == 0)
            {
                throw new InvalidOperationException("This recipe does not have any ingredients.");
            }
            Recipe newRecipe = new Recipe
            {
                Id = _appStorage.GeneratePrimaryKey(),
                Name = crm.Recipe.Name,
                Description = crm.Recipe.Description,
                Servings = crm.Recipe.Servings
            };
            HashSet<Ingredient> newIngredients = new HashSet<Ingredient>();
            foreach (Ingredient ingredient in crm.Ingredients)
            {
                Ingredient existingIngredient = _appStorage.Ingredients.FirstOrDefault(i => i.Name == ingredient.Name);
                if (existingIngredient == null)
                {
                    existingIngredient = new Ingredient
                    {
                        Id = _appStorage.GeneratePrimaryKey(),
                        Name = ingredient.Name
                    };
                }
                newIngredients.Add(existingIngredient);
                RecipeIngredient recipeIngredient = new RecipeIngredient
                {
                    RecipeId = newRecipe.Id,
                    IngredientId = existingIngredient.Id
                };
                _appStorage.RecipeIngredients.Add(recipeIngredient);
            }
            _appStorage.Recipes.Add(newRecipe);
            foreach (Ingredient ingredient in newIngredients)
            {
                if (!_appStorage.Ingredients.Contains(ingredient))
                {
                    _appStorage.Ingredients.Add(ingredient);
                }
            }
        }

        public string DeleteIngredients(int? id, string? name)
        {
            Ingredient ingredientToDelete = null;
            if (id != null)
            {
                ingredientToDelete = _appStorage.Ingredients.FirstOrDefault(i => i.Id == id);
            }
            if (ingredientToDelete == null && !string.IsNullOrEmpty(name)) 
            {
                ingredientToDelete = _appStorage.Ingredients.FirstOrDefault(i => i.Name.Contains(name));
            }
            if (ingredientToDelete == null)
            {
                throw new ArgumentNullException(nameof(id), "Can't find with the primary key.");
            }
            int recipesCount = _appStorage.RecipeIngredients.Count(rI => rI.IngredientId == ingredientToDelete.Id);
            if (recipesCount == 1)
            {
                RecipeIngredient recipeIngredientToDelete = _appStorage.RecipeIngredients.FirstOrDefault(ri => ri.IngredientId == ingredientToDelete.Id);
                Recipe recipeToDelete = _appStorage.Recipes.FirstOrDefault(r => r.Id == recipeIngredientToDelete.RecipeId);
                _appStorage.RecipeIngredients.Remove(recipeIngredientToDelete);
                _appStorage.Recipes.Remove(recipeToDelete);
                _appStorage.Ingredients.Remove(ingredientToDelete);
                return "Ingredient and associated recipe deleted successfully";
            }
            else
            {
                return "Ingredient is used in multiple recipes. Cannot delete.";
            }
        }

        public string DeleteRecipe(int? id, string? name)
        {
            Recipe recipeToDelete = null;
            if (id != null)
            {
                recipeToDelete = _appStorage.Recipes.FirstOrDefault(i => i.Id == id);
            }           
            if (recipeToDelete == null && !string.IsNullOrEmpty(name))
            {
                recipeToDelete = _appStorage.Recipes.FirstOrDefault(i => i.Name.Contains(name));
            }
            if (recipeToDelete == null)
            {
                throw new ArgumentNullException(nameof(id), "Can't find with the primary key.");
            }
            HashSet<RecipeIngredient> recipeIngredientsToDelete = _appStorage.RecipeIngredients.Where(ir => ir.RecipeId == recipeToDelete.Id).ToHashSet();
            foreach (RecipeIngredient recipeIngredient in recipeIngredientsToDelete)
            {
                _appStorage.RecipeIngredients.Remove(recipeIngredient);
            }
            _appStorage.Recipes.Remove(recipeToDelete);
            return "Recipe and associated IngredientRecipe objects deleted successfully";
        }
    }
}