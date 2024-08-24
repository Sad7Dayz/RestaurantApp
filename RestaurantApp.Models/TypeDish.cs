/*****************************************************************************************************
 *
 * 접시 유형
 *
 *****************************************************************************************************/
namespace RestaurantApp.Models
{
    public class TypeDish
    {
        /// <value>접시유형별ID</value>
        public int TypeDishId { get; set; }

        /// <value>이름</value>
        public string? Name { get; set; }

        /// <value>접시</value>
        public List<Dish>? Dishes { get; set; }

        /// <summary>
        /// 출력
        /// </summary>
        /// <returns>
        /// 이름으로 출력
        /// </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
