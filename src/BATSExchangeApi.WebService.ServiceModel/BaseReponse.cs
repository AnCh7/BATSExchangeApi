using System.Runtime.Serialization;

using ServiceStack.ServiceInterface.ServiceModel;

namespace BATSExchangeApi.WebService.ServiceModel
{
    [DataContract]
    public class BaseReponse : IHasResponseStatus
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "responseStatus")]
        public ResponseStatus ResponseStatus { get; set; }
    }
}
