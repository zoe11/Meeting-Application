using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace FT_Utils
{
    public class DelegateHelper
    {
        public delegate bool TransactionDelegate();

        public static TransactionDelegate transDelegate { get; set; }

        public static bool InvokeTranscation()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                bool result = transDelegate();
                if (result == true)
                {
                    scope.Complete();
                    return true;
                }               
            }
            return false;
        }
    }
}
