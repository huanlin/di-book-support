MVC 的預設 IDependencyResolver 實作類別：DefaultDependencyResolver


第一次對 HomeController 發出請求時，MVC 5 會解析下列型別：

- System.Web.Mvc.IControllerFactory
- System.Web.Mvc.IControllerActivator
- Ex2_DependencyResolver.Controllers.HomeController
- System.Web.Mvc.ITempDataProviderFactory
- System.Web.Mvc.ITempDataProvider
- System.Web.Mvc.Async.IAsyncActionInvokerFactory
- System.Web.Mvc.IActionInvokerFactory
- System.Web.Mvc.Async.IAsyncActionInvoker
- System.Web.Mvc.IActionInvoker


第二次對 HomeController 發出請求時，MVC 5 只需解析以下型別：

- Ex2_DependencyResolver.Controllers.HomeController