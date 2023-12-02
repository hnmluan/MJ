public class BtnCloseTaskPanel : BaseButton
{
    protected override void OnClick() => UITaskPanel.Instance.Close();
}
