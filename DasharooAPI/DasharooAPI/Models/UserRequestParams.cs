namespace DasharooAPI.Models
{
    public class UserRequestParams
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = null!;
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
