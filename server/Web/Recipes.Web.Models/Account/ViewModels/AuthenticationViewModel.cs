﻿namespace Recipes.Web.Models.Common.Account.ViewModels
{
    public class AuthenticationViewModel
    {
        public string Username { get; set; }

        public string Message { get; set; }

        public string Token { get; set; }

        public bool IsAdmin { get; set; }
    }
}
