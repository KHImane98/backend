using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API1.ViewModels
{
    public class AuthViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponse
    {
        public DateTime Created { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
       
    }
    
    public class AuthToken
    {
        public string Exp { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }

    public class UserProfileViewModel
    {
        public string UserName { get; set; }
      
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


    }
    public class UserProfileResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string NewProfilePicture { get; set; }
    }

}