using System;

namespace iQuest.Business.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string PaymentMethod { get; set; }
    }
}