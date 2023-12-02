using UnityEngine;
using UnityEngine.UI;

public class UIRecipeUpgradeLevel : InitMonoBehaviour
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

    public virtual void ShowUIRecipeUpdateLevel(WeaponRecipeIngredient weaponRecipeIngredient)
    {
        if (weaponRecipeIngredient == null) return;
        this.image.sprite = weaponRecipeIngredient.itemProfile.itemSprite;
        this.quantity.text =
            weaponRecipeIngredient.itemCount.ToString()
            + "/"
            + Inventory.Instance.GetQuantity(weaponRecipeIngredient.itemProfile.itemCode).ToString();
    }

    public virtual void ShowUIRecipeUpdateLevel(WeaponRecipePrice weaponRecipePrice)
    {
        if (weaponRecipePrice == null) return;
        this.image.sprite = weaponRecipePrice.currencyProfile.currencySprite;

        int balance =
            weaponRecipePrice.currencyProfile.currencyCode == CurrencyCode.Silver ?
            Wallet.Instance.SilverBalance :
            Wallet.Instance.GoldenBalance;

        this.quantity.text =
            weaponRecipePrice.currencyCout.ToString()
            + "/"
            + balance.ToString();
    }
}
