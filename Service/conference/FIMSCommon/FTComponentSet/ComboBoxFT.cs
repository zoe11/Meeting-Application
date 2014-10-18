using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Collections;
using FT_ENV;

namespace FTComponentSet
{
    public class ComboBoxFT : ComboBox
    {
        private bool isLabelInit = false;
        private bool isRelease = !FTEnv.IsDebug;
        private Dictionary<int, int> _newColumnWidth;
        private IList<int> _displayOrder;
        private bool isKeyValue = false;
        private bool isKeyOperatorValue = false;
        private bool isSql = false;
        private bool isDataTable = false;
        private bool _isColsClear = true;
        private bool start = true;
        private StringList m_slSuggestions = new StringList(); //A handy class used with the suggestion features.
        private Keys m_kcLastKey = Keys.Space; //Last key pressed.
        private int[] m_iaColWidths = new int[1];//Used for quick access to the column widths.
        public uint ColumnSpacing = 4; //Minimum spacing between columns. Don't go crazy with this...
        private CCBColumnCollection m_Cols = new CCBColumnCollection();//A class used for managing the columns.
        private DBCreater _dbCreater = new DBCreater();
        private DataTable m_dtData = null; //Main DataTable and DataView that contain the information to be shown in the ColumnComboBox.
        private DataView m_dvView = null;
        private int _topNumber = 0;
        //private bool m_bShowHeadings = true; //Was going to do something with this but ran out of time.
        private string m_iViewColumn = "";//Which of the columns will be shown in the text box.
        private bool m_bInitItems = true; //Flags used to determine when the things need to be initialized.
        private bool m_bInitDisplay = true;
        private bool m_bInitSuggestionList = true;
        private string m_iDisplayColumn = "";
        private bool m_bTextChangedInternal = false;//Used when the text is being changed by another member of the class.
        public bool DropDownOnSuggestion = true;
        public bool Suggest = true; //Suggesting can be turned on or off. No need for the whole property write out.
        private int m_iSelectedIndex = -1; //Used for storing the selected index without depending on the base.

        private System.ComponentModel.Container components = null;
        public bool ShowLabel { get; set; }
        public Label lb = null;
        private readonly string _lbText = "*";
        private string code = "";
        private bool isHaveDataWhenNoData = true;
        private Dictionary<object, object> orderBy = new Dictionary<object, object>();
        private string distinctCol;
        private List<string> distinctCols;

        public bool IsDropDown { get; set; }//废弃

        public List<string> DistinctCols 
        {
            get
            {
                return this.distinctCols;
            }
            set
            {
                this.distinctCols = value;
                this._dbCreater.SetDistinctCols(value);
            }
        }

        public Dictionary<object, object> OrderBy
        {
            get
            {
                return this.orderBy;
            }
            set
            {
                foreach (var item in value)
                {
                    if (item.Value.ToString() != "ASC"&&item.Value.ToString() != "DESC")
                    {
                        throw new Exception("值必须为ASC或者DESC");
                    }
                }
                this.orderBy = value;
                this._dbCreater.SetOrderBy(orderBy);
            }
        }

        public string DistinctCol 
        {
            get
            {
                return this.distinctCol;
            }
            set
            {
                this.distinctCol = value;
                this._dbCreater.SetDistinctCol(distinctCol);
            }
        }
        public bool IsHaveDataWhenNoData 
        {
            get
            {
                return this.isHaveDataWhenNoData;
            }
            set
            {
                this.isHaveDataWhenNoData = value;
            }
        }
        public string Code 
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        public ComboBoxFT()
            : base()
        {
            SkinController.SetFTComboBoxSkin(this);
            this.SizeChanged += new EventHandler(this.SizeChange);
            if (components == null)
                components = null;
            Data = new DataTable(); //Make sure the DataTable is not blank
            //_dbCreater.OpenDbConn();
            Init();
            
        }
        //以下方法不可取。会出问题 引以为戒：参照：http://hi.baidu.com/chenfengweioo/item/21ccf959d4c5830be7c4a5f5
        //~ComboBoxFT()
        //{
        //    _dbCreater.CloseDbConn();
        //}

        private void Init()
        {
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion
        public void SetDataSourceByDICName(string tableName)
        {
            this.isSql = false;
            this.isKeyValue = false;
            this.isKeyOperatorValue = false;
            if (!string.IsNullOrEmpty(tableName))
            {
                _dbCreater.SetTableName(tableName);
            }
            else
            {
                throw new Exception("字典or表名不能为空");
            }
        }

        public void SetDataSourceByDICNameAndKeyValue(string tableName, Dictionary<object, object> keyAndValue)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                //_dbCreater.SetTableName(tableName);
                this.isKeyValue = true;
                this.isKeyOperatorValue = false;
                this.isSql = false;
                _dbCreater.SetTableNameKeyAndValue(tableName, keyAndValue);
            }
            else
            {
                throw new Exception("字典or表名不能为空");
            }
        }

        public void SetDataSourceByDICNameAndKeyOperatorValue(string tableName, Dictionary<object, object> keyOperator,Dictionary<object,object> keyValue)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                this.isKeyValue = false;
                this.isSql = false;
                this.isKeyOperatorValue = true;
                _dbCreater.SetTableNameKeyOperatorValue(tableName, keyOperator,keyValue);
            }
            else
            {
                throw new Exception("字典or表名不能为空");
            }
        }

        public void SetDataSourceByDICNameAndSql4Where(string tableName, string sql)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                this.isKeyValue = false;
                this.isKeyOperatorValue = false;
                this.isSql = true;
                _dbCreater.SetTableNameAndSql4Where(tableName,sql);
            }
            else
            {
                throw new Exception("字典or表名不能为空");
            }
        }

        public void SetDataSourceByDataTable(DataTable dt)
        {
            if (dt != null)
            {
                this.Data = dt;
                this.isDataTable = true;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            try
            {
                //if (m_bInitSuggestionList)
                //    InitSuggestionList();
                base.OnKeyDown(e);
                m_kcLastKey = e.KeyCode;
            }
            catch (Exception ex)
            {
                if (isRelease)
                {
                    return;
                }
                throw new Exception(ex.Message + "\r\nIn ColumnComboBox.OnKeyDown(KeyEventArgs).");
            }
        }

        protected override void OnTextChanged(EventArgs e) //Doesn't call the base so no wiring up this event for you.
        {
            try
            {
                //Run a few checks to make sure there should be any "suggesting" going on.
                if (m_bTextChangedInternal)//If the text is being changed by another member of this class do nothing
                {
                    m_bTextChangedInternal = false; //It will only be getting changed once internally, next time do something.
                    return;
                }
                start = false;
                if (!Suggest)
                    return;
                if (SelectionStart < this.Text.Length)
                {
                    if (this.m_dvView.Count == 0)
                    {
                        InitItems();
                        InitDisplay();

                    }

                    return;
                }

                int iOffset = 0;
                if ((m_kcLastKey == Keys.Back) || (m_kcLastKey == Keys.Delete))//Obviously we aren't going to find anything when they push Backspace or Delete
                {
                    UpdateIndex();
                    //this.OnDropDown(e);
                    //return;
                }
                if (this.Text.Length < 1)
                {
                    this.DroppedDown = false;
                }
                if (m_slSuggestions == null || this.Text.Length < 1)

                    return;

                //Put the current text into temp storage
                string sText;
                sText = this.Text;
                //if (this.dataMode == ComboBoxFTMode.AllDatas)
                //{
                //    //_isColsClear = false;
                //    if (this.isKeyValue)
                //    {
                //        this.Data = _dbCreater.GetDbTable4TopTenByKeyValue(sText, ViewColumn, TopNumber);
                //    }
                //    else if (this.isKeyOperatorValue)
                //    {
                //        this.Data = _dbCreater.GetDbTable4TopTenByKeyOperatorValue(TopNumber);
                //    }
                //    else if (this.isSql)
                //    {
                //        this.Data = _dbCreater.GetDbTable4TopTenBySql4Where(TopNumber);
                //    }
                //    else
                //    {
                //        this.Data = _dbCreater.GetDbTable4TopTenByInput(sText, ViewColumn, TopNumber);
                //    }

                //    if (m_bInitSuggestionList)
                //        InitSuggestionList();
                //    this.OnDropDown(e);
                //}
                if (this.dataMode == ComboBoxFTMode.TopDatas)
                {
                    this.m_bInitItems = true;
                    m_bInitSuggestionList = true;
                    this.OnDropDown(e);
                }
                string sOriginal = sText;
                sText = sText.ToUpper();
                int iLength = sText.Length;
                string sFound = null;
                int index = 0;
                //see if what is currently in the text box matches anything in the string list
                for (index = 0; index < m_slSuggestions.Count; index++)
                {
                    string sTemp = m_slSuggestions[index].ToUpper();
                    if (sTemp.Length == sText.Length)
                    {
                        if (sTemp.IndexOf(sText, 0, sText.Length) > -1)
                        {
                            sFound = m_slSuggestions[index];
                            break;
                        }
                    }
                }
                if (sFound != null)
                {
                    m_bTextChangedInternal = true;
                    if (DropDownOnSuggestion && !DroppedDown)
                    {
                        m_bTextChangedInternal = true;
                        string sTempText = Text;
                        this.DroppedDown = true;
                        this.Cursor = Cursors.Default;
                        Text = sTempText;
                        m_bTextChangedInternal = false;
                    }
                    if (this.Text != sFound)
                    {
                        this.Text += sFound.Substring(iLength);
                        this.SelectionStart = iLength + iOffset;
                        this.SelectionLength = this.Text.Length - iLength + iOffset;
                        m_iSelectedIndex = index;
                        SelectedIndex = index;
                        //base.OnSelectedIndexChanged(new EventArgs());
                    }
                    else
                    {
                        UpdateIndex();
                        this.SelectionStart = iLength;
                        this.SelectionLength = 0;
                    }
                }
                else
                {
                   // m_bTextChangedInternal = true;
                    m_iSelectedIndex = -1;
                    SelectedIndex = -1;
                    this.DroppedDown = true;
                    this.Cursor = Cursors.Default;
                    Text = sOriginal;
                    m_bTextChangedInternal = false;
                    //base.OnSelectedIndexChanged(new EventArgs());
                    this.SelectionStart = sOriginal.Length;
                    this.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                if (isRelease)
                {
                    return;
                }
                throw new Exception(ex.Message + "\r\nIn ColumnComboBox.OnTextChanged(EventArgs).");
            }
            SetToIndexOf(Text);
        }

        protected override void OnDropDown(EventArgs e)
        {
            try
            {
                this.start = true;
                //Initialize as required.
                base.OnDropDown(e);
                //if (IsHaveDataWhenNoData&&this.m_dvView.Count == 0 && this.dataMode != ComboBoxFTMode.Null)
                //{
                //    this.Data = _dbCreater.GetDbTable4TopTenByInput("", ViewColumn, TopNumber);
                //}
                if (m_bInitItems)
                    InitItems();
                if (m_bInitDisplay)
                    InitDisplay();
                GetNewColumnWidth();
                isLabelInit = true;
                
            }
            catch (Exception ex)
            {
                //吃掉异常
                if (isRelease)
                {
                    return;
                }
                throw new Exception(ex.Message + "\r\nIn ColumnComboBox.OnDropDown(EventArgs).");
            }
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            try
            {
                base.OnDropDownClosed(e);
                if (m_bInitSuggestionList)
                    InitSuggestionList4DisplayColumn();
                SetToIndexOf(Text);
            }
            catch (Exception)
            {
                if (isRelease)
                {
                    return;
                }
                //吃掉异常
            }

        }

        public void ResetItem()
        {

            this.SelectedIndex = -1;
            this.Text = string.Empty;
            this.start = true;
            //this._dbCreater.DisposeDistinctCols();
            this._dbCreater.DisposeOrderBy();
            this._isColsClear = true;
            InitItems();
            InitDisplay();
            GetNewColumnWidth();
            this.Text = String.Empty;
        }

        public void ResetItem(bool isClear)
        {

            this.SelectedIndex = -1;
            this.Text = string.Empty;
            this.start = true;
            if (isClear)
            {
                this._dbCreater.DisposeDistinctCols();
                this._dbCreater.DisposeOrderBy();
            }

            this._isColsClear = true;
            InitItems();
            InitDisplay();
            GetNewColumnWidth();
            this.Text = String.Empty;
        }

        //protected override void OnLeave(EventArgs e)
        //{
        //    base.OnLeave(e);
        //    SetToIndexOf(Text);
        //}

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            try
            {
                //Keep track of this internally.
                m_iSelectedIndex = base.SelectedIndex;
                //以下事件是用户捕捉SelectedIndexChanged事件的源头
                base.OnSelectedIndexChanged(e);
            }
            catch (Exception ex)
            {
                if (isRelease)
                {
                    return;
                }
                throw new Exception(ex.Message + "\r\nIn ColumnComboBox.OnSelectedIndexChanged(EventArgs).");
            }
        }

        private void GetNewColumnWidth()
        {
            _newColumnWidth = new Dictionary<int, int>();
            _displayOrder = GetNewDisplayOrder();
            for (int i = 0; i < m_Cols.Count; i++)
            {
                _newColumnWidth.Add(i, m_Cols[_displayOrder[i]].CalculatedWidth);
            }
        }

        private IList<int> GetNewDisplayOrder()
        {
            Dictionary<int, int> columnAndOrder = new Dictionary<int, int>();
            IList<int> displayOrder = new List<int>();
            for (int i = 0; i < m_Cols.Count; i++)
            {
                columnAndOrder.Add(i, m_Cols[i].DisplayOrder);
            }
            List<KeyValuePair<int, int>> keyValue = columnAndOrder.OrderBy(o => o.Value).ToList();
            foreach (var item in keyValue)
            {
                displayOrder.Add(item.Key);
            }
            return displayOrder;
        }

        //This is where the magic happens that makes it appear dropped down with multiple columns
         protected override void OnDrawItem(DrawItemEventArgs e)
		{
            
            try
            {

                int iIndex = e.Index;
                if (iIndex > -1)
                {
                    int iXPos = 0;
                    int iYPos = 0;
                    DataRow dr = m_dvView[iIndex].Row;
                    //if (isLabelInit)
                    //{
                    //    int columnCount = m_Cols.Count;
                    //    for (int i = 0; i < columnCount; i++)
                    //    {
                    //        Label label = new Label();
                    //        label.Width = _newColumnWidth[i];
                    //        //label.Text = dr[_displayOrder[i]].ToString();
                    //        label.Height = ItemHeight;
                    //        label.Text = "testC" + i;
                    //        label.Location = new Point(this.Location.X + 10, this.Location.Y +10);
                    //        label.ForeColor = Color.Black;
                    //        label.BackColor = Color.Transparent;
                    //        //this.Parent.Controls.Add(label);
                    //    }
                    //    isLabelInit = false;
                    //}
                    e.DrawBackground();

                    for (int index = 0; index < m_Cols.Count; index++) //Loop for drawing each column
                    {
                        if (m_Cols[_displayOrder[index]].Display == false)
                            continue;
                        e.Graphics.DrawString(dr[_displayOrder[index]].ToString(), Font, new SolidBrush(e.ForeColor), new RectangleF(iXPos, e.Bounds.Y, _newColumnWidth[index], ItemHeight));
                        iXPos += _newColumnWidth[index] - 4;
                    }
                    iXPos = 0;
                    iYPos += ItemHeight;
                    e.DrawFocusRectangle();
                    base.OnDrawItem(e);
                }
            }
            catch (Exception ex)
            {
                if (isRelease)
                {
                    return;
                }
                throw new Exception(ex.Message + "\r\nIn ColumnComboBox.OnDrawItem(DrawItemEventArgs).");
            }
		}
        private void InitItems()
        {
            try
            {
                //Reset the Columns and the base.Items list
                if (this.dataMode == ComboBoxFTMode.Null)
                {
                    return;
                }
                if (this.dataMode == ComboBoxFTMode.AllDatas)
                {
                    if (this.isKeyValue)
                    {
                        this.Data = _dbCreater.GetDbTableByKeyValue();
                    }
                    else if (this.isKeyOperatorValue)
                    {
                        this.Data = _dbCreater.GetDbTableByKeyOperatorValue();
                    }
                    else if (this.isSql)
                    {
                        this.Data = _dbCreater.GetDbTableBySql4Where();
                    }
                    else if (this.isDataTable)
                    {
                        
                    }
                    else
                    {
                        this.Data = _dbCreater.GetDbTableByDICName();
                    }

                }
                if (this.dataMode == ComboBoxFTMode.TopDatas && start)
                {
                    if (this.isKeyValue)
                    {
                        this.Data = _dbCreater.GetDbTable4TopTenByKeyValue(Text, ViewColumn, TopNumber);
                    }
                    else if (this.isKeyOperatorValue)
                    {
                        this.Data = _dbCreater.GetDbTable4TopTenByKeyOperatorValue(Text, ViewColumn, TopNumber);
                    }
                    else if (this.isSql)
                    {
                        this.Data = _dbCreater.GetDbTable4TopTenBySql4Where(TopNumber);
                    }
                    else if (this.isDataTable)
                    {
                        
                    }
                    else
                    {
                        this.Data = _dbCreater.GetDbTable4TopTenByInput(Text, ViewColumn, TopNumber);
                    }
                   
                    if (m_bInitSuggestionList)
                        InitSuggestionList();
                }
                if (_isColsClear)
                {
                    m_Cols.Clear();
                    foreach (DataColumn dc in m_dtData.Columns)
                    {
                        m_Cols.Add(new CCBColumn(dc.Caption));
                    }
                    this.m_bInitItems = false;
                    this.m_bInitDisplay = false;
                    this.Columns[ViewColumn].DisplayOrder = 1;
                    this.m_bInitItems = true;
                    this.m_bInitDisplay = true;
                    _isColsClear = false;
                }

                //Set to the first or last column if an invlid ViewColumn is specified.
                //if(m_iViewColumn > m_Cols.Count - 1)
                //    m_iViewColumn = m_Cols.Count - 1;
                //if(m_iViewColumn < 0)
                //    m_iViewColumn = 0;

                //Set up the events for the columns
                for (int index = 0; index < m_Cols.Count; index++)
                {
                    m_Cols[index].OnColumnDisplayChanged += new ChangeColumnDisplayHandler(ColumnComboBox_OnColumnDisplayChanged);
                }
                //base.SelectedIndex = -1;
                base.Items.Clear();
                //Put the stuff from the ViewColumn into the base so other base functionality will work
                foreach (DataRowView drv in m_dvView)
                {
                    string sTemp = drv[DisplayColumn].ToString();
                    base.Items.Add(sTemp);
                }
                m_bInitItems = false;
                //Set the flag to initialize the display before next drop down
                m_bInitDisplay = true;
            }
            catch (Exception ex)
            {
                if (isRelease)
                {
                    return;
                }
                throw new Exception(ex.Message + "\r\nIn ColumnComboBox.InitItems().");
            }
        }
        private void InitDisplay()
        {
            try
            {
                //Set the widths of the columns
                int[] m_iaColWidths = new int[m_Cols.Count];
                SizeF size = new SizeF(10000, ItemHeight);//Here is a nice magic number for you but it should suffice.
                Graphics g = CreateGraphics();
                m_iaColWidths = new int[m_Cols.Count];
                //Measure each column width and set the largest size needed for each column
                foreach (DataRowView drv in m_dvView)
                {
                    for (int index = 0; index < m_Cols.Count; index++)
                    {
                        string sTemp = drv[index].ToString().Trim();
                        int iTempWidth = (int)g.MeasureString(sTemp, Font, size).Width;
                        if (iTempWidth > m_iaColWidths[index])
                            m_iaColWidths[index] = iTempWidth;
                    }
                }
                DropDownWidth = 1;
                for (int index = 0; index < m_iaColWidths.Length; index++)
                {
                    if (m_Cols[index].Width < 0) //It will be < 0 if it hasn't been initialized.
                        m_Cols[index].CalculatedWidth = m_iaColWidths[index] + (int)ColumnSpacing;
                    else
                        m_Cols[index].CalculatedWidth = m_Cols[index].Width + (int)ColumnSpacing;
                    int a = 0;
                    a++;
                    if (m_Cols[index].Display)
                        DropDownWidth += m_Cols[index].CalculatedWidth;
                }
                DropDownWidth += 16;//Another nice magic number to represent the vertical scroll bar width
                m_bInitDisplay = false;
            }
            catch (Exception ex)
            {
                if (isRelease)
                {
                    return;
                }
                throw new Exception(ex.Message + "\r\nIn ColumnComboBox.InitDisplay().");
            }
        }

        //Put all the data from the ViewColumn into a StringList for quicker suggesting later.
        private void InitSuggestionList()
        {
            m_slSuggestions.Clear();
            foreach (DataRowView drv in m_dvView)
            {
                string sTemp = drv[m_iViewColumn].ToString();
                m_slSuggestions.Add(sTemp);
            }
        }

        private void InitSuggestionList4DisplayColumn()
        {
            m_slSuggestions.Clear();
            foreach (DataRowView drv in m_dvView)
            {
                string sTemp = drv[DisplayColumn].ToString();
                m_slSuggestions.Add(sTemp);
            }
        }

        //Sometimes you just have to command the ComboBox to update its SelectedIndex.
        //This function will do that based on the current text.
        public void UpdateIndex()
        {
            try
            {
                if (m_bInitItems)
                    InitItems();
                if (m_bInitSuggestionList)
                    InitSuggestionList();
                string sText = Text;
                int index = 0;
                for (index = 0; index < m_dvView.Count; index++)
                {
                    if (m_dvView[index][ViewColumn].ToString() == sText)
                    {
                        if (SelectedIndex != index)
                        {
                            m_bTextChangedInternal = true;
                            m_iSelectedIndex = index;
                            SelectedIndex = index;
                            //base.OnSelectedIndexChanged(new EventArgs());
                            m_bTextChangedInternal = false;
                        }
                        break;
                    }
                }
                if (index >= m_dvView.Count)
                {
                    m_bTextChangedInternal = true;
                    m_iSelectedIndex = -1;
                    SelectedIndex = -1;
                    // base.OnSelectedIndexChanged(new EventArgs());
                    m_bTextChangedInternal = false;
                }
            }
            catch (Exception ex)
            {
                if (isRelease)
                {
                    return;
                }
                throw new Exception(ex.Message + "\r\nIn ColumnComboBox.UpdateIndex().");
            }
        }

        //Useful for setting the SelectedIndex to the index of a certain string.
        public int SetToIndexOf(string sText)
        {
            try
            {
                int index = 0;
                //see if what is currently in the text box matches anything in the string list
                for (index = 0; index < m_slSuggestions.Count; index++)
                {
                    string sTemp = m_slSuggestions[index].ToUpper();
                    if (sTemp == sText)
                        break;
                }
                if (index >= m_slSuggestions.Count)
                {
                    index = -1;
                }
                m_iSelectedIndex = index;
                //SelectedIndex = index;
                //base.OnSelectedIndexChanged(new EventArgs());
                return index;
            }
            catch (Exception ex)
            {
                if (isRelease)
                {
                    return -1;
                }
                throw new Exception(ex.Message + "\r\nIn ColumnComboBox.SetToIndexOf(string).");
            }
        }



        #region //Properties

        //Overridden to do the set differently.
        public string DisplayColumn
        {
            get
            {
                if (String.IsNullOrEmpty(this.m_iDisplayColumn))
                {
                    return this.m_iViewColumn;
                }
                return this.m_iDisplayColumn;
            }
            set
            {
                this.m_iDisplayColumn = value;
            }
        }
        private ComboBoxFTMode dataMode = ComboBoxFTMode.Null;

        public ComboBoxFTMode DataMode
        {
            get
            {
                return dataMode;
            }
            set
            {
                dataMode = value;
            }
        }

        public int TopNumber
        {
            get
            {
                if (this._topNumber == 0)
                {
                    return 10;
                }
                return this._topNumber;
            }
            set
            {
                this._topNumber = value;
            }
        }
        public override string Text
        {
            get
            {
                //if (this.Data.Rows.Count > 0)
                //{
                    return base.Text;
                //}
                //else
                //{
                //    return string.Empty;
                //}
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                }

            }
        }

        //Override the Selecte dindex to use the internal version.
        public override int SelectedIndex
        {
            get
            {
                return m_iSelectedIndex;
            }
            set
            {
                m_iSelectedIndex = value;
                base.SelectedIndex = value;
                base.OnSelectedIndexChanged(new EventArgs());
            }
        }

        //Property for getting and setting the DataTable that will be displayed in columns.
        //May be useful for getting the DataView used for displaying items
        public new DataView Items
        {
            get
            {
                return m_dvView;
            }
        }

        //Access to the Columns so they can be hidden or shown or have widths set etc.
        public CCBColumnCollection Columns
        {
            get
            {
                if (m_bInitItems)
                    InitItems();
                if (m_bInitDisplay)
                    InitDisplay();
                //if (m_bInitNewColumn)
                //{
                //    GetNewColumnWidth();
                //}
                return m_Cols;
            }
        }

        //Convenient for resorting the ComboBox based on a column.
        public void SortBy(string sCol, SortOrder so)
        {
            m_dvView.Sort = sCol + " " + so.ToString();
            m_bInitItems = true;
        }

        //This is the column that will be displayed in the Text of the ComboBox and will also be used
        //for "suggesting" functionality.
        public string ViewColumn
        {
            get
            {
                return m_iViewColumn;
            }
            set
            {
                //if(String.IsNullOrEmpty(value))
                //    throw new Exception("ViewColumn must be greater than zero\r\n(set)ColumnComboBox.ViewColumn");
                if (this.orderBy.Count == 0)
                {
                    Dictionary<object, object> d = new Dictionary<object, object>();
                    d.Add(value, "ASC");
                    this._dbCreater.SetOrderBy(d);
                }
                m_iViewColumn = value;
                m_bInitItems = true;
                m_bInitDisplay = true;
                m_bInitSuggestionList = true;
            }
        }

        //Does nothing... yet
        public new bool Sorted
        {
            get
            {
                return false;
            }
        }
        public DataTable Data
        {
            get
            {
                return m_dtData;
            }
            set
            {
                if (value == null)
                    throw new Exception("Data cannot be set to null.\r\n ColumnComboBox.Data (set)");
                m_dtData = value;
                //this.SelectedIndex = -1;
                m_dvView = new DataView(m_dtData);
                m_bInitItems = true;
                m_bInitSuggestionList = true;
                //Invalidate();
            }
        }
        //Indexer for retriving values based on the column string.
        //Will return the value of the given column at SelectedIndex row.
        //You may want to add an int indexer as well.
        public object this[int sCol]
        {
            get
            {
                try
                {
                    if (m_iSelectedIndex < 0)
                        return null;
                    object o = Data.Rows[m_iSelectedIndex][sCol];
                    return o;
                }
                catch (Exception ex)
                {
                    if (isRelease)
                    {
                        return null;
                    }
                    throw new Exception(ex.Message + "\r\nIn ColumnComboBox[string](get).");
                }
            }
            set
            {
                try
                {
                    Data.Rows[SelectedIndex][sCol] = value;
                }
                catch (Exception ex)
                {
                    if (isRelease)
                    {
                        return;
                    }
                    throw new Exception(ex.Message + "\r\nIn ColumnComboBox[string](set).");
                }
            }
        }
        public object this[string sCol]
        {
            get
            {
                try
                {
                    if (m_iSelectedIndex < 0)
                        return null;
                    object o = Data.Rows[m_iSelectedIndex][sCol];
                    return o;
                }
                catch (Exception ex)
                {
                    if (isRelease)
                    {
                        return null;
                    }
                    throw new Exception(ex.Message + "\r\nIn ColumnComboBox[string](get).");
                }
            }
            set
            {
                try
                {
                    Data.Rows[SelectedIndex][sCol] = value;
                }
                catch (Exception ex)
                {
                    if (isRelease)
                    {
                        return;
                    }
                    throw new Exception(ex.Message + "\r\nIn ColumnComboBox[string](set).");
                }
            }
        }
        #endregion

        //Event for changing which columns are displayed.
        private void ColumnComboBox_OnColumnDisplayChanged(object sender, CCBColumnEventArgs e)
        {
            //Set the flag to re-init the display before next dropdown event
            m_bInitDisplay = true;
        }



        //void ComboBoxFT_Resize(object sender, EventArgs e)
        //{
        //    SetPosition();
        //}

        //设置"*"Lable 的位置
        public void SetLabelPosition(Control parentCtrl)
        {
            if (ShowLabel)
            {
                lb = new Label
                {
                    Text = this._lbText,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent,
                    ForeColor = Color.Red

                };

                lb.SetBounds(this.Left + this.Width, this.Top + 5, 10, 15);
                parentCtrl.Controls.Add(lb);
            }
            else
            {
                if (parentCtrl.Controls.Contains(lb))
                {
                    parentCtrl.Controls.Remove(lb);
                }
                lb = null;
            }
        }

        //private void SetPosition()
        //{
        //    if (lb != null)
        //    {
        //        this.lb.Left = this.Left + this.Width + 3;
        //    }
        //}

        public void SizeChange(object sender, System.EventArgs e)
        {
            if (this.Width != Env_Const.tbWidth)
            {
                if (lb != null)
                {
                    this.lb.Left = this.Left + this.Width + 3;
                }

            }
        }
    }
    #region Supporting classes and enum
    public enum SortOrder
    {
        DESC,
        ASC
    }

    public class CCBColumnEventArgs : EventArgs
    {
        public CCBColumn Column;
        public CCBColumnEventArgs(CCBColumn col)
        {
            Column = col;
        }
    }
    public delegate void ChangeColumnDisplayHandler(object sender, CCBColumnEventArgs e);
    public class CCBColumn
    {
        private string m_sName;
        //public object Value;
        public int Width = -1;
        private bool m_Display = true;
        public int CalculatedWidth = 0;

        public event ChangeColumnDisplayHandler OnColumnDisplayChanged;

        public CCBColumn(string sName)
        {
            m_sName = sName;
        }
        public CCBColumn(string sName, int iWidth)
        {
            m_sName = sName;
            Width = iWidth;
        }
        public CCBColumn(string sName, bool bDisplay)
        {
            m_sName = sName;
            Display = bDisplay;
        }

        #region //Properties
        public string Name
        {
            get
            {
                return m_sName;
            }
            set
            {
                if (m_sName != value)
                {
                    m_sName = value;
                    if (OnColumnDisplayChanged != null)
                        OnColumnDisplayChanged(this, new CCBColumnEventArgs(this));
                }
            }
        }

        public bool Display
        {
            get
            {
                return m_Display;
            }
            set
            {
                if (m_Display != value)
                {
                    m_Display = value;
                    if (OnColumnDisplayChanged != null)
                        OnColumnDisplayChanged(this, new CCBColumnEventArgs(this));
                }
            }
        }
        private int displayOrder = 0;
        public int DisplayOrder 
        {
            get 
            {
                if (displayOrder ==0)
                {
                    return 999;
                }
                return displayOrder;
            }

            set
            {
                displayOrder = value;
                
            }
        }
        #endregion
    }
    public class CCBColumnCollectionEventArgs : EventArgs
    {
        public int Count;
        public CCBColumn DO;
        public CCBColumnCollectionEventArgs(int count, CCBColumn dO)
        {
            Count = count;
            DO = dO;
        }
    }
    public delegate void AddCCBColumnHandler(object sender, CCBColumnCollectionEventArgs e);
    public delegate void RemoveCCBColumnHandler(object sender, CCBColumnCollectionEventArgs e);
    //CCBColumn collection is similar to an ArrayList but deals only with CCBColumns.
    //Sure would be nice to have class templates for classes like this one.
    public class CCBColumnCollection : IEnumerator, IEnumerable
    {
        CCBColumn[] m_DOA = new CCBColumn[16];
        int m_iSize = 16;
        int m_iCount = 0;
        int m_iEnumeratorPos;
        bool m_bFireEvents = true;
        public event AddCCBColumnHandler AddColumnEvent;
        public event RemoveCCBColumnHandler RemoveColumnEvent;

        public CCBColumnCollection()
        {
        }
        public void ItemAdded(object sender, CCBColumnCollectionEventArgs e)
        {
        }
        private void CheckGrow()
        {
            if (m_iCount >= m_iSize)
            {
                m_iSize *= 2;
                CCBColumn[] doTemp = new CCBColumn[m_iSize];
                m_DOA.CopyTo(doTemp, 0);
                m_DOA = doTemp;
            }
        }
        public void Add(CCBColumn DO)
        {
            if (Contains(DO))
                throw new Exception("Column collection already contains a column named \"" + DO.Name + "\"");
            CheckGrow();
            m_DOA[m_iCount] = DO;
            m_iCount++;
            if (AddColumnEvent != null && m_bFireEvents)
            {
                CCBColumnCollectionEventArgs args = new CCBColumnCollectionEventArgs(m_iCount, DO);
                AddColumnEvent(this, args);
            }
        }
        public bool Contains(CCBColumn DO)
        {
            for (int index = 0; index < Count; index++)
            {
                if (m_DOA[index].Name == DO.Name)
                    return true;
            }
            return false;
        }
        public bool AddNoDuplicate(CCBColumn DO)
        {
            bool bRHS = true;
            if (Contains(DO))
            {
                Remove(DO);
                bRHS = false;
            }
            Add(DO);
            return bRHS;
        }
        public void Insert(CCBColumn DO, int iPos)
        {
            CheckGrow();
            if (iPos < 0)
                Insert(DO, 0);
            if (iPos >= m_iCount && iPos != 0)
                Insert(DO, m_iCount - 1);
            CCBColumn[] doTemp = new CCBColumn[m_iSize];
            int index = 0;
            for (; index < iPos; index++)
            {
                doTemp[index] = m_DOA[index];
            }
            doTemp[index] = DO;
            for (; index < m_iCount; index++)
            {
                doTemp[index + 1] = m_DOA[index];
            }
            m_DOA = doTemp;
            m_iCount++;
        }
        public void Remove(CCBColumn DO)
        {

            int index = 0;
            for (; index < m_iCount; index++)
            {
                if (m_DOA[index].Name == DO.Name)
                    break;
            }
            if (index == m_iCount)
                return;
            for (; index < m_iCount - 1; index++)
            {
                m_DOA[index] = m_DOA[index + 1];
            }
            m_iCount--;
            Remove(DO);
            if (RemoveColumnEvent != null && m_bFireEvents)
            {
                CCBColumnCollectionEventArgs args = new CCBColumnCollectionEventArgs(m_iCount, DO);
                RemoveColumnEvent(this, args);
            }
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= m_iCount)
                return;
            for (; index < m_iCount - 1; index++)
            {
                m_DOA[index] = m_DOA[index + 1];
            }
            m_iCount--;
        }
        public void MoveToFront(CCBColumn DO)
        {
            m_bFireEvents = false;
            Remove(DO);
            Insert(DO, 0);
            m_bFireEvents = true;
        }
        public void Clear()
        {
            m_iSize = 16;
            m_iCount = 0;
            m_DOA = new CCBColumn[m_iSize];
        }
        #region //Properties
        public int Count
        {
            get
            {
                return m_iCount;
            }
        }

        public CCBColumn this[int index]
        {
            get
            {
                return m_DOA[index];
            }
        }

        public CCBColumn this[string sName]
        {
            get
            {
                for (int index = 0; index < m_iCount; index++)
                {
                    if (m_DOA[index].Name == sName)
                        return m_DOA[index];
                }
                throw new Exception("Column \"" + sName + "\" is not a valid column.Or You should Set The DataMode First!");
            }
        }
        #endregion
        #region IEnumerator Members

        public IEnumerator GetEnumerator()
        {
            m_iEnumeratorPos = -1;
            return (IEnumerator)this;
        }
        public void Reset()
        {
            m_iEnumeratorPos = -1;
        }

        public object Current
        {
            get
            {
                return m_DOA[m_iEnumeratorPos];
            }
        }

        public bool MoveNext()
        {
            if (m_iEnumeratorPos >= m_iCount - 1)
                return false;
            else
            {
                m_iEnumeratorPos++;
                return true;
            }
        }

        #endregion
    }
    #endregion
}
