public class BtnCloseInventory : BaseButton
{
    protected override void OnClick() => UIInventory.Ins.Close();
}