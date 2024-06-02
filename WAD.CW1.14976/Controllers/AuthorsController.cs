using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CW1._14976.DTOs;
using WAD.CW1._14976.Interfaces;
using WAD.CW1._14976.Models;

namespace WAD.CW1._14976.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorRepository.GetAllAsync();
            var authorsDTO = _mapper.Map<IEnumerable<AuthorDTO>>(authors);
            return Ok(authorsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            var authorDTO = _mapper.Map<AuthorDTO>(author);
            return Ok(authorDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            await _authorRepository.AddAsync(author);
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, authorDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AuthorDTO authorDTO)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            _mapper.Map(authorDTO, author);
            await _authorRepository.UpdateAsync(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            await _authorRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
