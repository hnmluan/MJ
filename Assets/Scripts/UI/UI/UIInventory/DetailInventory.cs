using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class DetailInventory : InitMonoBehaviour
{
    [SerializeField] protected ItemInventory itemInventory = null;

    [SerializeField] protected Image itemImage;

    [SerializeField] protected Text itemName;

    [SerializeField] protected Text itemType;

    [SerializeField] protected Text itemDescription;

    [SerializeField] protected Text itemQuantity;

    [SerializeField] protected Transform options;

    [SerializeField] protected SelectOption optionPrefab;

    protected override void OnDisable() => this.ClearBox();

    public virtual void SetBox(ItemInventory item)
    {
        this.itemInventory = item;

        itemImage.sprite = item.itemProfile.itemSprite;
        itemQuantity.text = item.itemCount.ToString();
        itemName.text = LocalizationManager.Localize(item.itemProfile.keyName);
        itemDescription.text = LocalizationManager.Localize(item.itemProfile.keyDescription);
        itemType.text = LocalizationManager.Localize("Item.Type." + item.itemProfile.itemType.ToString());

        ShowOptions();
    }

    public virtual void ClearBox()
    {
        this.itemInventory = null;
        itemImage.sprite = null;
        itemDescription.text = null;
        itemName.text = null;
        itemQuantity.text = null;
        itemType.text = null;
        ClearOptions();
    }

    private void ShowOptions()
    {
        ClearOptions();
        foreach (ItemActionData itemActionData in itemInventory.itemProfile.actionItemDatas)
        {
            SelectOption selectOption = GetSelectOptionInactive();
            selectOption.transform.localScale = Vector3.one;
            selectOption.ShowOption(itemActionData.KeyActionLocalization, itemActionData.Action);
            Debug.Log("Key : " + itemActionData.KeyActionLocalization);
        }
    }

    protected void ClearOptions()
    {
        foreach (Transform child in options)
        {
            child.gameObject.SetActive(false);
        }
    }

    protected SelectOption GetSelectOptionInactive()
    {
        foreach (Transform child in options)
        {
            if (child.gameObject.activeSelf == false)
            {
                child.gameObject.SetActive(true);
                return child.GetComponent<SelectOption>();
            }
        }

        SelectOption option = Instantiate(optionPrefab, options);
        option.gameObject.SetActive(true);
        option.transform.localScale = Vector3.one;

        return option;
    }
}
