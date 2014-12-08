using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch07.Common.Contracts;

namespace Ch07.Common.Services
{
    public class NotificationManager2 : INotificationManager
    {
        private IMessageService _msgService = null;
        private readonly Func<IMessageService> _msgServiceFactory;

        public NotificationManager2(Func<IMessageService> svcFactory)
        {
            // 注意：這裡只是把工廠方法保存在 delegate 物件裡，
            //       此時並不會真的建立 IMessageService 的物件實體。
            _msgServiceFactory = svcFactory;
        }

        public void Notify(string to, string msg)
        {
            // 注意：每次呼叫委派方法 _msgServiceProvider() 時都會建立一個新的 IMessageService 物件。
            //       這裡用一個 private member 來保存先前建立好的物件，避免不斷建立新的執行個體。
            if (_msgService == null)
            {
                _msgService = _msgServiceFactory(); 
            }

            _msgService.SendMessage(to, msg);
        }
    }
}
