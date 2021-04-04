using Microsoft.AspNetCore.Mvc;
using Skyworkz.News.Application;
using Skyworkz.News.ViewModels;
using System;
using System.Collections.Generic;

namespace Skyworkz.News.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsAppService _newsAppService;
        public NewsController(INewsAppService newsAppService)
        {
            _newsAppService = newsAppService;
        }
        // GET: api/<NewsController>
        [HttpGet]
        public IEnumerable<NewsViewModel> Get()
        {
            return _newsAppService.GetAll();
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public NewsViewModel Get(Guid id)
        {
            return _newsAppService.GetById(id);
        }

        // POST api/<NewsController>
        [HttpPost]
        public void Post([FromBody] NewsViewModel news)
        {
            _newsAppService.Create(news);
        }
    }
}
