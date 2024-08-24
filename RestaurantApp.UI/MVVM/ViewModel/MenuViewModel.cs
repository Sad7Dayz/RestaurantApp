/*****************************************************************************************************
 * 
 * MenuViewModel 클래스
 * 
 *****************************************************************************************************/


using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;
using RestaurantApp.UI.Core;
using System.Collections.ObjectModel;
using System.Windows;

namespace RestaurantApp.UI.MVVM.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        /// <value></value>
        private int index = 0;

        /// <value></value>
        public ObservableCollection<Dish> Dishes { get; }

        /// <value>현재 요리 수</value>
        private Dish currentDish;
        public Dish CurrentDish
        {
            get => currentDish;
            set
            {
                currentDish = value;
                OnPropertyChanged();
            }
        }

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

        /// <value>다음버튼 커맨드</value>
        public RelayCommand NextBtnCommand { get; }

        /// <value>이전버튼 커맨드</value>
        public RelayCommand PrevBtnCommand { get; }

        /// <value>카트 추가 커맨드</value>
        public RelayCommand AddToCartCommand { get; }


        /// <summary>
        /// 생성자
        /// </summary>
        public MenuViewModel()
        {
           
            Db.Dishes.Load();
            Dishes = Db.Dishes.Local.ToObservableCollection();
            CurrentDish = Dishes.FirstOrDefault();

            //다음버튼 커맨드
            NextBtnCommand = new RelayCommand(() =>
            {
                if (index < Dishes.Count - 1)
                {
                    CurrentDish = Dishes[++index];
                }
            });

            //이전버튼 커맨드
            PrevBtnCommand = new RelayCommand(() =>
            {
                if (index > 0)
                {
                    CurrentDish = Dishes[--index];
                }
            });

            //카트 추가 커맨드
            AddToCartCommand = new RelayCommand(() =>
            {
                if (Count != 0)
                {
                    if (!Cart.Dishes.Any())
                    {
                        Order = new Order()
                        {
                            CustomerId = Customer.CustomerId,
                            TableNumber = TableNumber,
                            OrderDate = System.DateTime.Now
                        };
                    }
                    Cart.Add(CurrentDish, Count);
                    MessageBox.Show("바구니 추가");
                }
                Count = 0;
            });
        }
    }
}
