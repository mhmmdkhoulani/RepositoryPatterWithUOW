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
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Books.GetById(id));
        }

        [HttpGet("GetByName/{name}")]
        public IActionResult GetById(string name)
        {
            return Ok(_unitOfWork.Books.Find(b => b.Title == name,new string[] { "Author" }));
        }



        [HttpGet("GetAll")]
        public IActionResult GetAllWithAuthor(string name)
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title == name, new string[] { "Author" }));
        }

        [HttpGet("GetOrdered")]
        public IActionResult GetAllWithAuthorOrderd(string name)
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title == name, null, null, b => b.Id, OrderBy.Descending));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            return Ok(_unitOfWork.Books.Add(book));
        }

        [HttpGet("special")]
        public IActionResult GetSpecial(Book book)
        {
            return Ok(_unitOfWork.Books.SpecialMethod());
        }
    }
}
