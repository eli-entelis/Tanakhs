using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TanakhsApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }

        public string Email { get; set; }
        public string? ProfilePictureUrl { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public Religion Religion { get; set; }
        public Role Role { get; set; }

        public bool IsSubscribed { get; set; }
        public DateTime SignInDate { get; set; }

        //public ICollection<Chapter>? Chapters { get; set; }

        [NotMapped]
        public ICollection<int>? LikedChapters { get; set; }

        [NotMapped]
        public ICollection<int>? LikedComments { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other,
        None
    }

    public enum Religion
    {
        Judaism,
        Christianity,
        Islam,
        Atheist
    }

    public enum Role
    {
        Default,
        Admin
    }
}
