/*****************************************************************************************************
 * 
 * BaseViewModel
 * 
 * ObservableObject 상속 받는 클래스
 * 
 *****************************************************************************************************/
using RestaurantApp.DataBase.EF;
using RestaurantApp.Models;
using RestaurantApp.UI.Core;
using System.Windows;

namespace RestaurantApp.UI.MVVM.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        /// <value>DB속성</value>
        public AppDbContext Db { get; set; } = new AppDbContext();

        /// <value>카트</value>
        public static Cart Cart { get; } = new Cart();

        /// <value>닫기 커맨드</value>
        public RelayCommand<Window> CloseCommand { get; }

        /// <value>촤소화 커맨드</value>
        public RelayCommand<Window> MinimizeCommand { get; }

        /// <value>테이블 번호</value>
        private static int tableNumber;
        public int TableNumber
        {
            get => tableNumber;
            set
            {
                tableNumber = value;
                OnPropertyChanged();
            }
        }

        /// <value>주문</value>
        private static Order order = new Order();
        public Order Order
        {
            get => order;
            set
            {
                order = value;
                OnPropertyChanged();
            }
        }

        /// <value>고객</value>
        private static Customer customer;
        public Customer Customer
        {
            get => customer;
            set
            {
                customer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 생성자
        /// </summary>
        public BaseViewModel()
        {
            //닫기 커맨드
            CloseCommand = new RelayCommand<Window>((Window) =>
            {
                Cart.Clear();
                Window.Close();
            });

            //최소화 커맨드
            MinimizeCommand = new RelayCommand<Window>((Window) =>
            {
                Window.WindowState = WindowState.Minimized;
            });
        }
    }
}
