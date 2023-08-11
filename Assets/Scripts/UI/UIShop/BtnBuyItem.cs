using UnityEngine;

public class BtnBuyItem : BaseButton
{
    [SerializeField] protected UIItemShop uiItemShop;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIItemShop();
    }

    private void LoadUIItemShop()
    {
        this.uiItemShop = transform.parent.GetComponent<UIItemShop>();
        Debug.Log(transform.name + ": LoadUIItemShop", gameObject);
    }

    protected override void OnEnable() => LoadUIItemShop();

    protected override void OnClick()
    {
        if (uiItemShop == null) return;
        PlayerCtrl.Instance.Inventory.AddItem(uiItemShop.ItemShop.itemProfile.itemCode, uiItemShop.ItemShop.quantity);
        uiItemShop.SoldOut.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

    }
}
