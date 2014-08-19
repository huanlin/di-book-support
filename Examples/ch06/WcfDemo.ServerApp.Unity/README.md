範例程式：WcfDemo.ServerApp
==========================

## 說明

示範以 Contructor Injection 的方式將相依物件注入至 WCF 服務。
此範例程式是個可裝載於 IIS （和 IIS Express） 的 WCF 應用程式。觀察重點如下：

  - web.config 中的 serviceActivations 區段。
  - Infrastructure 資料夾下的各個類別。建議從 MyServiceHostFactory.cs 開始看起。