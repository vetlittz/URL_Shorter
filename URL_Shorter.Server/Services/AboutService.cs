namespace URL_Shorter.Server.Services
{
    public class AboutService : IAboutService
    {
        private static string _description = "This is a URL Shortener algorithm that takes a long URL and creates a shorter, unique URL.";

        public Task<string> GetDescriptionAsync()
        {
            return Task.FromResult(_description);
        }

        public Task UpdateDescriptionAsync(string description)
        {
            _description = description;
            return Task.CompletedTask;
        }
    }

}
