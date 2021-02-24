namespace Recipes.Data.Models.Base
{
    using System;

    public class Entity : IEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
