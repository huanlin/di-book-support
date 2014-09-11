using Examples.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsDemo.Autofac
{
    public partial class Default : System.Web.UI.Page
    {
        // 此屬性會由 Autofac 負責注入相依物件。
        public IMessageService HelloService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 在網頁上輸出一段字串訊息。訊息內容由 HelloService 提供。
            Response.Write(this.HelloService.Hello("DI in ASP.NET Web Forms using Autofac!"));
        }
    }
}