public class BtnAgreeTask : BaseButton
{
    protected override void OnClick() => Task.Instance.AcceptTask();
}
