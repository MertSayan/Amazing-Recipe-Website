using Domain;

namespace Application.Features.Mediatr.Users.Results
{
    public class GetUserQueryResult
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string? UserImageUrl { get; set; }
    }
}
