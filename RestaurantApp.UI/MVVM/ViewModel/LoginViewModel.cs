/*****************************************************************************************************
 * 
 * LoginViewModel 클래스
 * 
 *****************************************************************************************************/

using Microsoft.EntityFrameworkCore;
using RestaurantApp.DataBase.Service;
using RestaurantApp.Models;
using RestaurantApp.UI.Core;
using System.Collections.ObjectModel;
using System.Windows;

namespace RestaurantApp.UI.MVVM.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        /// <value></value>
        public ObservableCollection<Customer> Customers { get; }

        ///<value>로그인</value>
        private Customer? loginCustomer;
        public Customer? LoginCustomer
        {
            get => loginCustomer;
            set
            {
                loginCustomer = value;
                OnPropertyChanged();
            }
        }

        ///<value>패스워드</value>
        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
            }
        }

        /// <value>등록 커맨드</value>
        public RelayCommand? RegistrationCommand { get; }

        /// <value>로그인 커맨드</value>
        public RelayCommand<Window>? LoginCommand { get; }

        /// <summary>
        /// 생성자, 로그인
        /// </summary>
        public LoginViewModel()
        {
            Db.Customers.Load();
            LoginCustomer = new Customer();
            Customers = Db.Customers.Local.ToObservableCollection();

            //등록 커맨드
            RegistrationCommand = new RelayCommand(() =>
            {
                LoginCustomer.Password = PasswordEncryptor.PasswordEncrypt(Password);
                Customer = Customers.SingleOrDefault(c => c.FirstName == LoginCustomer.FirstName && c.LastName == LoginCustomer.LastName && c.Password == PasswordEncryptor.PasswordEncrypt(Password));

                if (Customer != null)
                {
                    MessageBox.Show("이 사용자는 이미 등록되어 있습니다.");
                }
                else
                {
                    Db.Customers.Add(LoginCustomer);
                    Db.SaveChanges();
                    MessageBox.Show("사용자 등록 완료.");
                }
            });

            //로그인 커맨드
            LoginCommand = new RelayCommand<Window>((window) =>
            {
                Customer = Customers.SingleOrDefault(c => c.FirstName == LoginCustomer.FirstName &&
                                            c.LastName == LoginCustomer.LastName &&
                                            c.Password == PasswordEncryptor.PasswordEncrypt(Password));
                if (Customer != null)
                {
                    TableNumber = new Random().Next(1, 7);
                    window.DialogResult = true;
                    window.Close();
                }
                else
                {
                    MessageBox.Show("이 사용자는 아직 등록되지 않았습니다.");
                }
            });
        }
    }
}
