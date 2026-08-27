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
        public List<OrderReport> Orders=new();
        public record OrderElement
        {

            public string SenderCity { get; set; } = string.Empty;

            public string SenderAddress { get; set; } = string.Empty;

            public string RecipientCity { get; set; } = string.Empty;

            public string RecipientAddress { get; set; } = string.Empty;

            public decimal Weight { get; set; } = 0.0m;
            public DateOnly PickupDate { get; set; }
        }
    }
}
