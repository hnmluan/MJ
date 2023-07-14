using UnityEngine;

public class PlayerConverse : PlayerAbstract
{
    [SerializeField] protected LayerMask converseLayer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

}
