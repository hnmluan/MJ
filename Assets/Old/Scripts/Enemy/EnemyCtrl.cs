using UnityEngine;
using UnityEngine.UI;

public class EnemyCtrl : InitMonoBehaviour
{
    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn { get => enemyDespawn; }

    [SerializeField] protected SpriteRenderer enemySprite;
    public SpriteRenderer EnemySprite { get => enemySprite; }

    [SerializeField] protected Slider hpBarSprite;
    public Slider HPBarSprite { get => hpBarSprite; }

    [SerializeField] protected HealthBlink healthBlink;
    public HealthBlink HealthBlink { get => healthBlink; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyDespawn();
        this.LoadEnemySprite();
        this.LoadHPBarSprite();
        this.LoadHealthBlink();
    }

    protected override void OnEnable()
    {
        hpBarSprite.value = 1;
    }

    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemyDespawn != null) return;
        this.enemyDespawn = transform.GetComponentInChildren<EnemyDespawn>();
        Debug.Log(transform.name + ": LoadEnemyDespawn", gameObject);
    }

    protected virtual void LoadHPBarSprite()
    {
        if (this.hpBarSprite != null) return;
        this.hpBarSprite = transform.GetComponentInChildren<Slider>();
        Debug.Log(transform.name + ": LoadHPBarSprite", gameObject);
    }

    protected virtual void LoadEnemySprite()
    {
        if (this.enemySprite != null) return;
        this.enemySprite = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadEnemyDespawn", gameObject);
    }

    protected virtual void LoadHealthBlink()
    {
        if (this.healthBlink != null) return;
        this.healthBlink = transform.GetComponentInChildren<HealthBlink>();
        Debug.Log(transform.name + ": LoadHealthBlink", gameObject);
    }
}
