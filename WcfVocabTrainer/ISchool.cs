using Marx.Wolfgang.VocabTrainer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfVocabTrainer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISchool" in both code and config file together.
    [ServiceContract]
    public interface ISchool
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetClassRooms")]
        List<BasicClassRoom> GetClassRooms();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetLastDataUpdate")]
        DateTime GetLastDataUpdate();

        [OperationContract]
        void DoWork();
    }
}
