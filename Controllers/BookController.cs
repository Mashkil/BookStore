using AutoMapper;
using BookStore.Data.Entities;
using BookStore.Data.Models;
using BookStore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public BookController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавляет книгу
        /// </summary>
        /// <param name="bookToAdd">Объект книги</param>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost("CreateBook")]
        public async Task CreateBook([FromBody] BookModel bookToAdd)
        {
            await _repositoryManager.Book.CreateBook(_mapper.Map<Book>(bookToAdd));
        }

        /// <summary>
        /// возвращает все книги по названию и дате выхода
        /// </summary>
        /// <param name="title">название книги</param>
        /// <param name="year">год выхода</param>
        [ProducesResponseType(typeof(List<Book>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("FindWithFilters/{title}/{year}")]
        public async Task<List<Book>> FindWithFilters(string title, int year)
        {
            DateTimeOffset date = new(year, 01, 01, 1, 1, 1, new TimeSpan());

            return await _repositoryManager.Book.FindWithFilters(title, date);

        }

        /// <summary>
        /// возвращает полную информацию по id книги
        /// </summary>
        /// <param name="id">название книги</param>
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("GetFullInfo/{id}")]
        public async Task<Book> GetFullInfo(int id)
        {
            return await _repositoryManager.Book.GetFullInfo(id);
        }
    }
}
