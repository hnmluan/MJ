using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : InitMonoBehaviour
{
    [SerializeField] protected Slider HPBar;

    [SerializeField] protected PlayerDamageReceiver damageReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHPBar();
        this.LoadDamageReceiver();
    }

    private void Update()
    {
        if (!damageReceiver || !HPBar) return;
        HPBar.value = damageReceiver.HP / damageReceiver.HPMax;
    }

    private void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        damageReceiver = transform.parent.GetComponentInChildren<PlayerDamageReceiver>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }

    private void LoadHPBar()
    {
        if (this.HPBar != null) return;
        HPBar = GetComponentInChildren<Slider>();
        Debug.Log(transform.name + ": LoadHPBar", gameObject);
    }
}
