namespace CBTPreparation.Application.Model
{
    public class ApplicationUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
