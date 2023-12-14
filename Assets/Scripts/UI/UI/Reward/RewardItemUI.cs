using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class RewardItemUI : InitMonoBehaviour
{
    [SerializeField] protected Image itemImage;
    public Image ItemImage => itemImage;

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Text itemQuantity;
    public Text ItemQuantity => itemQuantity;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemImage();
        this.LoadItemName();
        this.LoadItemQuantity();
    }

    private void LoadItemImage()
    {
        if (this.itemImage != null) return;
        this.itemImage = transform.Find("Image").Find("Image").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadItemImage", gameObject);
    }

    private void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("NameBox").Find("Name").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponName", gameObject);
    }

    private void LoadItemQuantity()
    {
        if (this.itemQuantity != null) return;
        this.itemQuantity = transform.Find("QuantityBox").Find("Quantity").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponName", gameObject);
    }

    public void ShowItem(ItemCode itemCode, int quantity)
    {
        ItemDataSO itemDataSO = ItemDataSO.FindByCode(itemCode);
        if (itemDataSO == null) return;

        itemName.text = LocalizationManager.Localize(itemDataSO.keyName);
        itemQuantity.text = "x" + quantity;
        itemImage.sprite = itemDataSO.itemSprite;
    }

    public void ShowWeapon(WeaponCode weaponCode, int level)
    {
        WeaponDataSO dataSO = WeaponDataSO.FindByCode(weaponCode);
        if (dataSO == null) return;

        itemName.text = LocalizationManager.Localize(dataSO.keyName);
        itemQuantity.text = "+" + level;
        itemImage.sprite = dataSO.spriteInHand;
    }
}
