using com.tencent.imsdk.unity;
using com.tencent.imsdk.unity.callback;
using com.tencent.imsdk.unity.enums;
using com.tencent.imsdk.unity.types;
using com.tencent.imsdk.unity.utils;
using Newtonsoft.Json;
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
            string SendMsgTemp = "自动回复";

            TencentIMSDK.Init(SDKAppId, sdkConfig, true);
            TencentIMSDK.AddRecvNewMsgCallback((List<Message> message, string user_data) => {
               
            },(string message, string user_data) => {
                Trace.WriteLine(message);

                //自动回复
                List<Message> messages = JsonConvert.DeserializeObject<List<Message>>(message);
                Message bean = messages[0];
                Message sendMessage = new Message
                {
                    message_elem_array = new List<Elem>(){
                    new Elem(){
                        elem_type = TIMElemType.kTIMElem_Text,
                        text_elem_content = SendMsgTemp,
                    }
                }
                };
                TencentIMSDK.MsgSendMessage(bean.message_conv_id, TIMConvType.kTIMConv_C2C, sendMessage, null, (int code, string desc, Message data, string user_data)=> {
                    Trace.WriteLine(desc);
                });
                
            });
            TencentIMSDK.Login(UserId, UserSig, (int code, string desc, string user_data) => {
                Trace.WriteLine(desc);
            });
        }

    }
}
