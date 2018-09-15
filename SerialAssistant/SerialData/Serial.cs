using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;

namespace SerialAssistant.SerialData
{
    class Serial
    {
        public List<string> PortName = new List<string>();

        public async void SerialList()
        {
            string selectors = SerialDevice.GetDeviceSelector();
            var decices = await DeviceInformation.FindAllAsync(selectors);
            if (decices.Any())
            {
                for (int i = 0; i < decices.Count(); i++)
                {
                    PortName.Add(decices[i].Name);
                }
                PortName = PortName.Distinct().ToList();
            }
        }

        public async void SerialDataSet(string PortName, string BaudRate, string ParityBit, string DataBit, string StopBit)
        {
            string selectors = SerialDevice.GetDeviceSelector();
            var decices = await DeviceInformation.FindAllAsync(selectors);
            if (decices.Any())
            {
                for (int i = 0; i < decices.Count(); i++)
                {
                    if (decices[i].Id.Equals(PortName))
                    {
                        SerialDevice serialDevice = await SerialDevice.FromIdAsync(decices[i].Id);

                        serialDevice.BaudRate = Convert.ToUInt32(BaudRate);

                        //无校验（no parity）
                        //奇校验（odd parity）：如果字符数据位中"1"的数目是偶数，校验位为"1"，如果"1"的数目是奇数，校验位应为"0"。（校验位调整个数）
                        //偶校验（even parity）：如果字符数据位中"1"的数目是偶数，则校验位应为"0"，如果是奇数则为"1"。（校验位调整个数）
                        //mark parity：校验位始终为1
                        //space parity：校验位始终为0
                        switch (ParityBit)
                        {
                            case "无校验":
                                serialDevice.Parity = SerialParity.None;
                                break;
                            case "奇校验":
                                serialDevice.Parity = SerialParity.Odd;
                                break;
                            case "偶校验":
                                serialDevice.Parity = SerialParity.Even;
                                break;
                            case "校验位为1":
                                serialDevice.Parity = SerialParity.Mark;
                                break;
                            case "校验位为0":
                                serialDevice.Parity = SerialParity.Space;
                                break;
                        }

                        serialDevice.DataBits = Convert.ToUInt16(DataBit);

                        switch (StopBit)
                        {
                            case "1":
                                serialDevice.StopBits = SerialStopBitCount.One;
                                break;
                            case "1.5":
                                serialDevice.StopBits = SerialStopBitCount.OnePointFive;
                                break;
                            case "2":
                                serialDevice.StopBits = SerialStopBitCount.Two;
                                break;
                        }
                    }
                }
            }
        }

        
        
        //public string BaudRate { get; set; }
        //public string ParityBit { get; set; }
        //public string DataBit { get; set; }
        //public string StopBit { get; set; }
        //public async void SerialList()
        //{
        //    var selector = SerialDevice.GetDeviceSelector();
        //    var devices = await DeviceInformation.FindAllAsync(selector);
        //    if (devices.Any())
        //    {
        //        for (int i = 0; i < devices.Count(); i++)
        //        {
        //            PortIDComboBox.Items.Add(devices[i].Name);
        //        }
        //        //PortIDComboBox.SelectedIndex = 0;

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
    }
}
