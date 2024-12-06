using AppShop.Business;
using AppShop.Business.DataModel;
using AppShop.Business.Entity;
using AppShop.Business.Service;
using AppShop.Business.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppShop.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
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
    }
}