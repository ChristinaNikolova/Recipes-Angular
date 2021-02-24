namespace Recipes.Data.Models.Base
{
    using System;

    public interface IEntity
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
