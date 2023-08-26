public class ItemModel : ItemAbstract
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        itemCtrl.ItemSR.sprite = itemCtrl.ItemInventory.itemProfile.itemSprite;
    }
}
