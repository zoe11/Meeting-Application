using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using FT_ControlsUtils;

namespace FTComponentSet
{
    public partial class ComboBoxTree : UserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private Container components = null;

        public delegate void EventHandle(TriStateTreeNode n);
        public event EventHandle AfterSelectedNode;
       
        private bool _allowSelectParentNode = false;

        public ComboBoxTree()
        {
            this.InitializeComponent();

            // Initializing Controls
            this.pnlBack = new PanelFT();
            this.pnlBack.BorderStyle = BorderStyle.Fixed3D;
            this.pnlBack.BackColor = Color.White;
            this.pnlBack.AutoScroll = false;

            this.tbSelectedValue = new TextBoxFT();
            this.tbSelectedValue.BorderStyle = BorderStyle.None;
            this.tbSelectedValue.ReadOnlyChanged += new EventHandler(tbSelectedValue_ReadOnlyChanged);

            this.btnSelect = new ButtonEx();
            this.btnSelect.Click += new EventHandler(ToggleTreeView);
            this.btnSelect.FlatStyle = FlatStyle.Flat;

            this.lblSizingGrip = new LabelEx();
            this.lblSizingGrip.Size = new Size(9, 9);
            this.lblSizingGrip.BackColor = Color.Transparent;
            this.lblSizingGrip.Cursor = Cursors.SizeNWSE;
            this.lblSizingGrip.MouseMove += new MouseEventHandler(SizingGripMouseMove);
            this.lblSizingGrip.MouseDown += new MouseEventHandler(SizingGripMouseDown);

            this.tvTreeView = new TriStateTreeView();
            this.tvTreeView.BorderStyle = BorderStyle.None;
            //this.AfterSelectedNode += new EventHandle(ComboBoxTree_AfterSelectedNode);
            this.tvTreeView.DoubleClick += new EventHandler(tvTreeView_DoubleClick);
            this.tvTreeView.Location = new Point(0, 0);
            this.tvTreeView.LostFocus += new EventHandler(TreeViewLostFocus);
            //this.tvTreeView.Scrollable = false;

            this.frmTreeView = new FTForm();
            this.frmTreeView.FormBorderStyle = FormBorderStyle.None;
            this.frmTreeView.BringToFront();
            this.frmTreeView.StartPosition = FormStartPosition.Manual;
            this.frmTreeView.ShowInTaskbar = false;
            this.frmTreeView.BackColor = SystemColors.Control;
            this.frmTreeView.Controls.Add(tvTreeView);

            this.pnlTree = new PanelFT();
            this.pnlTree.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTree.BackColor = Color.White;

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            // Adding Controls to UserControl
            this.pnlTree.Controls.Add(this.lblSizingGrip);
            this.pnlTree.Controls.Add(this.tvTreeView);
            this.frmTreeView.Controls.Add(this.pnlTree);
            this.pnlBack.Controls.AddRange(new Control[] { btnSelect, tbSelectedValue });
            this.Controls.Add(this.pnlBack);

            //this.tvTreeView.DoubleClick += new EventHandler(TreeView_DoubleClick);
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要使用代码编辑器 
        /// 修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ComboBoxTree
            // 
            this.Name = "ComboTree";
            //   this._absoluteChildrenSelectableOnly = true;
            this.Layout += new LayoutEventHandler(this.ComboBoxTree_Layout);


        }

        #endregion

        #region Private 属性
        private PanelFT pnlBack;
        private PanelFT pnlTree;
        private TextBoxFT tbSelectedValue;
        private ButtonEx btnSelect;
        private TriStateTreeView tvTreeView;
        private LabelEx lblSizingGrip;
        private FTForm frmTreeView;

        //  private string _branchSeparator;
        //  private bool _absoluteChildrenSelectableOnly;
        private Point DragOffset;
        #endregion

        #region Public 属性
        public object SelectedObj { get; set; }
        /// <summary>
        /// 是否允许选择非叶子节点
        /// </summary>
        public bool AllowSelectParentNode
        {
            set
            {
                _allowSelectParentNode = value;
            }
            get
            {
                return _allowSelectParentNode;
            }
        }

        public Color TextForeColor
        {
            set { this.tbSelectedValue.ForeColor = value; }
        }

        public Color TextBackColor
        {
            set { this.tbSelectedValue.BackColor = value; }
        }

        /// <summary>
        /// 文本只读属性
        /// </summary>
        public bool TextReadOnly
        {
            set { this.tbSelectedValue.ReadOnly = value; }
        }

        /// <summary>
        /// 树节点集合
        /// </summary>
        public TreeNodeCollection Nodes
        {
            get
            {
                return this.tvTreeView.Nodes;
            }
        }

        /// <summary>
        /// 选中的节点
        /// </summary>
        /// 
        public TriStateTreeView TreeView
        {
            get
            {
                return this.tvTreeView;
            }
        }
        public TriStateTreeNode SelectedNode
        {
            set
            {
                this.tvTreeView.SelectedNode = value;
            }
            get
            {
                return (TriStateTreeNode)this.tvTreeView.SelectedNode;
            }
        }

        /// <summary>
        /// ImageList
        /// </summary>
        public ImageList Imagelist
        {
            get { return this.tvTreeView.ImageList; }
            set { this.tvTreeView.ImageList = value; }
        }

        /// <summary>
        /// 显示选中的值
        /// </summary>
        public override string Text
        {
            get { return this.tbSelectedValue.Text; }
            set { this.tbSelectedValue.Text = value; }
        }

        //  /// <summary>
        //  /// 显示完整树节点路径时，路经的分隔符（1位字符）
        //  /// </summary>
        //  public string BranchSeparator
        //  {
        //   get {return this._branchSeparator;}
        //   set
        //   {
        //    if(value.Length > 0)
        //     this._branchSeparator = value.Substring(0,1);
        //   }
        //  }
        //
        //  /// <summary>
        //  /// 是否是叶子节点
        //  /// </summary>
        //  public bool AbsoluteChildrenSelectableOnly
        //  {
        //   get {return this._absoluteChildrenSelectableOnly;}
        //   set {this._absoluteChildrenSelectableOnly = value;}
        //  }
        #endregion

        /// <summary>
        /// 拖动树背景，改变背景大小
        /// </summary>
        private void RelocateGrip()
        {
            this.lblSizingGrip.Top = this.frmTreeView.Height - lblSizingGrip.Height - 1;
            this.lblSizingGrip.Left = this.frmTreeView.Width - lblSizingGrip.Width - 1;
        }

        /// <summary>
        /// 点击三角按钮，显示树Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleTreeView(object sender, EventArgs e)
        {
            if (!this.frmTreeView.Visible)
            {
                Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
                this.frmTreeView.Location = new Point(CBRect.X, CBRect.Y + this.pnlBack.Height);
                this.tvTreeView.Nodes[0].Expand();
                this.tvTreeView.DoubleClick += new EventHandler(tvTreeView_DoubleClick);
                this.frmTreeView.Show();

                //this.frmTreeView.BringToFront();

                //this.RelocateGrip();
                //this.tbSelectedValue.Text = "";
            }
            else
            {
                this.frmTreeView.Hide();
            }
        }

        void tvTreeView_DoubleClick(object sender, EventArgs e)
        {
            if (this.TreeView.SelectedNode != null)
            {
                this.SelectedObj = ((TriStateTreeNode)this.TreeView.SelectedNode).Obj;
            }
            TreeViewNodeSelect(sender,e);
        }

        /// <summary>
        /// 验证选中的是否是叶子节点
        /// </summary>
        /// <returns></returns>
        //  public bool ValidateText()
        //  {
        //   string ValidatorText = this.Text;
        //   TreeNodeCollection TNC = this.tvTreeView.Nodes;
        //
        //   for(int i = 0; i < ValidatorText.Split(this._branchSeparator.ToCharArray()[0]).Length; i++)
        //   {
        //    bool NodeFound = false;
        //    string NodeToFind = ValidatorText.Split(this._branchSeparator.ToCharArray()[0])[i];
        //    for(int j = 0; j < TNC.Count; j++)
        //    {
        //     if(TNC[j].Text == NodeToFind)
        //     {
        //      NodeFound = true;
        //      TNC = TNC[j].Nodes;
        //      break;
        //     }
        //    }
        //
        //    if(!NodeFound)
        //     return false;
        //   }
        //
        //   return true;
        //  }

        #region 事件
        /// <summary>
        /// 改变背景大小，在鼠标移动时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizingGripMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int TvWidth, TvHeight;
                TvWidth = Cursor.Position.X - this.frmTreeView.Location.X;
                TvWidth = TvWidth + this.DragOffset.X;
                TvHeight = Cursor.Position.Y - this.frmTreeView.Location.Y;
                TvHeight = TvHeight + this.DragOffset.Y;

                if (TvWidth < 50)
                    TvWidth = 50;
                if (TvHeight < 50)
                    TvHeight = 50;

                this.frmTreeView.Size = new Size(TvWidth, TvHeight);
                this.pnlTree.Size = this.frmTreeView.Size;
                this.tvTreeView.Size = new Size(this.frmTreeView.Size.Width - this.lblSizingGrip.Width, this.frmTreeView.Size.Height - this.lblSizingGrip.Width); ;
                RelocateGrip();
            }
        }

        /// <summary>
        /// 改变背景大小，在按下鼠标时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizingGripMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int OffsetX = Math.Abs(Cursor.Position.X - this.frmTreeView.RectangleToScreen(this.frmTreeView.ClientRectangle).Right);
                int OffsetY = Math.Abs(Cursor.Position.Y - this.frmTreeView.RectangleToScreen(this.frmTreeView.ClientRectangle).Bottom);

                this.DragOffset = new Point(OffsetX, OffsetY);
            }
        }

        /// <summary>
        /// 树型控件失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewLostFocus(object sender, EventArgs e)
        {
            if (!this.btnSelect.RectangleToScreen(this.btnSelect.ClientRectangle).Contains(Cursor.Position))
                this.frmTreeView.Hide();
        }

        /// <summary>
        /// 选中树型空间节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewNodeSelect(object sender, EventArgs e)
        {
            if (this._allowSelectParentNode && this.tvTreeView.SelectedNode != this.tvTreeView.Nodes[0])
            {
                this.tbSelectedValue.Text = this.tvTreeView.SelectedNode.Text;

                this.ToggleTreeView(sender, null);

                if (AfterSelectedNode != null)
                {
                    AfterSelectedNode((TriStateTreeNode)this.tvTreeView.SelectedNode);
                }
                //
            }
            else
            {
                if (this.tvTreeView.SelectedNode.Nodes.Count == 0)
                {
                    this.tbSelectedValue.Text = this.tvTreeView.SelectedNode.Text;

                    this.ToggleTreeView(sender, null);
                    if (AfterSelectedNode != null)
                    {
                        AfterSelectedNode((TriStateTreeNode)this.tvTreeView.SelectedNode);
                    }
                    //AfterSelectedNode((TriStateTreeNode)this.tvTreeView.SelectedNode);
                }
            }
        }

        private void ComboBoxTree_Layout(object sender, LayoutEventArgs e)
        {
            this.Height = this.tbSelectedValue.Height + 8;
            this.pnlBack.Size = new Size(this.Width, this.Height - 2);

            this.btnSelect.Size = new Size(16, this.Height - 6);
            this.btnSelect.Location = new Point(this.Width - this.btnSelect.Width - 4, 0);

            this.tbSelectedValue.Location = new Point(2, 2);
            this.tbSelectedValue.Width = this.Width - this.btnSelect.Width - 4;
            this.frmTreeView.Size = new Size(this.Width + 60, 250);
            this.pnlTree.Size = this.frmTreeView.Size;
            this.tvTreeView.Width = this.frmTreeView.Width - this.lblSizingGrip.Width;
            this.tvTreeView.Height = this.frmTreeView.Height - this.lblSizingGrip.Width;
            this.RelocateGrip();
        }

        /// <summary>
        /// 文本只读事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSelectedValue_ReadOnlyChanged(object sender, EventArgs e)
        {
            if (this.tbSelectedValue.ReadOnly)
            {
                this.tbSelectedValue.BackColor = Color.White;
            }
        }
        #endregion

        #region 树型背景Label
        private class LabelEx : Label
        {
            /// <summary>
            /// 
            /// </summary>
            public LabelEx()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                ControlPaint.DrawSizeGrip(e.Graphics, Color.Black, 1, 0, this.Size.Width, this.Size.Height);
            }
        }
        #endregion

        #region 三角形按钮
        private class ButtonEx : Button
        {
            ButtonState state;

            /// <summary>
            /// 
            /// </summary>
            public ButtonEx()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnMouseDown(MouseEventArgs e)
            {
                state = ButtonState.Pushed;
                base.OnMouseDown(e);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnMouseUp(MouseEventArgs e)
            {
                state = ButtonState.Normal;
                base.OnMouseUp(e);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                ControlPaint.DrawComboButton(e.Graphics, 0, 0, this.Width, this.Height, state);
            }
        }
        #endregion
    }
}
