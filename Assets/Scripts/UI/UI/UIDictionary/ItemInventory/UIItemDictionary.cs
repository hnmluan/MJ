using UnityEngine;
using UnityEngine.UI;

public class UIItemDictionary : InitMonoBehaviour
{
    [Header("UI Item Dictionary")]
    [SerializeField] protected ScriptableObject itemDictionary;
    public ScriptableObject ItemDictionary => itemDictionary;

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Image itemImage;
    public Image Image => itemImage;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemImage();
    }

    private void LoadItemImage()
    {
        if (this.itemImage != null) return;
        this.itemImage = transform.Find("Image").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadItemDictionarytory", gameObject);
    }

    protected virtual void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("Name").Find("Name").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    public virtual void ShowItem(EnemyProfileSO item)
    {
        if (item == null) return;
        itemDictionary = item;
        itemName.text = item.enemyName;
        itemImage.sprite = item.sprite;
    }
}