using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersService.Models;
using OrdersService.Repositories;

namespace OrdersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        public OrderController(IOrderRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("GetOrders")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.GetAllOrders());
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);

            }
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_repo.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);

            }
        }



        [HttpPost]
        [Route("AddItem")]
        public IActionResult Post(Orders order)
        {
            try
            {
                _repo.AddOrder(order);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);

            }

        }
        //[HttpPut]
        //[Route("updateitem")]
        //public IActionResult Update(Items item)
        //{
        //    try
        //    {
        //        _repo.UpdateItem(item);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.InnerException.Message);

        //    }


        //}


        [HttpDelete]
        [Route("Deleteitem/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _repo.DeleteOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);

            }
        }


    }
}
