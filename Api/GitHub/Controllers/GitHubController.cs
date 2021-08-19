using GitHubIntegration.Models;
using GitHubIntegration.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GitHubIntegration.Controllers
{
    [Route("api/repositories")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        RepositoryService Service;

        public GitHubController() => Service = new RepositoryService("takenet");


        // GET: api/<GitHubController>
        [HttpGet]
        public IEnumerable<Repository> Get() => Service.GetAll();

        // GET api/<GitHubController>/5
        [HttpGet("{language}")]
        public IEnumerable<Repository> Get(string language) => Service.GetByLanguage(language);

    }
}
