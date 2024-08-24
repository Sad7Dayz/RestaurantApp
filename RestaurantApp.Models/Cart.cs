/*****************************************************************************************************
 * 
 * https://yeko90.tistory.com/entry/c-wpf-ObservableCollection
 * ObservableCollection의 변화가 있다면 알려주는 역할
 * INotifyPropertyChanged 인터페에스 상속
 * 
 * 
 * 카트 클래스
 * 
 *****************************************************************************************************/

using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RestaurantApp.Models
{
    public class Cart : ObservableObject, IEnumerable
    {
        /// <value>가격</value>
        public ObservableCollection<CartItem> Dishes { get; } = new ObservableCollection<CartItem>();

        /// <value>가격</value>
        private decimal price;
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        public Cart()
        {
            Dishes.CollectionChanged += Dishes_CollectionChanged;
        }

        /// <summary>
        /// 카트 아이템
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dishes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (var item in e.NewItems.Cast<CartItem>())
                    item.PropertyChanged += OnChanged;

            if (e.OldItems != null)
                foreach (var item in e.OldItems.Cast<CartItem>())
                    item.PropertyChanged -= OnChanged;
        }

        /// <summary>
        /// 카트 아이템 속성이 변경 됬을때 호출 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is CartItem c && c.Count <= 0)
            {
                Dishes.Remove(c);
            }
            UpdatePrice();
        }

        /// <value>요리 초기화</value>
        public void Clear() => Dishes.Clear();

        /// <value>총가격</value>
        public void UpdatePrice() => Price = GetAll().Sum(d => d.Price);
        
        /// <summary>
        /// 카트 아이템 추가
        /// </summary>
        /// <param name="dish"></param>
        /// <param name="count"></param>
        public void Add(Dish dish, int count)
        {
            var cartItem = Dishes.FirstOrDefault(c => c.Dish.Name == dish.Name);
            if (cartItem != null)
            {
                cartItem.Count += count;
            }
            else
            {
                Dishes.Add(new CartItem(dish, count));
            }
        }

        /// <summary>
        /// 모든 아이템
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<Dish> GetAll()
        {
            var dishes = new ObservableCollection<Dish>();
            foreach (Dish dish in this)
            {
                dishes.Add(dish);
            }
            return dishes;
        }

        /// <summary>
        /// 아이템 카운트
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            foreach (var item in Dishes)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    yield return item.Dish;
                }
            }
        }
    }
}
