

namespace Prog6221_Part_2_VuyoNeoMokoatle_ST10194124
{
    internal class UnitTest
    {

        [TestClass]
        public class RecipeTests
        {
            public object Assert { get; private set; }

            [TestMethod]
            public void CalculateTotalCalories_WithValidIngredients_ReturnsCorrectTotalCalories()
            {
                // Arrange
                var recipe = new Recipe();
                var ingredients = new List<Ingredient>
        {
            new Ingredient("Flour", 200, "g", 364, "Grains"),
            new Ingredient("Sugar", 100, "g", 387, "Sweets"),
            new Ingredient("Butter", 50, "g", 717, "Dairy"),
        };
                recipe.Ingredients.AddRange(ingredients);

                // Act
                var totalCalories = recipe.CalculateTotalCalories();

                // Assert
                Assert.AreEqual((200 * 364) + (100 * 387) + (50 * 717), totalCalories);
            }
        }
    }

    internal class TestMethodAttribute : Attribute
    {
    }
}