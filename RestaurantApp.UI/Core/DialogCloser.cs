/*****************************************************************************************************
 * 
 * Login이후 메인창으로 넘어 갈 시 Login창 shutdown.
 * 
 *****************************************************************************************************/

using System.Windows;

namespace RestaurantApp.UI.Core
{
    public class DialogCloser
    {
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.RegisterAttached(
                "DialogResult",
                typeof(bool?),
                typeof(DialogCloser),
                new PropertyMetadata(DialogResultChanged));

        private static void DialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window != null)
            {
                var dialogResult = e.NewValue as bool?;
                if (dialogResult == false)
                    window.Close();
            }
        }

        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }
    }
}
