using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CW1._14976.DTOs;
using WAD.CW1._14976.Interfaces;
using WAD.CW1._14976.Models;

namespace WAD.CW1._14976.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAllAsync();
            var booksDTO = _mapper.Map<IEnumerable<BookDTO>>(books);
            return Ok(booksDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookDTO = _mapper.Map<BookDTO>(book);
            return Ok(bookDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            await _bookRepository.AddAsync(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, bookDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookDTO bookDTO)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _mapper.Map(bookDTO, book);
            await _bookRepository.UpdateAsync(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
