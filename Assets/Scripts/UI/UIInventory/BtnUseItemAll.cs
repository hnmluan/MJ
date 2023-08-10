using System;

public class BtnUseItemAll : BaseButton
{

    protected override void Start()
    {
        base.Start();
        Click += () => { UIInventoryIn4.Instance.ClickUseItemAll(); };
    }

    public Action Click;

    protected override void OnClick() => Click?.Invoke();
}
