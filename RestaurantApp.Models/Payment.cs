/*****************************************************************************************************
 *
 * 지급 클래스
 *
 *****************************************************************************************************/
namespace RestaurantApp.Models
{
    public class Payment
    {
        /// <value>지급ID</value>
        public int PaymentId { get; set; }

        /// <value>주문ID</value>
        public int OrderId { get; set; }

        /// <value>주문</value>
        public Order? Order { get; set; }

        /// <value>접시ID</value>
        public int DishId { get; set; }

        /// <value>접시</value>
        public Dish? Dish { get; set; }

        /// <value>결제날짜</value>
        public DateTime PaymentDate { get; set; }
    }
}
