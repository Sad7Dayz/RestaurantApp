/*****************************************************************************************************
 * 
 * SettingViewModel 클래스
 * 
 *****************************************************************************************************/


using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using RestaurantApp.Models;
using RestaurantApp.UI.Core;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RestaurantApp.UI.MVVM.ViewModel
{
    public class SettingViewModel : BaseViewModel
    {
        /// <value>이미지</value>
        private OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            Title = "이미지 선택",
            Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
               "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
               "Portable Network Graphic (*.png)|*.png"
        };

        /// <value>요리 종류</value>
        private TypeDish typeDish;
        public TypeDish TypeDish
        {
            get => typeDish;
            set
            {
                typeDish = value;
            }
        }

        /// <value>요리</value>
        private Dish dish;
        public Dish Dish
        {
            get => dish;
            set
            {
                dish = value;
            }
        }


        /// <value>요리 종류</value>
        public ObservableCollection<TypeDish> TypeDishes { get; }

        /// <value>요리종류 추가 커맨드</value>
        public RelayCommand AddTypeDishCommand { get; }

        /// <value>요리 추가 커맨드</value>
        public RelayCommand AddDishCommand { get; }

        /// <value>이미지 추가</value>
        public RelayCommand AddImage { get; }


        /// <summary>
        /// 생성자
        /// </summary>
        public SettingViewModel()
        {
            TypeDish = new TypeDish();
            Dish = new Dish();
            Db.TypeDishs.Load();
            TypeDishes = Db.TypeDishs.Local.ToObservableCollection();
            AddTypeDishCommand = new RelayCommand(() =>
            {
                Db.TypeDishs.Add(TypeDish);
                Db.SaveChanges();
                MessageBox.Show("요리종류 추가");
            });
            AddDishCommand = new RelayCommand(() =>
            {
                Db.Dishes.Add(Dish);
                Db.SaveChanges();
                MessageBox.Show("요리 추가");
            });
            AddImage = new RelayCommand(() =>
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    var img = new BitmapImage(new Uri(openFileDialog.FileName));
                    byte[] data;
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(img));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                        data = ms.ToArray();
                    }
                    Dish.Image = data;
                    MessageBox.Show("이미지 추가");
                }
            });
        }
    }
}
