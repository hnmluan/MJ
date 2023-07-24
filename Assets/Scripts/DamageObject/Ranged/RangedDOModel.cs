using UnityEngine;

public class RangedDOModel : RangedDOAbstract
{
    [SerializeField] protected SpriteRenderer rangedDOSprite;
    public SpriteRenderer RangedDOSprite { get => rangedDOSprite; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRangedDOSprite();
    }

    protected override void ResetValue() => rangedDOSprite.sprite = rangedDOCtrl.DamageObjectSO.spriteInAttack;

    protected virtual void LoadRangedDOSprite()
    {
        if (this.rangedDOSprite != null) return;
        this.rangedDOSprite = transform.GetComponent<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadRangedDOCtrl", gameObject);
    }
}
