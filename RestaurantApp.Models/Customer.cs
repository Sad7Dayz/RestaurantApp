/*****************************************************************************************************
 *
 * 고객 클래스
 *
 *****************************************************************************************************/
namespace RestaurantApp.Models
{
    public class Customer
    {
        /// <value>고객ID</value>
        public int CustomerId { get; set; }

        /// <value>첫번째이름</value>
        public string FirstName { get; set; }

        /// <value>마지막이름</value>
        public string LastName { get; set; }

        /// <value>패스워드</value>
        public string Password { get; set; }

        /// <value>주문</value>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// 출력
        /// </summary>
        /// <returns>
        /// 첫번째이름, 마지막이름
        /// </returns>
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
