using Windows.UI.Xaml.Controls;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace SerialAssistant
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        

        private void ClearReceiveButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ReceiveTextBox.Text = string.Empty;
        }

        private void ClearSendButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            SendTextBox.Text = string.Empty;
        }

        private void PortIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SerialPortList();

        }
    }
}
