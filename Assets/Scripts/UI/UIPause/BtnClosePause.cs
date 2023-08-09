public class BtnClosePause : BaseButton
{
    protected override void OnClick() => UIPause.Instance.Close();
}
