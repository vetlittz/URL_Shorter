namespace URL_Shorter.Server.Services
{
    public interface IAboutService
    {
        Task<string> GetDescriptionAsync();
        Task UpdateDescriptionAsync(string description);
    }

}
