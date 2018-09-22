using SerialAssistant.SerialData;
using System;
using Windows.UI.Xaml.Controls;
// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace SerialAssistant
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Serial serial = new Serial();

        public MainPage()
        {
            this.InitializeComponent();
            serial.SerialList();
            if (serial.AllPortName != null)
            {
                foreach (string name in serial.AllPortName)
                {
                    PortNameComboBox.Items.Add(name);
                }
            }
        }
        
        private void ClearReceiveButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ReceiveTextBox.Text = string.Empty;
        }

        private void ClearSendButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            SendTextBox.Text = string.Empty;
            //serial.PortName.Clear();
            //PortNameComboBox.Items.Clear();
        }

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var PortName = PortNameComboBox.SelectionBoxItem;
            if (PortName == null)
            {
                string message = string.Empty;
                if (PortNameComboBox.Items.Count == 0)
                {
                    message = "设备未连接";
                }
                else
                {
                    message = "未选择设备";
                }
                ContentDialog contentDialog = new ContentDialog()
                {
                    Title = "消息提示",
                    Content = message,
                    CloseButtonText = "关闭",
                    FullSizeDesired = false
                };
                
                await contentDialog.ShowAsync();
            }
            else
            {
                string BaudRate = BaudRateComboBox.SelectionBoxItem.ToString();
                string ParityBit = ParityBitComboBox.SelectionBoxItem.ToString();
                string DataBit = DataBitComboBox.SelectionBoxItem.ToString();
                string StopBit = StopBitComboBox.SelectionBoxItem.ToString();

                serial.SerialDataSet(PortName.ToString(), BaudRate, ParityBit, DataBit, StopBit);

                string data = serial.SerialDataRead();
                ReceiveTextBox.Text = data.ToString();
            }
        }

        private void PortNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ConnectedDevicesTextBlock.Text = PortNameComboBox.SelectedItem.ToString();
        }

        private void PortNameComboBox_DropDownOpened(object sender, object e)
        {
            serial.SerialList();
            if (serial.AllPortName.Count == 0)
            {
                serial.AllPortName.Clear();
                PortNameComboBox.Items.Clear();
            }
            else
            {
                foreach (string name in serial.AllPortName)
                {

                    if (PortNameComboBox.Items.Contains(name))
                    {
                        continue;
                    }
                    else
                    {
                        PortNameComboBox.Items.Add(name);
                    }
                }
            }
        }
    }
}
