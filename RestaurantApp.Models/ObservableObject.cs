/*****************************************************************************************************
 * https://nomadcoder.tistory.com/entry/WPF-%EC%B4%88%EA%B0%84%EB%8B%A8-INotifyPropertyChanged-%EA%B5%AC%ED%98%84%ED%95%98%EA%B8%B0
 * INotifyPropertyChanged 원본속성 또는 대상속성이 변경되면 다른 항목이 자동으로 업데이트
 * 
 *****************************************************************************************************/
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantApp.Models
{
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChangedEventHandler Delegate
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// 속성이 변경 될때 이벤트 호출
        /// </summary>
        /// <param name="prop">prop 문자</param>
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
