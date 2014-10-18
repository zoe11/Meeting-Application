using System.Windows.Forms;

namespace FT_ControlsUtils
{
    public class TreeNodeExt:TreeNode
    {
        public string ID { get; set; }
        public bool Flag { get; set; }
        public object Obj { get; set; }

        public TreeNodeExt() : base() { }
        public TreeNodeExt(string text) : base(text) { }
    }
}
