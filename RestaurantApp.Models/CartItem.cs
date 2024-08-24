/*****************************************************************************************************
 *
 * 카트 아이템 클래스
 *
 *****************************************************************************************************/
namespace RestaurantApp.Models
{
    public class CartItem : ObservableObject
    {
        /// <value>접시</value>
        public Dish Dish { get; set; }

        /// <value>카운트</value>
        private int count;
        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged();
            }
        }

        /// <value>카트 아이템</value>
        public CartItem(Dish dish, int count)
        {
            Dish = dish;
            Count = count;
        }
    }
}
