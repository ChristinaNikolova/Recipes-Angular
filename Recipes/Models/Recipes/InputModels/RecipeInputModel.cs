namespace Recipes.Models.Recipes.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class RecipeInputModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(5000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]

        public string Content { get; set; }

        [Required]

        public string Picture { get; set; }

        [Range(typeof(int), "1", "2147483647")]
        public int Portions { get; set; }

        [Range(typeof(int), "1", "2147483647")]
        public int PreparationTime { get; set; }

        [Range(typeof(int), "1", "2147483647")]
        public int CookingTime { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
