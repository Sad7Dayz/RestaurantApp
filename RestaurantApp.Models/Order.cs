/*****************************************************************************************************
 *
 * 주문 클래스
 *
 *****************************************************************************************************/
namespace RestaurantApp.Models
{
    public class Order
    {
        /// <value>주문ID</value>
        public int OrderId { get; set; }

        /// <value>고객ID</value>
        public int CustomerId { get; set; }

        /// <value>고객</value>
        public Customer? Customer { get; set; }

        /// <value>테이블넘버</value>
        public int TableNumber { get; set; }

        /// <value>주문날짜</value>
        public DateTime OrderDate { get; set; }

        /// <value>결제</value>
        public List<Payment>? Payments { get; set; }

        /// <summary>
        /// 출력
        /// </summary>
        /// <returns>
        /// 테이블넘버, 고객, 주문날짜
        /// </returns>
        public override string ToString()
        {
            return $"Table Number{TableNumber} {Customer} {OrderDate:HH:mm dd.MM.yyyy}";
        }
    }
}
