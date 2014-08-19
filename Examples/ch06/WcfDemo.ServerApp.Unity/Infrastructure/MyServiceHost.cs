using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WcfDemo.ServerApp.Unity.Infrastructure
{
    public class MyServiceHost : ServiceHost
    {       

        public MyServiceHost(Type serviceType, params Uri[] baseAddresses) 
            : base(serviceType, baseAddresses)
        {
            var contracts = this.ImplementedContracts.Values;
            foreach (var contract in contracts)
            {
                var behavior = new MyContractBehavior();
                contract.ContractBehaviors.Add(behavior);
            }
        }   
    }

}
