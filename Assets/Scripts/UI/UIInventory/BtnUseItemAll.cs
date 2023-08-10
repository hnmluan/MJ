using System;

public class BtnUseItemAll : BaseButton
{
    public Action Click;
    protected override void OnClick() => Click?.Invoke();
}
