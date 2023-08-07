using UnityEngine;

public class BtnExitGame : BaseButton
{
    protected override void OnClick()
    {
        Application.Quit();
    }
}