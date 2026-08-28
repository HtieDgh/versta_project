using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using versta.Models;
using versta.Shared;
using versta.Views;

namespace versta.Controllers
{
    [Route("/")]
    public class MainController : Controller
    {
        private readonly IConfiguration configuration_;
        private readonly DatabaseConfig dbConfig_;

        public MainController(IConfiguration configuration)
        {
            configuration_ = configuration;
            dbConfig_ = new DatabaseConfig();
            configuration_.GetSection("DatabaseConnection").Bind(dbConfig_);
        }
        /// <summary>
        /// Редирект на форму заполнения заказа
        /// </summary>
        /// <response code="301">Редирект на форму</response>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return Redirect("/orders/new");
        }
        /// <summary>
        /// Отобразить список существующих заказов
        /// </summary>
        /// <returns></returns>
        [HttpGet("/orders")]
        public IActionResult GetOrderList()
        {
            using var db = new ApplicationContext(dbConfig_);
            var vm=new OrderListViewModel();
            vm.PopulateOrders(db,0,1000);
            return View("/Views/OrderList.cshtml", vm);
        }
        /// <summary>
        /// Отобразить форму создания заказа
        /// </summary>
        /// <returns></returns>
        [HttpGet("/orders/new")]
        public IActionResult GetOrderForm()
        {
            var vm = new OrderFormViewModel
            {
                ErrorMessage = (string?)TempData["ErrorMessage"],//вывести сообщение если есть
                SuccessMessage = (string?)TempData["SuccessMessage"],
                PickupDate = DateOnly.FromDateTime(DateTime.Now),//дата по умолчанию - сегодня
                Weight = 0.1m//Вес по умолчанию
            };
            return View("/Views/OrderForm.cshtml", vm);
        }
        /// <summary>
        /// Сохранить Заказ в БД и перенаправить на "/orders/new" вместе с сообщением о результате (через TempData)
        /// </summary>
        /// <param name="vm">Данные формы</param>
        /// <returns></returns>
        [HttpPost("/orders/new")]
        public async Task<IActionResult> SaveOrder(OrderFormViewModel vm)
        {
            using var db = new ApplicationContext(dbConfig_);
            try
            {
                if (!ModelState.IsValid)
                    throw new ArgumentException("Пожалуйста, исправьте ошибки в форме");
                if(//Адреса отправителя и получателя должны различаться
                    vm.SenderAddress == vm.RecipientAddress &&
                    vm.SenderCity == vm.RecipientCity
                ){
                    throw new ArgumentException("Адреса отправителя и получателя должны различаться");
                }
                if (vm.Weight < 0.1m && vm.Weight > 10000.0m)
                    throw new ArgumentException("Вес не может быть меньше 0.1 и больше 10000");

                //Проверка на существование отправителя и получателя
                var existingSender = db.Endpoints.Where(e => e.City == vm.SenderCity && e.Address == vm.SenderAddress).FirstOrDefault();
                var existingRecipient = db.Endpoints.Where(e => e.City == vm.RecipientCity && e.Address == vm.RecipientAddress).FirstOrDefault();
                var existingCargo = db.Cargos.Where(c => c.Weight == vm.Weight).FirstOrDefault();//В данной задаче груз отличается по весу, так что можно считать одинаковыми грузы с одинаковыми весами и не создавать новых сущностей в БД

                if (existingSender is null)
                {
                    existingSender = new Models.Endpoint()
                    {
                        Address = vm.SenderAddress,
                        City = vm.SenderCity
                    };
                    db.Endpoints.Add(existingSender);
                }
                if (existingRecipient is null)
                {
                    existingRecipient = new Models.Endpoint()
                    {
                        Address = vm.RecipientAddress,
                        City = vm.RecipientCity
                    };
                    db.Endpoints.Add(existingRecipient);
                }

                if (existingCargo is null)
                {
                    existingCargo = new Cargo()
                    {
                        Weight = vm.Weight
                    };
                    db.Cargos.Add(existingCargo);
                }
                //Создание новго Заказа
                var order = new Order();
                //Создание факта доставки
                var delivery = new Delivery()
                {
                    Cargo = existingCargo,
                    Order = order,
                    RecipientEndpoint = existingRecipient,
                    SenderEndpoint = existingSender,
                    Date = vm.PickupDate,
                };

                db.Deliverys.Add(delivery);
                db.Orders.Add(order);

                TempData["SuccessMessage"] = "Заказ сохранен";
                await db.SaveChangesAsync();//Подтвердить добавление
            }
            catch (ArgumentException e)
            {
                TempData["ErrorMessage"] = e.Message;
            }

            return Redirect("/orders/new");
        }
        
    }
}
