public class DropdownArmorySort : BaseDropdown
{
    protected override void OnChanged(int option)
    {
        switch (option)
        {
            case 0:
                UIArmory.Instance.SetArmorySort(ArmorySort.ByName);

                break;
            case 1:
                UIArmory.Instance.SetArmorySort(ArmorySort.ByLevel);
                break;
        }

    }
}
