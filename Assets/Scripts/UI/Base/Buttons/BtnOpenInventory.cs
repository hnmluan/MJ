public class BtnOpenInventory : BaseButton
{
    protected override void OnClick() => UIInventory.Instance.Toggle();

    private void Update()
    {
        if (InputManager.Instance.OpenInventory()) OnClick();
    }
}
