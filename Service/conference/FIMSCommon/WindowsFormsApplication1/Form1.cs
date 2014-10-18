using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FT_StoreProcess;
using FT_Utils;
using FT_ENV;
using FT_ControlsUtils;
using FTComponentSet;

namespace WindowsFormsApplication1
{
    public partial class Form1 : FTForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(GetSerialID.GetSerialIDByCustomer());
            //MessageBox.Show(TimeHelper.SetDateTime().ToString() + "\r\n");
          //  MessageBox.Show(GetSerialID.GetSerialIDByCustomer() + "\r\n" +"OK"+ GetSerialID.GetSerialIDByCustomerContacts());
            string loginID = FT_Utils.LoginHelper.GetLoginUserID();
            FT_Utils.LogHelper.LogWrite("SH");
            //this.IsControlBoxEnable = true;

            comboBoxFT1.SetDataSourceByDICName("DIC_MaterialUnit");
            comboBoxFT1.ViewColumn = "MaterialUnitCode";
            comboBoxFT1.DisplayColumn = "MaterialUnitChinese";
            comboBoxFT1.DataMode = ComboBoxFTMode.AllDatas;
            var dictinctCols = new List<string>
                {
                    "MaterialUnitCode",
                    "MaterialUnitChinese"
                };
            comboBoxFT1.DistinctCols = dictinctCols;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    ExcuteStoreProcess excute = new ExcuteStoreProcess();
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.BOM流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.采购计划单编号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.采购计划单供应商明细流水号).ToString()  + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.采购计划单物料明细流水号).ToString()  + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.采购实施单编号).ToString()  + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.采购实施单供应商明细流水号).ToString()  + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.采购实施单物料明细流水号).ToString()  + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.附件流水号).ToString()  + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.供应商编号).ToString()  + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.供应商联系人流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.客户编号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.客户发货通知单号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.客户联系人流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.库存出库登记流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.库存入库登记流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.内部订单号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.内部订单明细流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.设备点检月表流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.生产需求分析单贡献明细流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.生产需求分析单号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.生产需求分析单明细流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.生产需求分析单损耗明细流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.实体预占出库登记流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.实体预占入库登记流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.实体自由出库登记流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.实体自由入库登记流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.外部出货单号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.物料供应商价格方案流水号, "CESHE2", "V1").ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.物料公共价格方案流水号, "CESHE2", "V1").ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.物料客户价格方案流水号, "CESHE2", "V1").ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.物料流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.在制预占出库登记流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.在制预占入库登记流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.在制自由出库登记流水号).ToString() + "\r\n";
        //    this.textBox1.Text += excute.GetSerialIDByStoreProcessName(StoreProcessEnum.在制自由入库登记流水号).ToString() + "\r\n";

        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByAttachment() + "\t" + "Pro_GetSerialIDIntByAttachment()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByBeMadeCampOnStockInRecordDetails() + "\t" + "Pro_GetSerialIDIntByBeMadeCampOnStockInRecordDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByBeMadeCampOnStockOutRecordDetails() + "\t" + "Pro_GetSerialIDIntByBeMadeCampOnStockOutRecordDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByBeMadeFreeStockInRecordDetails() + "\t" + "Pro_GetSerialIDIntByBeMadeFreeStockInRecordDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByBeMadeFreeStockOutRecordDetails() + "\t" + "Pro_GetSerialIDIntByBeMadeFreeStockOutRecordDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByBOM() + "\t" + "Pro_GetSerialIDIntByBOM()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByCustomerContacts() + "\t" + "Pro_GetSerialIDIntByCustomerContacts()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByEntityCampOnStockInRecordDetails() + "\t" + "Pro_GetSerialIDIntByEntityCampOnStockInRecordDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByEntityCampOnStockOutRecordDetails() + "\t" + "Pro_GetSerialIDIntByEntityCampOnStockOutRecordDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByEntityFreeStockInRecordDetails() + "\t" + "Pro_GetSerialIDIntByEntityFreeStockInRecordDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByEntityFreeStockOutRecordDetails() + "\t" + "Pro_GetSerialIDIntByEntityFreeStockOutRecordDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByEquipmentCheckList() + "\t" + "Pro_GetSerialIDIntByEquipmentCheckList()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByInnerSalesOrderDetails() + "\t" + "Pro_GetSerialIDIntByInnerSalesOrderDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByMaterial() + "\t" + "Pro_GetSerialIDIntByMaterial()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByProductionDemandAnalysisListConsumptionDetails() + "Pro_GetSerialIDIntByProductionDemandAnalysisListConsumptionDetails()方法调用成功!" + "\r\n";
        //    ////error
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByProductionDemandAnalysisListContributeAmountDetails() + "Pro_GetSerialIDIntByProductionDemandAnalysisListContributeAmountDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByProductionDemandAnalysisListDetails() + "\t" + "Pro_GetSerialIDIntByProductionDemandAnalysisListDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByPurchaseCarryOutListMaterialDetails() + "\t" + "Pro_GetSerialIDIntByPurchaseCarryOutListMaterialDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByPurchaseCarryOutListVendorDetails() + "\t" + "Pro_GetSerialIDIntByPurchaseCarryOutListVendorDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByPurchasePlanListMaterialDetails() + "\t" + "Pro_GetSerialIDIntByPurchasePlanListMaterialDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByPurchasePlanListVendorDetails() + "\t" + "Pro_GetSerialIDIntByPurchasePlanListVendorDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByStockInRecordDetails() + "\t" + "Pro_GetSerialIDIntByStockInRecordDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByStockOutRecordDetails() + "\t" + "Pro_GetSerialIDIntByStockOutRecordDetails()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDIntByVendorContacts() + "\t" + "Pro_GetSerialIDIntByVendorContacts()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDNvarcharByCustomerDeliveryNotice() + "\t" + "Pro_GetSerialIDNvarcharByCustomerDeliveryNotice()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDNvarcharByCustomerInfo() + "\t" + "Pro_GetSerialIDNvarcharByCustomerInfo()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDNvarcharByDeliveryOrderBill() + "\t" + "Pro_GetSerialIDNvarcharByDeliveryOrderBill()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDNvarcharByInnerSalesOrder() + "\t" + "Pro_GetSerialIDNvarcharByInnerSalesOrder()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDNvarcharByMaterialCustomerPriceScheme("CESHE2", "V1") + "\t" + "Pro_GetSerialIDNvarcharByMaterialCustomerPriceScheme()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDNvarcharByMaterialVendorPriceScheme("CESHE2", "V1") + "\t" + "Pro_GetSerialIDNvarcharByMaterialVendorPriceScheme()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDNvarcharByProductionDemandAnalysisList() + "\t" + "Pro_GetSerialIDNvarcharByProductionDemandAnalysisList()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDNvarcharByPurchaseList() + "\t" + "Pro_GetSerialIDNvarcharByPurchaseList()方法调用成功!" + "\r\n";
        //    //this.textBox1.Text += ExcuteStoreProcesscs.Pro_GetSerialIDNvarcharByPurchasePlanList() + "\t" + "Pro_GetSerialIDNvarcharByPurchasePlanList()方法调用成功!" + "\r\n";
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = FTEnv.IsDebug.ToString();

            this.textBox2.Text = new ExcuteStoreProcess().GetSerialIDByStoreProcessName(StoreProcessEnum.Pro_GetSerialIDNvarcharByIQCBatchCheckout).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += FT_ENV.FTEnv.IsDebug.ToString() + "\n";
            this.textBox1.Text += FT_ENV.FTEnv.DBADDRESS.ToString() + "\n";
            this.textBox1.Text += FT_ENV.FTEnv.USERCONN.ToString() + "\n";
            this.textBox1.Text += FT_ENV.FTEnv.IsMessageOn.ToString() + "\n";
            this.textBox1.Text += FT_ENV.FTEnv.IsAutoUpdateOn.ToString() + "\n";
            this.textBox1.Text += FT_ENV.FTEnv.IsEmpowerEnable.ToString() + "\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Test test = new Test();
            ////test.Time = DateTime.Now;
            //test.Time = new DateTime(1, 1, 1);
            //Test1 test1 = new Test1();
            ////test1.Time = null;
            //test1.Time = null;
            //Test2 test2 = new Test2();
            //Test2 test22 = new Test2();
            //ConvertUtil.conversion(test2, test);
            //ConvertUtil.conversion(test22, test1);

            //var l = LoginHelper.GetLoginUserID();

            //var d = TimeHelper.SetDateTime();

            //以下代码下载供应商附件
            FTPHelper FTP = new FTPHelper();
            string[] UploadPathUnTrans = new string[1];
            string AbsoluteFileName;
            //UploadPathUnTrans[0] = "Material/JT-FG-900101.A/MATT02/2/E_SPEC-日本粗糙度标准539.pdf";
            UploadPathUnTrans[0] = "customer/BA-20130721-0001/客户信息附件.pdf";
            AbsoluteFileName = System.IO.Path.GetTempPath() + System.IO.Path.GetFileName(UploadPathUnTrans[0]);//下载保存到系统的temp目录
            bool res = FTP.Download(UploadPathUnTrans, AbsoluteFileName);//下载
            if (!res)
            {
                FTMessageBox.ShowErrorDialog("附件下载失败!");
                return;
            }

            //以下代码打开供应商附件，PDF格式
            try
            {
                System.Threading.Thread.Sleep(1000);
                FTComponentSet.PdfFormFT frm = new FTComponentSet.PdfFormFT(AbsoluteFileName);//打不开，是因为下载后需要延时一段时间才能打开
                frm.Show();
            }
            catch (Exception ex)
            {
                FTMessageBox.ShowErrorDialog("Adobe Reader 启动失败！");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FTEnv.GetConnection("ftuser");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] UploadPathUnTrans = new string[2];
            //上传附件文件
            FTPHelper FTP = new FTPHelper();
            string AbsoluteFileName;
            UploadPathUnTrans[0] = "Vendor";
            UploadPathUnTrans[1] = "VEN-60001";
            AbsoluteFileName = "C:\\Users\\Administrator\\Desktop\\文献\\钒催化剂形状对内表面利用率的影响_潘银珍.pdf";
            bool res = FTP.Upload(UploadPathUnTrans, AbsoluteFileName);//上传

            if (!res)
            {
                FTMessageBox.ShowErrorDialog("供应商附件信息上传失败！");
                return;
            }
        }


    }

    public  class Test
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }
    public class Test1
    {
        public string Name { get; set; }
        public System.Nullable<DateTime> Time { get; set; }
    }
    public class Test2
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }
}