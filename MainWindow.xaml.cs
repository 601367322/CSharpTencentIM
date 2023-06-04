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
            long SDKAppId = ;
            string UserId = ;
            string UserSig = ;            
            TencentIMSDK.Init(SDKAppId, sdkConfig, true);
            TencentIMSDK.AddRecvNewMsgCallback((List<Message> message, string user_data) => {
               
            },(string message, string user_data) => {
                Trace.WriteLine(message);
            });
            TencentIMSDK.Login(UserId, UserSig, (int code, string desc, string user_data) => {
                Trace.WriteLine(desc);
            });
        }

    }
}
