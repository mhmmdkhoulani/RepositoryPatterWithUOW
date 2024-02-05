using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.Core.Repositories;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBaseRepository<Author> _repo;

        public AuthorsController(IBaseRepository<Author> repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_repo.GetById(id));
        }
        [HttpGet("GetByName/{name}")]
        public IActionResult GetById(string name)
        {
            return Ok(_repo.Find(b => b.Name == name, new string[] {"Author"}));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            return Ok(_repo.Add(author));
        }
    }
}
