using System;
using System.ComponentModel.DataAnnotations;


namespace Skyworkz.News.ViewModels
{
    public class NewsViewModel
    {
        [Required(ErrorMessage = "A Title is mandatory to the news article")]
        public string Title { get; set; }
        [Required(ErrorMessage = "A Description is mandatory to the news article")]
        public string Description { get; set; }
        public DateTime When { get; set; }
    }
}
