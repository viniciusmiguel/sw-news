using System.Collections.Generic;
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

        public IEnumerable<NewsViewModel> NewsCollection => _newsAppService.GetAll();
        public void OnGet()
        {

        }
        public string DoTest()
        {
            return "Index";
        }
    }
}