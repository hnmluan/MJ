using UnityEngine;

public class DropdownGraphics : BaseDropdown
{
    protected override void OnChanged(int option) => QualitySettings.SetQualityLevel(option);
}
