using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfExample
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetInfo")]
        GetServiceInfoResponse GetServiceInfo();
    }
}
