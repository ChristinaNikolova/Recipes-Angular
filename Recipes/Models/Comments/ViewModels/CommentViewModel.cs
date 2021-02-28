namespace Recipes.Models.Comments.ViewModels
{
    using System;

    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FormattedCreatedOn =>
            this.CreatedOn.ToShortDateString();

        public string ClientUserName { get; set; }
    }
}
