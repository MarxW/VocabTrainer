using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marx.Wolfgang.VocabTrainer.ViewModel.Helpers
{
    public static class Constants
    {
        #if DEBUG
        public static string SCHOOL_URI = @"http://localhost:9300/";
        #else
        public static const string SCHOOL_URI = "";
        #endif
    }
}
