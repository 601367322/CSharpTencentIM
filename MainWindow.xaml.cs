using com.tencent.imsdk.unity;
using com.tencent.imsdk.unity.types;
using com.tencent.imsdk.unity.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Trace.WriteLine(TencentIMSDK.GetSDKVersion());
            SdkConfig sdkConfig = new SdkConfig();
            long SDKAppId = 1400486080;
            string UserId = "111";
            string UserSig = "eJwtzEELgjAYxvHvsnPYO3VzCh2CQpIwqx27GFv6KoqsFWH03TPb8fk98H8TuT97T21IQnwPyGLeqHRv8YYzU0od31VbDgMqktAQIBQcBPwf-RrQ6MkZYz6AU4vdz7hgIgwiFrgKVlNVZuZkRnk8pGlcN3nXxk0m8-5qI15vWLHd2fQxFlV-Wa7Finy*jWIwcA__";            
            TencentIMSDK.Init(SDKAppId, sdkConfig, true);
            TencentIMSDK.AddRecvNewMsgCallback((List<Message> message, string user_data) => {
               
            },(string message, string user_data) => {
                Trace.WriteLine( message);
            });
            TencentIMSDK.Login(UserId, UserSig, (int code, string desc, string user_data) => {
                Trace.WriteLine(desc);
            });
        }

    }
}
