using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Skyworkz.News.Application;
using Skyworkz.News.ViewModels;

namespace Skyworkz.News.Pages
{
    public class IndexModel : PageModel
    {
        private readonly INewsAppService _newsAppService;
        public IndexModel(INewsAppService newsAppService)
        {
            _newsAppService = newsAppService;
        }

        [BindProperty]
        public IEnumerable<NewsViewModel> NewsCollection { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            this.NewsCollection = await _newsAppService.GetAll();
            return Page();
        }
        public string DoTest()
        {
            return "Index";
        }
    }
}