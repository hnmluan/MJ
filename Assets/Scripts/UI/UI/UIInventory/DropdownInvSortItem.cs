public class DropdownInvSortItem : BaseDropdown
{
    protected override void OnChanged(int option)
    {
        switch (option)
        {
            case 0:
                UIInventory.Ins.SetInventorySort(InventorySort.ByName);

                break;
            case 1:
                UIInventory.Ins.SetInventorySort(InventorySort.ByQuantity);
                break;
        }

    }
}
