using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch07.Common.Contracts;

namespace Ch07.Common.Services
{
    public class NotificationManager : INotificationManager
    {
        #region 動態解析元件-樸實版
        private IMessageService _emailService;
        private IMessageService _smsService;       

        public NotificationManager(IMessageService emailService, IMessageService smsService)
        {
            _emailService = emailService;
            _smsService = smsService;
        }

        private bool UsingEmail()
        {
            return false;
        }

        #endregion

        #region 動態解析元件-使用物件工廠

        private IMessageServiceFactory _msgServiceFactory;

        public NotificationManager(IMessageServiceFactory factory)
        {
            _msgServiceFactory = factory;
        }

        #endregion

        #region 動態解析元件-使用 Func<T>

        private Func<IMessageService> _msgServiceProvider;

        public NotificationManager(Func<IMessageService> svcProvider)
        {
            _msgServiceProvider = svcProvider;
        }

        #endregion

        #region 共用函式
        public void Notify(string to, string msg)
        {
            if (_msgServiceProvider != null)
            {
                var svc = _msgServiceProvider();
                svc.SendMessage(to, msg);
                return;
            }

            if (_msgServiceFactory != null)
            {
                using (IMessageService svc = _msgServiceFactory.GetService())
                {
                    svc.SendMessage(to, msg);
                }
                return;
            }
            if (UsingEmail())
            {
                _emailService.SendMessage(to, msg);
            }
            else
            {
                _smsService.SendMessage(to, msg);

            }
        }
        #endregion
    }

}
