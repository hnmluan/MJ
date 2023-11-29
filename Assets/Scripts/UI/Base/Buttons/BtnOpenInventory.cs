public class BtnOpenInventory : BaseButton
{
    protected override void OnClick() => UIInventory.Instance.Open();

    private void Update()
    {
        if (InputManager.Instance.OpenInventory()) OnClick();
    }
}
