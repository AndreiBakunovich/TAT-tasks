using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev9
{
    class Replacer
    {
        //dividion lines on parts
        public string ReplacingPartsInStrings(char[] recipient,int recipientIntervalStart, int recipientIntervalFinish,
            char[] donor, int donorIntervalStart, int donorIntervalFinish)
        {
            string res = String.Empty;

            //result configuring
            string resipientString = new string(recipient);
            string donorString = new string(donor);

            res = String.Concat(res, resipientString.Substring(0, recipientIntervalStart));
            res = String.Concat(res, donorString.Substring(donorIntervalStart, donorIntervalFinish - donorIntervalStart));
            res = String.Concat(res, resipientString.Substring(recipientIntervalFinish, resipientString.Length - recipientIntervalFinish));
            return res;
        }
    }
}
