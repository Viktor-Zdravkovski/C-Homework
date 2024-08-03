using BurgerShop.Domain;
using BurgerShop.Dto.Dto;
using BurgerShop.Dto.ViewModels;
using BurgerShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShop.WebApp.Controllers
{
    [Route("")]
    public class BurgerShopController : Controller
    {
        private readonly IBurgerService _burgerService;
        private readonly IOrderService _orderService;
        private readonly IFilterService _filterService;

		public BurgerShopController(IBurgerService burgerService, IFilterService filterService, IOrderService orderService)
		{
			_burgerService = burgerService;
			_filterService = filterService;
			_orderService = orderService;
		}

		[HttpGet]
        public IActionResult Index()
        {
            int orderId = 0;
            int burgerId = 0;

            ViewBag.Filter = new FilterDto();

            if (TempData["HasFilter"] != null)
            {
                ViewBag.Filter.OrderId = (int?)TempData["Order"];
                orderId = (int)TempData["Order"];
                ViewBag.Filter.BurgerId = (int?)TempData["Burger"];
                burgerId = (int)TempData["Burger"];
            }

            ViewBag.Filter.Order = _filterService.GetOrders();
            ViewBag.Filter.Burger = _filterService.GetBurgers();

            var burgers = _burgerService.MostPopularBurer(burgerId);
            return View(burgers);
        }

        [HttpPost("filter")]
        public IActionResult Filter(FilterVM filterVM)
        {
            TempData["HasFilter"] = true;
            TempData["Order"] = filterVM.OrderId;
            TempData["Burger"] = filterVM.BurgerId;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("addOrder")]
        public IActionResult AddOrder()
        {
            ViewBag.Order = _filterService.GetOrders();
            return View("AddOrder");
        }

        [HttpPost("addOrder")]

        public IActionResult AddOrder(Order order)
        {
            if (order.Id == 0)
            {
                ViewBag.Error = "Please enter valid order";
                ViewBag.Orders = _filterService.GetOrders();
                return View(order);
            }

            _orderService.AddOrder(order);
            return RedirectToAction("Index");
        }

        [HttpGet("addBurger")]

        public IActionResult AddBurger()
        {
            ViewBag.Burger = _filterService.GetBurgers();
            return View("AddBurger");
        }

        [HttpPost("addBurger")]

        public IActionResult AddBurger(Burger burger)
        {
            if (burger.Id == 0)
            {
                ViewBag.Error = "Please enter valid burger";
                ViewBag.Burger = _filterService.GetBurgers();
                return View(burger);
            }

            _burgerService.AddBurger(burger);
            return RedirectToAction("Index");
        }
    }
}
