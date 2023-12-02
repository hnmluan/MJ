public class DropdownArmorySort : BaseDropdown
{
    protected override void OnChanged(int option)
    {
        switch (option)
        {
            case 0:
                UIArmory.Instance.SetSort(ArmorySort.ByName);

                break;
            case 1:
                UIArmory.Instance.SetSort(ArmorySort.ByLevel);
                break;
        }

    }
}
