namespace MCApplicationServices.Interfaces
{
    public interface IJWTAuthenticationManager
    {
        string? Authenticate(string clientId, string secret);
    }
}
