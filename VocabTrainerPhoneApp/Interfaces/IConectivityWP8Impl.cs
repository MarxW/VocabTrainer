using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VocabTrainerPhoneApp.Interfaces
{
    class IConectivityWP8Impl //: IConectivity
    {
        public Task<string> GetRequestAsync(Uri uri)
        {
            var tcs = new TaskCompletionSource<string>();
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.AllowReadStreamBuffering = true;
            webRequest.BeginGetResponse(iar =>
            {
                var request = (HttpWebRequest)iar.AsyncState;
                try
                {
                    var response = request.EndGetResponse(iar);
                    Stream streamResponse = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(streamResponse);
                    string responseBody = streamReader.ReadToEnd();
                    streamResponse.Close();
                    streamReader.Close();
                    response.Close();
                    tcs.TrySetResult(responseBody);
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled();
                }
                catch (Exception exc)
                {
                    tcs.TrySetException(exc);
                }
            }, webRequest);
            return tcs.Task;
        }

        public Task<string> GetRequestAsync(Uri uri, string encoding)
        {
            var tcs = new TaskCompletionSource<string>();
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.AllowReadStreamBuffering = true;
            webRequest.BeginGetResponse(iar =>
            {
                var request = (HttpWebRequest)iar.AsyncState;
                try
                {
                    var response = request.EndGetResponse(iar);
                    Stream streamResponse = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(streamResponse, Encoding.GetEncoding(encoding));
                    string responseBody = streamReader.ReadToEnd();
                    streamResponse.Close();
                    streamReader.Close();
                    response.Close();
                    tcs.TrySetResult(responseBody);
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled();
                }
                catch (Exception exc)
                {
                    tcs.TrySetException(exc);
                }
            }, webRequest);
            return tcs.Task;
        }

        public Task<string> GetRequestAsync(Uri uri, List<KeyValuePair<string, string>> queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRequestAsync(Uri uri, System.Net.CookieContainer cookies, List<KeyValuePair<string, string>> queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRequestAsync(Uri uri, List<KeyValuePair<string, string>> queryParams, string encoding)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRequestAsync(Uri uri, CookieContainer cookies, List<KeyValuePair<string, string>> queryParams, string encoding)
        {
            throw new NotImplementedException();
        }
    }
}
