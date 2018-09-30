using Application.Sales.Services;
using Domain.Sales.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesAppService _salesAppService;

        public SalesController(ISalesAppService salesAppService)
        {
            _salesAppService = salesAppService;
        }

        [HttpGet("{orderNumber}/{Quantity}")]
        public Sale Get(int orderNumber, int quantity)
        {
            var sale = new Sale(orderNumber, quantity);

            _salesAppService.MakeSale(sale);

            return sale;
        }
    }
}