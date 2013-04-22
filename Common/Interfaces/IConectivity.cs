using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Marx.Wolfgang.VocabTrainer.Common.Interfaces
{
    interface IConectivity
    {
        /*
         * Get Requests
         */
        Task<string> GetRequestAsync(Uri uri);
        Task<string> GetRequestAsync(Uri uri, List<KeyValuePair<string, string>> queryParams);
        Task<string> GetRequestAsync(Uri uri, CookieContainer cookies, List<KeyValuePair<string, string>> queryParams);

        //Task<string> GetRequestAsync(Uri uri, CookieContainer cookies, List<KeyValuePair<string, string>> queryParams, string encoding);
        //Task<byte[]> GetBytesAsync(Uri uri, CookieContainer cookies, List<KeyValuePair<string, string>> queryParams);
        //Task<string> PostRequestAsync(Uri uri, CookieContainer cookies, List<KeyValuePair<string, string>> postParams);
    }
}
