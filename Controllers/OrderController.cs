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
    public class OrderController
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Создает заказ и возвращает его ID
        /// </summary>
        /// <param name="orderModel">Номер заказа</param>
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost("CreateOrder/{orderModel}")]
        public async Task<int> CreateOrder(int orderModel)
        {
            return await _repositoryManager.Order.CreateOrder(orderModel);
        }

        /// <summary>
        /// Добавляет книгу в заказ
        /// </summary>
        /// <param name="orderId">Id заказа</param>
        /// <param name="bookId">Id книги</param>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost("AddBookInOrder/{orderId}/{bookId}")]
        public async Task AddBookInOrder(int orderId, int bookId)
        {
            await _repositoryManager.Order.AddBookInOrder(orderId, bookId);
        }

        /// <summary>
        /// Получение списка заказов 
        /// </summary>
        /// <param name="orderId">Id заказа</param>
        /// <param name="date">Дата заказа</param>
        [ProducesResponseType(typeof(List<OutputOrder>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("FindWithFilters/{orderId}/{date}")]
        public async Task<List<OutputOrder>> FindWithFilters(int orderId, DateTime date)
        {
            return await _repositoryManager.Order.FindWithFilters(orderId, date);
        }
    }
}
