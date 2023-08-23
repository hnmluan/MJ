using UnityEngine;

public class ToggleFullscreen : BaseToggle
{
    protected override void OnChanged(bool option) => Screen.fullScreen = option;
}
