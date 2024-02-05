using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core.Constants;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.Core.Repositories;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> _repo;

        public BooksController(IBaseRepository<Book> repo)
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
            return Ok(_repo.Find(b => b.Title == name,new string[] { "Author" }));
        }



        [HttpGet("GetAll")]
        public IActionResult GetAllWithAuthor(string name)
        {
            return Ok(_repo.FindAll(b => b.Title == name, new string[] { "Author" }));
        }

        [HttpGet("GetOrdered")]
        public IActionResult GetAllWithAuthorOrderd(string name)
        {
            return Ok(_repo.FindAll(b => b.Title == name, null, null, b => b.Id, OrderBy.Descending));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            return Ok(_repo.Add(book));
        }
    }
}
