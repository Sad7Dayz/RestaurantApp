/*****************************************************************************************************
 * 
 * CartViewModel 클래스
 * 
 *****************************************************************************************************/

using RestaurantApp.Models;
using RestaurantApp.UI.Core;
using System.Windows;

namespace RestaurantApp.UI.MVVM.ViewModel
{
    public class CartViewModel : BaseViewModel
    {
        /// <value>지급 커맨드</value>
        public RelayCommand PaymentCommand { get; }

        /// <value>요리삭제 커맨드</value>
        public RelayCommand<CartItem> RemoveDishCommand { get; }

        /// <summary>
        /// 생성자
        /// </summary>
        public CartViewModel()
        {
            Db.Dishes.ToList();
            Cart.UpdatePrice();

            //결제 커맨드
            PaymentCommand = new RelayCommand(() =>
            {
                if (Order != null)
                {
                    DateTime paymentDate = DateTime.Now;
                    Db.Orders.Add(Order);
                    Db.SaveChanges();
                    foreach (Dish dish in Cart)
                    {
                        Payment payment = new Payment()
                        {
                            DishId = dish.DishId,
                            OrderId = Order.OrderId,
                            PaymentDate = paymentDate
                        };
                        Db.Payments.Add(payment);
                    }
                    Cart.Clear();
                    Cart.UpdatePrice();
                    Db.SaveChanges();
                    Order = null;
                }
                MessageBox.Show("카트 추가");
            });

            //카트삭제 커맨드
            RemoveDishCommand = new RelayCommand<CartItem>((cartItem) =>
            {
                Cart.Dishes.Remove(cartItem);
                Cart.UpdatePrice();
            });
        }
    }
}
