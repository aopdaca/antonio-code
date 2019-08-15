using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MySoapService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUnitConversion" in both code and config file together.
    //wcf attributs 
    // mark interfaces classes, members, etc for "notice" by WCF setting up the soap service

    // Service COntract - goes on an interface to mark it as a service 
    //Operation contract - goes on the methods of a service interface to mark them as the operations of that service
    [ServiceContract]
    public interface IUnitConversion
    {
        [OperationContract]
        double FeetToMeeters(double feet);

        [OperationContract]
        Temperature ConvertTemp(Temperature temp);
    }
}
