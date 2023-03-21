namespace OnlineTest.Services.DTO
{
    public class JWTConfigDTO
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Aud { get; set; }
    }
}
