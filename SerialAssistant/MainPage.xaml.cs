using SerialAssistant.SerialData;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using System;
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
            if(serial.PortName != null)
            {
                foreach (string name in serial.PortName)
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
        }

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            object PortName = PortNameComboBox.SelectedValue;
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
                string BaudRate = BaudRateComboBox.SelectedValue.ToString();
                string ParityBit = ParityBitComboBox.SelectedValue.ToString();
                string DataBit = DataBitComboBox.SelectedValue.ToString();
                string StopBit = StopBitComboBox.SelectedValue.ToString();
                
                serial.SerialDataSet(PortName.ToString(), BaudRate, ParityBit, DataBit, StopBit);
            }
        }

        private void PortNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConnectedDevicesTextBlock.Text = PortNameComboBox.SelectedItem.ToString();
        }

        private void PortNameComboBox_DropDownOpened(object sender, object e)
        {
            serial.SerialList();
            if (serial.PortName.Count == 0)
            {
                PortNameComboBox.Items.Clear();
            }
            else
            {
                foreach (string name in serial.PortName)
                {

                    if (PortNameComboBox.Items.Contains(name))
                    {
                        //PortNameComboBox.Items.Remove(name);
                        //return;
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
