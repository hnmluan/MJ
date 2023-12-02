public class BtnAgreeTask : BaseButton
{
    protected override void OnClick() => UITask.Instance.Close();
}
