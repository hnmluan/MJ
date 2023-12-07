using UnityEngine;
using UnityEngine.UI;

public class UIRecipeUpgrade : InitMonoBehaviour
{
    [SerializeField] protected Image image;
    public Image Image => image;

    [SerializeField] protected Text quantity;
    public Text Quantity => quantity;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
        this.LoadQuantity();
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = transform.Find("Image").Find("Image").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadContent", gameObject);
    }

    protected virtual void LoadQuantity()
    {
        if (this.quantity != null) return;
        this.quantity = transform.Find("Quantity").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadContent", gameObject);
    }

    public virtual void Show(WeaponRecipeIngredient weaponRecipeIngredient)
    {
        if (weaponRecipeIngredient == null) return;

        this.image.sprite = weaponRecipeIngredient.itemProfile.itemSprite;

        this.quantity.text = weaponRecipeIngredient.itemCount + "/" + Inventory.Instance.GetItemCount(weaponRecipeIngredient.itemProfile);

        if (weaponRecipeIngredient.isAvailable()) quantity.color = new Color(23f / 255f, 119f / 255f, 37f / 255f, 1f); else quantity.color = Color.red;
    }

    public virtual void Show(WeaponRecipePrice weaponRecipePrice)
    {
        if (weaponRecipePrice == null) return;

        this.image.sprite = weaponRecipePrice.data.currencySprite;

        int balance = weaponRecipePrice.data.currencyCode == CurrencyCode.Silver ? Wallet.Instance.SilverBalance : Wallet.Instance.GoldenBalance;

        this.quantity.text = weaponRecipePrice.quantity + "/" + balance;

        if (weaponRecipePrice.isAvailable()) quantity.color = new Color(23f / 255f, 119f / 255f, 37f / 255f, 1f); else quantity.color = Color.red;
    }
}
