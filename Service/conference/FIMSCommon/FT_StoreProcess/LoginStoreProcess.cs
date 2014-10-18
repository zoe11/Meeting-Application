using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FT_Utils;
using FT_ENV;
namespace FT_StoreProcess
{
    public class LoginStoreProcess
    {
        private StoreProcessDataContext dc;
        public int PreventRepeatLogin()
        {
            int? result = 0;
            dc = new StoreProcessDataContext(FTEnv.DBADDRESS);
            dc.Pro_PreventRpeatLogin(LoginHelper.GetLoginUserID(), ref result);
            return result.Value;
        }

        public void CloseConnection()
        {
            dc.Dispose();
        }
    }
}
