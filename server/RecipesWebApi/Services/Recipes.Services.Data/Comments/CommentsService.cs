namespace Recipes.Services.Data.Comments
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using global::Recipes.Data.Common.Repositories;
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> commentsRepository;

        public CommentsService(IRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task CreateAsync(string content, string recipeId, string userId)
        {
            var comment = new Comment()
            {
                Content = content,
                RecipeId = recipeId,
                ClientId = userId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllCurrentRecipeAsync<T>(string recipeId)
        {
            var comments = await this.commentsRepository
                .All()
                .Where(c => c.RecipeId == recipeId)
                .OrderByDescending(c => c.CreatedOn)
                .ThenBy(c => c.Client.UserName)
                .To<T>()
                .ToListAsync();

            return comments;
        }
    }
}
