using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using URL_Shorter.Server.Services;

[Authorize]
public class AboutModel : PageModel
{
    private readonly IAboutService _aboutService;

    public AboutModel(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    [BindProperty]
    public string Description { get; set; }

    public async Task OnGetAsync()
    {
        Description = await _aboutService.GetDescriptionAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (User.IsInRole("Admin"))
        {
            await _aboutService.UpdateDescriptionAsync(Description);
            return RedirectToPage();
        }
        else
        {
            return Forbid();
        }
    }
}