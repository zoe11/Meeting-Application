using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FT_ENV;

namespace FT_StoreProcess
{
    public class GetSerialID
    {
        public static int GetSerialIDByMaterial()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByMaterial(ref serialID);
                return serialID.Value;
            }
        }

        public static int GetSerialIDByBOM()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByBOM(ref serialID);
                return serialID.Value;
            }
        }
        public static string GetSerialIDByCustomer()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                string temp = "";
                dc.Pro_GetSerialIDNvarcharByCustomerInfo(ref temp);
                return temp;
            }
        }

        public static int GetSerialIDByCustomerContacts()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByCustomerContacts(ref serialID);
                return serialID.Value;
            }
        }


        public static int GetSerialIDByAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByAttachment(ref serialID);
                return serialID.Value;
            }
        }
    }
}
