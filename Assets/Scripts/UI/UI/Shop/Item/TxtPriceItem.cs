using UnityEngine;

public class TxtPriceItem : BaseText
{
    [SerializeField] protected UIItemShop uiItemShop;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIItemShop();
    }

    private void LoadUIItemShop()
    {
        this.uiItemShop = transform.parent.parent.GetComponent<UIItemShop>();
        Debug.Log(transform.name + ": LoadUIItemShop", gameObject);
    }

    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText()
    {
        try
        {
            if (uiItemShop == null) { text.text = ""; }
            text.text = "x" + uiItemShop.ItemShop.price.ToString();
        }
        catch (System.Exception)
        {
            text.text = "";
        }
    }
}
