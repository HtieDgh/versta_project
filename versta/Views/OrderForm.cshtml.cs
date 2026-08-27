using System.ComponentModel.DataAnnotations;

namespace versta.Views
{
    public class OrderFormViewModel
    {
        public void OnGet() { }
        [Required(ErrorMessage = "Укажите город отправителя")]
        [Display(Name = "Город отправителя")]
        public string SenderCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите адрес отправителя")]
        [Display(Name = "Адрес отправителя")]
        public string SenderAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите город получателя")]
        [Display(Name = "Город получателя")]
        public string RecipientCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите адрес получателя")]
        [Display(Name = "Адрес получателя")]
        public string RecipientAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите вес груза")]
        [Range(0.1, 10000, ErrorMessage = "Вес должен быть от 0.1 до 10000 кг")]
        [Display(Name = "Вес (кг)")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Выберите дату забора груза")]
        [Display(Name = "Дата забора")]
        public DateOnly PickupDate { get; set; }
        public string? ErrorMessage=null; //сообщение об ошибке
        public string? SuccessMessage = null; //сообщение о успехе
    }
}
