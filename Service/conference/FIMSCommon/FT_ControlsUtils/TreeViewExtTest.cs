
namespace FT_ControlsUtils
{
    class TreeViewExtTest
    {
        public void test()
        {
            TreeViewExt ext  = new TreeViewExt();
            
            //此处又有ImageList被赋值

            TreeViewExtDelegateRole dr = new TreeViewExtDelegateRole();
            ext.WorkStatus = TreeViewWorkStatus.ChoiceStatus;
            ext.RelationOwner = "";
            ext.bindDelegate(dr);
        }
    }
}
