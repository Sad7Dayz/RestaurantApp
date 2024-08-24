/*****************************************************************************************************
 * https://endtime-co-kr.tistory.com/entry/RelayCommand-ICommand
 * 
 * RelayCommand 
 * WPF 컨트롤의 Command 속성에 Binding 하기 위해 사용
 *****************************************************************************************************/
using System.Windows.Input;

namespace RestaurantApp.UI.Core
{
    public class RelayCommand : ICommand
    {
        private Action _execute;
        private Func<bool> _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
               => _canExecute == null || _canExecute();

        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}
