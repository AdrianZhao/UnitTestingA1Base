using Microsoft.AspNetCore.Mvc;
using UnitTestingA1Base.Data;
using UnitTestingA1Base.Models;
using static UnitTestingA1Base.Data.BusinessLogicLayer;

namespace RecipeUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private BusinessLogicLayer _initializeBusinessLogic()
        {
            return new BusinessLogicLayer(new AppStorage());
        }

        [TestMethod]
        public void GetRecipesByIngredient_ValidId_ReturnsRecipesWithIngredient()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 6;
            int recipeCount = 2;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIngredient(ingredientId, null);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByIngredient_ValidName_ReturnsRecipesWithIngredient()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string ingredientName = "Spa";
            int recipeCount = 1;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIngredient(null, ingredientName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }
        
        [TestMethod]
        public void GetRecipesByIngredient_InvalidId_ReturnsNotFound()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 11;

            // Act and Assert            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                bll.GetRecipesByIngredient(ingredientId, null);
            });
        }
        
        [TestMethod]
        public void GetRecipesByIngredient_InvalidName_ReturnsEmptyCollection()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string ingredientName = "LOL";        
            int recipeCount = 0;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIngredient(null, ingredientName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);                     
        }
        
        [TestMethod]
        public void GetRecipesByIngredient_InvalidIdWithValidName_ReturnsRecipesWithIngredient()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 11;
            string ingredientName = "Spa";
            int recipeCount = 1;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIngredient(ingredientId, ingredientName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByIngredient_InvalidIdWithInvalidName_ReturnsEmptyCollection()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 11;
            string ingredientName = "LOL";
            int recipeCount = 0;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIngredient(ingredientId, ingredientName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByIngredient_ValidIdWithValidName_ReturnsRecipesWithIngredient()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 6;
            string ingredientName = "Spa";
            int recipeCount = 2;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIngredient(ingredientId, ingredientName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByIngredient_ValidIdWithInvalidName_ReturnsRecipesWithIngredient()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 6;
            string ingredientName = "LOL";
            int recipeCount = 2;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIngredient(ingredientId, ingredientName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByDietary_ValidId_ReturnsRecipesWithDietary()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int dietaryId = 1;
            int recipeCount = 2;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByDietary(dietaryId, null);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByDietary_ValidName_ReturnsRecipesWithDietary()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string dietaryName = "Vegetarian";
            int recipeCount = 2;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByDietary(null, dietaryName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByDietary_InvalidId_ReturnsNotFound()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int dietaryId = 6;
            // Act and Assert            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                bll.GetRecipesByDietary(dietaryId, null);
            });
        }

        [TestMethod]
        public void GetRecipesByDietary_InvalidName_ReturnsEmptyCollection()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string dietaryName = "LOL";
            int recipeCount = 0;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByDietary(null, dietaryName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByDietary_InvalidIdWithValidName_ReturnsRecipesWithDietary()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int dietaryId = 6;
            string dietaryName = "Vegetarian";
            int recipeCount = 2;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByDietary(dietaryId, dietaryName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByDietary_InvalidIdWithInvalidName_ReturnsEmptyCollection()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int dietaryId = 6;
            string dietaryName = "LOL";
            int recipeCount = 0;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByDietary(dietaryId, dietaryName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByDietary_ValidIdWithValidName_ReturnsRecipesWithDietary()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int dietaryId = 1;
            string dietaryName = "Vegetarian";
            int recipeCount = 2;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByDietary(dietaryId, dietaryName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByDietary_ValidIdWithInvalidName_ReturnsRecipesWithDietary()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int dietaryId = 1;
            string dietaryName = "LOL";
            int recipeCount = 2;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByDietary(dietaryId, dietaryName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByIdOrName_ValidId_ReturnsRecipesWithId()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 1;
            int recipeCount = 1;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIdOrName(recipeId, null);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByIdOrName_ValidName_ReturnsRecipesWithDietary()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string recipeName = "Spaghetti Carbonara";
            int recipeCount = 1;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIdOrName(null, recipeName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByIdOrName_InvalidId_ReturnsNotFound()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 13;
            // Act and Assert            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                bll.GetRecipesByIdOrName(recipeId, null);
            });
        }

        [TestMethod]
        public void GetRecipesByIdOrName_InvalidName_ReturnsEmptyCollection()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string recipeName = "LOL";
            int recipeCount = 0;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIdOrName(null, recipeName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByIdOrName_InvalidIdWithValidName_ReturnsRecipesWithDietary()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 13;
            string recipeName = "Spaghetti Carbonara";
            int recipeCount = 1;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIdOrName(recipeId, recipeName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByIdOrName_InvalidIdWithInvalidName_ReturnsEmptyCollection()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 13;
            string recipeName = "LOL";
            int recipeCount = 0;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIdOrName(recipeId, recipeName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByIdOrName_ValidIdWithValidName_ReturnsRecipesWithDietary()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 1;
            string recipeName = "Spaghetti Carbonara";
            int recipeCount = 1;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIdOrName(recipeId, recipeName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        [TestMethod]
        public void GetRecipesByIdOrName_ValidIdWithInvalidName_ReturnsRecipesWithDietary()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 1;
            string recipeName = "LOL";
            int recipeCount = 1;
            // Act
            HashSet<Recipe> recipes = bll.GetRecipesByIdOrName(recipeId, recipeName);
            // Assert
            Assert.AreEqual(recipeCount, recipes.Count);
        }

        private CreateRecipeModel CreateRecipe(Recipe recipe, HashSet<Ingredient> ingredients)
        {
            return new CreateRecipeModel
            {
                Recipe = recipe,
                Ingredients = ingredients
            };
        }

        [TestMethod]
        public void CreateNewRecipe_ValidRecipeNameWithNewIngredient_ReturnNewRecipe()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();          
            Recipe recipe = new Recipe
            {
                Name = "Cats' favorite",
                Description = "Cats really like this.",
                Servings = 4
            };
            HashSet<Ingredient> ingredients = new HashSet<Ingredient>
            {
                new Ingredient
                {
                    Name = "Tuna"
                },
                new Ingredient
                {
                    Name = "Chicken"
                },
            };
            // Act
            CreateRecipeModel createRecipeRequest = CreateRecipe(recipe, ingredients);
            bll.CreateNewRecipe(createRecipeRequest);
            HashSet<Recipe> getRecipe = bll.GetRecipesByIdOrName(256, null);
            // Assert
            if (getRecipe != null)
            {
                Assert.AreEqual(256, getRecipe.First().Id);
            }
        }

        [TestMethod]
        public void CreateNewRecipe_ValidRecipeNameWithExistingIngredient_ReturnNewRecipe()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            Recipe recipe = new Recipe
            {
                Name = "Cats' second favorite",
                Description = "Cats really like this too.",
                Servings = 1
            };
            HashSet<Ingredient> ingredients = new HashSet<Ingredient>
            {
                new Ingredient
                {
                    Name = "Salmon"
                },
            };
            // Act
            CreateRecipeModel createRecipeRequest = CreateRecipe(recipe, ingredients);
            bll.CreateNewRecipe(createRecipeRequest);
            HashSet<Recipe> getRecipe = bll.GetRecipesByIdOrName(256, null);
            // Assert
            if (getRecipe != null)
            {
                Assert.AreEqual(256, getRecipe.First().Id);
            }
        }

        [TestMethod]
        public void CreateNewRecipe_InvalidRecipeName_ReturnNotFound()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            Recipe recipe = new Recipe
            {
                Name = "Spaghetti Carbonara",
                Description = "Classic Roman pasta dish with eggs, cheese, and pancetta.",
                Servings = 2
            };
            HashSet<Ingredient> ingredients = new HashSet<Ingredient>
            {
                new Ingredient
                {
                    Name = "Spaghetti"
                },
            };
            // Act and Assert
            CreateRecipeModel createRecipeRequest = CreateRecipe(recipe, ingredients);
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                bll.CreateNewRecipe(createRecipeRequest);
            });            
        }

        [TestMethod]
        public void CreateNewRecipe_ValidRecipeNameWithoutIngredient_ReturnNotFound()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            Recipe recipe = new Recipe
            {
                Name = "Cats' third favorite",
                Description = "Cats really like this too too.",
                Servings = 1
            };
            HashSet<Ingredient> ingredients = new HashSet<Ingredient>();
            // Act and Assert
            CreateRecipeModel createRecipeRequest = CreateRecipe(recipe, ingredients);
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                bll.CreateNewRecipe(createRecipeRequest);
            });
        }

        [TestMethod]
        public void DeleteIngredients_ValidIdCanBeDelete_ReturnsOkMessage()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 1;
            // Act and Assert
            Assert.AreEqual("Ingredient and associated recipe deleted successfully", bll.DeleteIngredients(ingredientId, null));
        }

        [TestMethod]
        public void DeleteIngredients_ValidIdCantBeDelete_ReturnsOkMessage()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 6;
            // Act and Assert
            Assert.AreEqual("Ingredient is used in multiple recipes. Cannot delete.", bll.DeleteIngredients(ingredientId, null));
        }

        [TestMethod]
        public void DeleteIngredients_InvalidId_ReturnsNotFound()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 11;
            // Act and Assert            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                bll.DeleteIngredients(ingredientId, null);
            });
        }

        [TestMethod]
        public void DeleteIngredients_ValidNameCanBeDelete_ReturnsOkMessage()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string ingredientName = "Spaghetti";
            // Act and Assert
            Assert.AreEqual("Ingredient and associated recipe deleted successfully", bll.DeleteIngredients(null, ingredientName));
        }

        [TestMethod]
        public void DeleteIngredients_ValidNameCannotBeDelete_ReturnsOkMessage()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string ingredientName = "Salmon";
            // Act and Assert
            Assert.AreEqual("Ingredient is used in multiple recipes. Cannot delete.", bll.DeleteIngredients(null, ingredientName));
        }

        [TestMethod]
        public void DeleteIngredients_InvalidName_ReturnsNotFound()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string ingredientName = "LOL";
            // Act and Assert            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                bll.DeleteIngredients(null, ingredientName);
            });
        }

        [TestMethod]
        public void DeleteIngredients_InvalidIdValidNameCanBeDelete_ReturnsOkMessage()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 11;
            string ingredientName = "Spaghetti";            
            // Act and Assert
            Assert.AreEqual("Ingredient and associated recipe deleted successfully", bll.DeleteIngredients(ingredientId, ingredientName));
        }
        
        [TestMethod]
        public void DeleteIngredients_InvalidIdValidNameCannotBeDelete_ReturnsOkMessage()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 11;
            string ingredientName = "Salmon";
            // Act and Assert
            Assert.AreEqual("Ingredient is used in multiple recipes. Cannot delete.", bll.DeleteIngredients(ingredientId, ingredientName));
        }

        [TestMethod]
        public void DeleteIngredients_InvalidIdInvalidName_ReturnsNotFound()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 11;
            string ingredientName = "LOL";
            // Act and Assert            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                bll.DeleteIngredients(ingredientId, ingredientName);
            });
        }
      
        [TestMethod]
        public void DeleteRecipe_ValidId_ReturnsOkMessage()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 1;
            // Act and Assert
            Assert.AreEqual("Recipe and associated IngredientRecipe objects deleted successfully", bll.DeleteRecipe(recipeId, null));
        }

        [TestMethod]
        public void DeleteRecipe_InvalidId_ReturnsNotFound()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 13;
            // Act and Assert            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                bll.DeleteRecipe(recipeId, null);
            });
        }

        [TestMethod]
        public void DeleteRecipe_ValidName_ReturnsOkMessage()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string recipeName = "Spaghetti Carbonara";
            // Act and Assert
            Assert.AreEqual("Recipe and associated IngredientRecipe objects deleted successfully", bll.DeleteRecipe(null, recipeName));
        }

        [TestMethod]
        public void DeleteRecipe_InvalidName_ReturnsNotFound()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string recipeName = "LOL";
            // Act and Assert            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                bll.DeleteRecipe(null, recipeName);
            });
        }

        [TestMethod]
        public void DeleteRecipe_InvalidIdValidName_ReturnsOkMessage()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 13;
            string recipeName = "Spaghetti Carbonara";
            // Act and Assert
            Assert.AreEqual("Recipe and associated IngredientRecipe objects deleted successfully", bll.DeleteRecipe(recipeId, recipeName));
        }

        [TestMethod]
        public void DeleteRecipe_InvalidIdInvalidName_ReturnsNotFound()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string recipeName = "LOL";
            int recipeId = 13;
            // Act and Assert            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                bll.DeleteRecipe(recipeId, recipeName);
            });
        }

        [TestMethod]
        public void DeleteRecipe_ValidIdValidName_ReturnsOkMessage()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 1;
            string recipeName = "Spaghetti Carbonara";          
            // Act and Assert
            Assert.AreEqual("Recipe and associated IngredientRecipe objects deleted successfully", bll.DeleteRecipe(recipeId, recipeName));
        }

        [TestMethod]
        public void DeleteRecipe_ValidIdInvalidName_ReturnsOkMessage()
        {
            // Arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 1;
            string recipeName = "LOL";         
            // Act and Assert
            Assert.AreEqual("Recipe and associated IngredientRecipe objects deleted successfully", bll.DeleteRecipe(recipeId, recipeName));
        }
    }
}