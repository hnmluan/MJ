using System;
public class BtnUseItem : BaseButton
{
    public Action Click;
    protected override void OnClick() => Click?.Invoke();
}
