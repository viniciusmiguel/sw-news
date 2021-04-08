using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Skyworkz.News.Application;
using Skyworkz.News.ViewModels;

namespace Skyworkz.News.Pages
{
    public class AddnewsModel : PageModel
    {
        private readonly INewsAppService _newsAppService;
        
        [BindProperty] 
        public NewsViewModel ViewModel { get; set; }

        public AddnewsModel(INewsAppService newsAppService)
        {
            _newsAppService = newsAppService;
            ViewModel = new NewsViewModel();
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _newsAppService.Create(ViewModel);
                    return RedirectToPage("Index");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Page();
        }
    }
}
