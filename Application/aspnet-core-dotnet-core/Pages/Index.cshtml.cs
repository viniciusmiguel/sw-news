using System.Collections.Generic;
using System.Threading.Tasks;
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

        public IEnumerable<NewsViewModel> NewsCollection;
        public async Task OnGetAsync()
        {
            this.NewsCollection = await _newsAppService.GetAll();
        }
        public string DoTest()
        {
            return "Index";
        }
    }
}