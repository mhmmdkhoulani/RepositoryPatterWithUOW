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
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Authors.GetById(id));
        }
        [HttpGet("GetByName/{name}")]
        public IActionResult GetById(string name)
        {
            return Ok(_unitOfWork.Authors.Find(b => b.Name == name, new string[] {"Author"}));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Authors.GetAll());
        }

        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            var result = _unitOfWork.Authors.Add(author);
            _unitOfWork.Complete();
            return Ok(author);
        }
    }
}
