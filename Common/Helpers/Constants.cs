using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marx.Wolfgang.VocabTrainer.Common.Helpers
{
    public static class Constants
    {
        #if DEBUG
        public static const string SCHOOL_URI = @"..\..\..\Data\School.xml";
        #else
        public static const string SCHOOL_URI = "";
        #endif
    }
}
