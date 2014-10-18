using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnmsMGT_Model;

namespace FT_ControlsUtils
{
    public class ComboBoxDelegateBomGroup4Material : ComboBoxDelegate
    {
        private string _sqlTextBOMGroup = "select * from T_BOMGroup Where BOMGroupName = {0}";
        //private string _sqlTextBOMGroup4IDVer = "select * from T_BOMGroup Where OriginMaterialID = {0} and OriginMaterialVersion = {1}";
        private string _sqlTextMaterial = "select * from T_Material Where MaterialID= {0} and MaterialVersion = {1}";
        private IList<BOMGroupInfo> _bomGroups;
        private IList<BOMInfo> _boms;
        private const int StartTime = 0;

        private DataTable _dt;
        private string _sqlTextBOM = "SELECT * FROM T_BOM where ParentMaterialID={0} AND ParentMaterialVersion={1}";
        private string _sqlText = "";
        private TreeViewExtDataSource<BOMGroupInfo,BOMInfo> _tvDataSource;
        internal override void InitDataSource()
        {
            _tvDataSource = new TreeViewExtDataSource<BOMGroupInfo,BOMInfo>();
            AssemblyDataSourceList();
        }

        private void AssemblyDataSourceList()
        {
            if (RelationOwner != null)
            {
                CreateBOMGroup();
                CreateBOMs();
            }
            
        }

        private void CreateBOMs()
        {
            _sqlText = string.Format(_sqlTextBOM, "'" + (this._tvDataSource.GetEntities())[0].OriginMaterialID + "'", "'" + (this._tvDataSource.GetEntities())[0].OriginMaterialVersion + "'");
            _dt = Builder.GetDbTable(_sqlText);
            _boms = (from DataRow row in _dt.Rows select AssemblyBOMInfo(row)).ToList();

            _tvDataSource.SetOldRelations(_boms);
        }

        private void CreateBOMGroup()
        {
            _sqlText = string.Format(_sqlTextBOMGroup, "'" + RelationOwner + "'");
            _dt = Builder.GetDbTable(_sqlText);
            this._bomGroups = (from DataRow row in _dt.Rows select AssemblyBOMGroup(row)).ToList();
            _tvDataSource.SetEntities(_bomGroups);
        }

        private IList<BOMInfo> CreateBomsByParentIDandVersion(string orgMaterialID, string orgMaterialVer)
        {
            _sqlText = string.Format(_sqlTextBOM, "'" + orgMaterialID + "'", "'" + orgMaterialVer + "'");
            _dt = Builder.GetDbTable(_sqlText);
            IList<BOMInfo> boms = (from DataRow row in _dt.Rows select AssemblyBOMInfo(row)).ToList();
            return boms;
        }

        private MaterialInfo CreateMaterialByIDandVersion(string orgMaterialID, string orgMaterialVer)
        {
            _sqlText = string.Format(_sqlTextMaterial, "'" + orgMaterialID + "'", "'" + orgMaterialVer + "'");
            _dt = Builder.GetDbTable(_sqlText);
            MaterialInfo material = ((from DataRow row in _dt.Rows select AssemblyMaterialInfo(row)).ToList())[0];
            return material;
        }
        private BOMInfo AssemblyBOMInfo(DataRow row)
        {
            var bom = new BOMInfo { BOMGroupName = Convert.ToString(row["BOMGroupName"]), BOMSID = Convert.ToInt32(row["BOMSID"]), ParentMaterialID = Convert.ToString(row["ParentMaterialID"]), ParentMaterialVersion = Convert.ToString(row["ParentMaterialVersion"]), ChildMaterialID = Convert.ToString(row["ChildMaterialID"]), ChildMaterialVersion = Convert.ToString(row["ChildMaterialVersion"])};
            return bom;
        }
        private MaterialInfo AssemblyMaterialInfo(DataRow row)
        {
            var material = new MaterialInfo { MaterialSID = Convert.ToInt32(row["MaterialSID"]), MaterialID = Convert.ToString(row["MaterialID"]), MaterialVersion = Convert.ToString(row["MaterialVersion"]), MaterialChineseName = Convert.ToString(row["MaterialChineseName"]), ApprovedState = Convert.ToString(row["ApprovedState"]), ApprovedOperatorID = Convert.ToString(row["ApprovedOperatorID"]), CreateOperatorID = Convert.ToString(row["CreateOperatorID"]) };
            return material;
        }

        private BOMGroupInfo AssemblyBOMGroup(DataRow row)
        {
            var bomGroup = new BOMGroupInfo
            {
                ApprovedState = Convert.ToString(row["ApprovedState"]),
                ApprovedStateCode = Convert.ToString(row["ApprovedStateCode"]),
                ApprovedOperatorID = Convert.ToString(row["ApprovedOperatorID"]),
                BOMGroupID = Convert.ToString(row["BOMGroupID"]),
                BOMGroupName = Convert.ToString(row["BOMGroupName"]),
                OriginMaterialID = Convert.ToString(row["OriginMaterialID"]),
                OriginMaterialVersion = Convert.ToString(row["OriginMaterialVersion"]),
                AuditStatusCode = Convert.ToString(row["AuditStatusCode"]),
                AuditStatus = Convert.ToString(row["AuditStatus"])
            };
            return bomGroup;
        }

        internal override DataTable AssemblyDataTale()
        {
            DataTable dt = CreateDataTableStructure();
            CreateMaterialTableRecurve(this._tvDataSource.GetEntities()[0], null, 0,ref dt);
            return dt;
        }

        private DataTable CreateDataTableStructure()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("MaterialSID", typeof(int)));
            dt.Columns.Add(new DataColumn("MaterialID", typeof(string)));
            dt.Columns.Add(new DataColumn("MaterialVersion", typeof(string)));
            dt.Columns.Add(new DataColumn("MaterialChineseName", typeof(string)));
            return dt;
        }
        private DataRow AssemblyNewMaterialRow(DataTable dt,MaterialInfo material)
        {
            DataRow row = dt.NewRow();
            row["MaterialSID"] = material.MaterialSID;
            row["MaterialID"] = material.MaterialID;
            row["MaterialVersion"] = material.MaterialVersion;
            row["MaterialChineseName"] = material.MaterialChineseName;
            return row;
        }
        private void CreateMaterialTableRecurve(BOMGroupInfo bomGroup, BOMInfo bom, int startTime,ref DataTable dt)
        {
            IList<BOMInfo> boms;

            if (startTime == 0)
            {
                boms = CreateBomsByParentIDandVersion(bomGroup.OriginMaterialID, bomGroup.OriginMaterialVersion);
                MaterialInfo material = CreateMaterialByIDandVersion(bomGroup.OriginMaterialID, bomGroup.OriginMaterialVersion);
                dt.Rows.Add(AssemblyNewMaterialRow(dt, material));

                //判断是否有孩子节点
                if (boms.Count != 0)
                {
                    startTime++;

                    foreach (BOMInfo bomItem in boms)
                    {
                        CreateMaterialTableRecurve(bomGroup, bomItem, startTime, ref dt);
                    }

                }
            }
            else
            {
                BOMGroupInfo newBomGroup;
                boms = CreateBomsByParentIDandVersion(bom.ChildMaterialID, bom.ChildMaterialVersion);
                MaterialInfo material = CreateMaterialByIDandVersion(bom.ChildMaterialID, bom.ChildMaterialVersion);
                dt.Rows.Add(AssemblyNewMaterialRow(dt, material));
                if (boms.Count != 0)
                {
                    foreach (BOMInfo item in boms)
                    {
                        if (IsSameBOMGroup(item, bom, out newBomGroup))
                        {
                            CreateMaterialTableRecurve(bomGroup, item, startTime, ref dt);
                        }
                        else
                        {
                            CreateMaterialTableRecurve(newBomGroup, item, startTime, ref dt);
                        }
                    }
                }
            }
        }

        private bool IsSameBOMGroup(BOMInfo newBom,BOMInfo oldBom,out BOMGroupInfo newBOMGroup)
        {
            if (newBom.BOMGroupName == oldBom.BOMGroupName)
            {
                newBOMGroup = null;
                return true;
            }
            else
            {
                _sqlText = string.Format(_sqlTextBOMGroup, "'" + newBom.BOMGroupName + "'");
                _dt = Builder.GetDbTable(_sqlText);
                newBOMGroup = (from DataRow row in _dt.Rows select AssemblyBOMGroup(row)).ToList()[0];
                return false;
            }
        }
    
    }
}
