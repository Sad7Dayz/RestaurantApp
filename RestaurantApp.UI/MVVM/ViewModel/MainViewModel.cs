/*****************************************************************************************************
 * 
 * MainViewModel 클래스
 * 
 *****************************************************************************************************/

using Microsoft.EntityFrameworkCore;
using RestaurantApp.UI.Core;
using RestaurantApp.UI.MVVM.View;
using System.Windows;

namespace RestaurantApp.UI.MVVM.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        /// <value>다이얼로그 결과</value>
        private bool dialogResult;
        public bool DialogResult
        {
            get { return dialogResult; }
            set
            {
                dialogResult = value;
                OnPropertyChanged();
            }
        }

        /// <value>현재뷰</value>
        private object currentView;
        public object CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                OnPropertyChanged();
            }
        }

        /// <value>홈 초기화</value>
        public HomeViewModel HomeVM { get; } = new HomeViewModel();

        /// <value>메뉴 초기화</value>
        public MenuViewModel MenuVM { get; } = new MenuViewModel();

        /// <value>셋팅 초기화</value>
        public SettingViewModel SettingVM { get; } = new SettingViewModel();

        /// <value>카트 초기화</value>
        public CartViewModel CartVM { get; set; } = new CartViewModel();

        /// <value>로그인 초기화</value>
        public LoginViewModel LoginVM { get; set; } = new LoginViewModel();

        /// <value>홈화면 전환 명령 currentview가 homevm으로 설정</value>
        public RelayCommand HomeCommand { get; }

        /// <value>메뉴화면 전환 명령 currentview가 menuvm으로 설정</value>
        public RelayCommand MenuCommand { get; }

        /// <value>셋팅화면 전환 명령 currentview가 settingvm으로 설정</value>
        public RelayCommand SettingCommand { get; }

        /// <value>카드화면 전환 명령 currentview가 cartvm으로 설정</value>
        public RelayCommand CartCommand { get; }

        /// <value>로그인화면 전환 명령 currentview가 loginvm으로 설정</value>
        public RelayCommand<Window> LoginCommand { get; }

        /// <summary>
        /// 생성자
        /// </summary>
        public MainViewModel()
        {
            Task.Run(() =>
            {
                Db.Dishes.Load();
            });
            //현재 메인화면
            CurrentView = HomeVM;

            //로그인화면
            LoginView loginView = new LoginView();
            if (loginView.ShowDialog() == false)
            {
                DialogResult = false;
            }
            else
            {
                DialogResult = true;
            }
            HomeCommand = new RelayCommand(() => CurrentView = HomeVM);
            MenuCommand = new RelayCommand(() => CurrentView = MenuVM);
            SettingCommand = new RelayCommand(() => CurrentView = SettingVM);
            CartCommand = new RelayCommand(() => CurrentView = CartVM);
        }
    }
}
