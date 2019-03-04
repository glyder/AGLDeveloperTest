
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using AGL.DeveloperTest.Core;

namespace AGL.Base
{
    public enum MockHttpMessageHandlerObjectType
    {
        FilePath,
        ReturnContent
    }

    public class MockHttpMessageHandler : HttpMessageHandler
    {
        string _path = "";
        string _returnContent = "";

        public MockHttpMessageHandler()
        {

        }

        public MockHttpMessageHandler(MockHttpMessageHandlerObjectType type, 
                                      string objectType)
        {
            switch(type)
            {
                case MockHttpMessageHandlerObjectType.FilePath:
                    _path = objectType;
                    break;
                case MockHttpMessageHandlerObjectType.ReturnContent:
                    _returnContent = objectType;
                    break;
                default:
                    break;
            }
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage = null;
            IFileReader fileReader = new FileHelper(); 

            if (!string.IsNullOrEmpty(_path))
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(fileReader.Get(_path))
                };
            }
            else if (!string.IsNullOrEmpty(_returnContent))
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(_returnContent)
                };
            }
            else
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Content as string")
                };
            }

            return await Task.FromResult(responseMessage);
        }
    }
}
