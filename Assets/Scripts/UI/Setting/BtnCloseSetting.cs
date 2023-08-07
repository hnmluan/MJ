public class BtnCloseSetting : BaseButton
{
    protected override void OnClick() => UISetting.Instance.Close();
}
