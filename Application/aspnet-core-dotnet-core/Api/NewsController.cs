using Microsoft.AspNetCore.Mvc;
using Skyworkz.News.Application;
using Skyworkz.News.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<NewsViewModel>> Get()
        {
            return await _newsAppService.GetAll();
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public async Task<NewsViewModel> Get(Guid id)
        {
            return await _newsAppService.GetById(id);
        }

        // POST api/<NewsController>
        [HttpPost]
        public async Task Post([FromBody] NewsViewModel news)
        {
            await _newsAppService.Create(news);
        }
    }
}
