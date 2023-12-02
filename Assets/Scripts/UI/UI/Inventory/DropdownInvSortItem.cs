public class DropdownInvSortItem : BaseDropdown
{
    protected override void OnChanged(int option)
    {
        switch (option)
        {
            case 0:
                UIInventory.Instance.SetInventorySort(InventorySort.Name);

                break;
            case 1:
                UIInventory.Instance.SetInventorySort(InventorySort.Quantity);
                break;
        }

    }
}