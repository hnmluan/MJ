public class BtnInvUseAll : BaseButton
{
    protected override void OnClick() => Inventory.Instance.OpenAllTreasure(UIInventory.Instance.CurrentItem);
}
