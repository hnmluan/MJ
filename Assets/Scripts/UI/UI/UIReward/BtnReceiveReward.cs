public class BtnReceiveReward : BaseButton
{
    protected override void OnClick() => UIReward.Instance.Close();
}
