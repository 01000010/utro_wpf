using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using utro_wpf.core;

namespace utro_wpf
{
    /// <summary>
    /// Interaction logic for PaymentControl.xaml
    /// </summary>
    public partial class PaymentControl : UserControl, IHavePassword
    {
        public PaymentControl()
        {
            InitializeComponent();

            DataContext = IoC.AppPay;
        }

        public SecureString SecurePassword => CVVBox.SecurePassword;
    }
}
