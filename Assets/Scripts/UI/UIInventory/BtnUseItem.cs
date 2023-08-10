using System;
public class BtnUseItem : BaseButton
{
    protected override void Start()
    {
        base.Start();
        Click += () => { UIInventoryIn4.Instance.ClickUseItem(); };
    }

    public Action Click;
    protected override void OnClick() => Click?.Invoke();
}
