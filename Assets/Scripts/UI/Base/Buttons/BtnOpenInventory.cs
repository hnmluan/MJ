public class BtnOpenInventory : BaseButton
{
    protected override void OnClick() => UIInventory.Ins.Toggle();

    private void Update()
    {
        if (InputManager.Instance.OpenInventory()) OnClick();
    }
}
