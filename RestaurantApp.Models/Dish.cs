/*****************************************************************************************************
 *
 * 접시 클래스
 *
 *****************************************************************************************************/
namespace RestaurantApp.Models
{
    public class Dish
    {
        /// <value>접시ID</value>
        public int DishId { get; set; }

        /// <value>이름</value>
        public string? Name { get; set; }

        /// <value>접시유형별ID</value>
        public int TypeDishId { get; set; }

        /// <value>접시유형별</value>
        public TypeDish? TypeDish { get; set; }

        /// <value>이미지</value>
        public byte[]? Image { get; set; }

        /// <value>칼로리</value>
        public double Kilocalories { get; set; }

        /// <value>무게</value>
        public double Weight { get; set; }

        /// <value>가격</value>
        public decimal Price { get; set; }

        /// <value>결제</value>
        public List<Payment>? Payments { get; set; }

        /// <summary>
        /// 출력
        /// </summary>
        /// <returns>
        /// 이름, 가격
        /// </returns>
        public override string ToString()
        {
            return $"{Name} : ${Price}";
        }
    }
}
