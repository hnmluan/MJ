public class SortItemDropdown : BaseDropdown
{
    protected override void OnChanged(int option)
    {
        switch (option)
        {
            case 0:
                UIInventory.Instance.SetInventorySort(InventorySort.ByName);

                break;
            case 1:
                UIInventory.Instance.SetInventorySort(InventorySort.ByQuantity);
                break;
        }

    }
}
