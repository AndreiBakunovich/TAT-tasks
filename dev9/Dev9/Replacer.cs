using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev9
{
    class Replacer
    {
        public string ReplacingPartsInStrings(char[] recipient, char[] donor)
        {
            string res = String.Empty;
            //dividion lines on parts
            Random rnd = new Random();

            int donorIntervalStart = rnd.Next(0, donor.Length),
                donorIntervalFinish = rnd.Next(donorIntervalStart, donor.Length),
                recipientIntervalStart = rnd.Next(0, recipient.Length),
                recipientIntervalFinish = rnd.Next(recipientIntervalStart, recipient.Length);
            
            //result configuring
            for (int i = 0; i < recipientIntervalStart; i++)
                res = res + recipient[i];

            for (int i = donorIntervalStart; i < donorIntervalFinish; i++)
                res = res + donor[i];

            for (int i = recipientIntervalFinish; i < recipient.Length; i++)
                res = res + recipient[i];

            return res;
        }
    }
}
