using UnityEngine;

public class BtnExitGame : BaseButton
{
    protected override void OnClick() => Application.Quit();

    private void Update()
    {
        if (InputManager.Instance.Close()) OnClick();
    }
}