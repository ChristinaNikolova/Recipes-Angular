namespace Recipes.Data.Models.Base
{
    using System;

    public class DeletableEntity : Entity, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
