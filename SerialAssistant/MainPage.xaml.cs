using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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

        //public async void SerialPortList()
        //{
        //    var selector = SerialDevice.GetDeviceSelector();
        //    var devices = await DeviceInformation.FindAllAsync(selector);
        //    if (devices.Any())
        //    {
        //        for (int i = 0; i < devices.Count(); i++)
        //        {
        //            PortIDComboBox.Items.Add(devices[i].Name);
        //        }
        //    //PortIDComboBox.SelectedIndex = 0;

        //        for (int i = 0; i < devices.Count(); i++)
        //        {
        //            if (devices[i].Name.Equals(PortIDComboBox.SelectedValue.ToString()))
        //            {
        //                SerialDevice serialDevice = await SerialDevice.FromIdAsync(devices[i].Id);
        //                serialDevice.BaudRate = Convert.ToUInt32(BaudRateComboBox.SelectedValue);

        //                //无校验（no parity）
        //                //奇校验（odd parity）：如果字符数据位中"1"的数目是偶数，校验位为"1"，如果"1"的数目是奇数，校验位应为"0"。（校验位调整个数）
        //                //偶校验（even parity）：如果字符数据位中"1"的数目是偶数，则校验位应为"0"，如果是奇数则为"1"。（校验位调整个数）
        //                //mark parity：校验位始终为1
        //                //space parity：校验位始终为0
        //                string SelectorParity = ParityBitComboBox.SelectedValue.ToString();
        //                switch (SelectorParity)
        //                {
        //                    case "无校验":
        //                        serialDevice.Parity = SerialParity.None;
        //                        break;
        //                    case "奇校验":
        //                        serialDevice.Parity = SerialParity.Odd;
        //                        break;
        //                    case "偶校验":
        //                        serialDevice.Parity = SerialParity.Even;
        //                        break;
        //                    case "校验位为1":
        //                        serialDevice.Parity = SerialParity.Mark;
        //                        break;
        //                    case "校验位为0":
        //                        serialDevice.Parity = SerialParity.Space;
        //                        break;
        //                }

        //                serialDevice.DataBits = Convert.ToUInt16(DataBitComboBox.SelectedValue);

        //                switch (StopBitComboBox.SelectedValue.ToString())
        //                {
        //                    case "1":
        //                        serialDevice.StopBits = SerialStopBitCount.One;
        //                        break;
        //                    case "1.5":
        //                        serialDevice.StopBits = SerialStopBitCount.OnePointFive;
        //                        break;
        //                    case "2":
        //                        serialDevice.StopBits = SerialStopBitCount.Two;
        //                        break;
        //                }
        //                SendTextBox.Text = serialDevice.PortName + ", " + serialDevice.BaudRate + ", " + serialDevice.Parity + ", " + serialDevice.DataBits + ", " + serialDevice.StopBits;
        //                return;
        //            }
        //        }

        //    }
        //}

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
