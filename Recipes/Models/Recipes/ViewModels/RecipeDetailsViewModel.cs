﻿namespace Recipes.Models.Recipes.ViewModels
{
    using System;
    using System.Collections.Generic;

    using global::Recipes.Data.Models;
    using global::Recipes.Models.Ingredients.InputModels;
    using global::Recipes.Services.Mapping;

    public class RecipeDetailsViewModel : RecipeBaseViewModel, IMapFrom<Recipe>
    {
        public int Portions { get; set; }

        public int PreparationTime { get; set; }

        public int CookingTime { get; set; }

        public string AuthorUserName { get; set; }

        public bool IsFavourite { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FormattedCreatedOn
            => this.CreatedOn.ToShortDateString();

        public IEnumerable<BaseIngredientViewModel> Ingredients { get; set; }
    }
}
