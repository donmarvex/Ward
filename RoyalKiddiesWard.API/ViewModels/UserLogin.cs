using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RoyalKiddiesWard.API.ViewModels
{
    public class UserLogin
    {
        
        [Required(ErrorMessage = "Please enter Email Address")]
        [DataType(DataType.EmailAddress)]
        [JsonPropertyName("email")]
        public string Email { get; set; }



        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

    }
}
