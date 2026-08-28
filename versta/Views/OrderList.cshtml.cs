using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using versta.Models;
using versta.Shared;

namespace versta.Views
{
    public class OrderListViewModel : PageModel
    {
        public void OnGet()
        {
        }
        /// <summary>
        /// Получение списка заказов с учетом пагинации.
        /// </summary>
        /// <param name="db">Файл контекста базы данных</param>
        /// <param name="skip">Сколько пропустить заказов</param>
        /// <param name="take">Количество возвращаемых заказов</param>
        public void PopulateOrders(ApplicationContext db,int skip, int take)
        {
            Orders = db.Deliverys
                .Include(d=>d.Cargo)
                .Include(d=>d.SenderEndpoint)
                .Include(d=>d.RecipientEndpoint)
                .Select(d => new OrderReport
                {
                    Date=d.Date,
                    OrderID=d.OrderID,
                    SenderCity=d.SenderEndpoint!.City,
                    RecipientCity=d.RecipientEndpoint!.City,
                    SenderAddress=d.SenderEndpoint.Address,
                    RecipientAddress=d.RecipientEndpoint.Address,
                    Weight=d.Cargo!.Weight
                })
                .Skip(skip).Take(take).ToList();
        }
        
        public List<OrderReport> Orders=new();//Список заказов
    }
}
