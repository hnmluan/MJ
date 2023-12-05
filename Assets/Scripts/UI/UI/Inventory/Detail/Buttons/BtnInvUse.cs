public class BtnInvUse : BaseButton
{
    protected override void OnClick() => Inventory.Instance.OpenTreasure(UIInventory.Instance.CurrentItem);
}
