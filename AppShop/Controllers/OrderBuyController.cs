using AppShop.Business;
using AppShop.Business.DataModel;
using AppShop.Business.Entity;
using AppShop.Business.Service;
using AppShop.Business.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppShop.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class OrderBuyController : ControllerBase
    {

        private readonly IOrderBuyService service;
        private readonly ILogService logService;
        public OrderBuyController(IOrderBuyService _service, ILogService _logService)
        {
            service = _service;
            logService = _logService;
        }
        [HttpPost]
        public ActionResult Add(InOrderBuy input)
        {
            try
            {
                return Ok(service.Add(input));
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult ConfirmOrder(InId input)
        {
            try
            {
                service.ChangeShopStatues(input.Id, ShopStatues.Confirm);
                return Ok();
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult SendOrder(InId input)
        {
            try
            {
                service.ChangeShopStatues(input.Id, ShopStatues.Send);
                return Ok();
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult DeliveryOrder(InId input)
        {
            try
            {
                service.ChangeShopStatues(input.Id, ShopStatues.Delivery);
                return Ok();
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult RejectOrder(InId input)
        {
            try
            {
                service.ChangeShopStatues(input.Id, ShopStatues.Reject);
                return Ok();
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult GetAll(InputRequest inputRequest)
        {
            //push 25 aban 1403
            try
            {
                var param = new DataRequest(inputRequest.PageNumber, 100);
                return Ok(service.GetAll(param));
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult GetAllUser(InputRequest inputRequest)
        {
            try
            {
                var userId = 1;
                var param = new DataRequest(inputRequest.PageNumber, 100);
                return Ok(service.GetAllUser(param, userId));
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult GetById(int id)
        {
            try
            {
                return Ok(service.GetById(id));
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult GetDays()
        {
            try
            {
                return Ok(service.GetDays());
            }
            catch (Exception ex)
            {
                logService.Add(ex.Message, ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}