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

    public virtual void ShowItem(ScriptableObject item)
    {
        if (item is EnemyProfileSO) ShowEnemyProfileSO(item as EnemyProfileSO);
        if (item is NPCProfileSO) ShowNPCProfileSO(item as NPCProfileSO);
    }

    private void ShowEnemyProfileSO(EnemyProfileSO enemyProfileSO)
    {
        if (enemyProfileSO == null) return;
        itemDictionary = enemyProfileSO;
        itemName.text = enemyProfileSO.enemyName;
        itemImage.sprite = enemyProfileSO.sprite;
    }

    private void ShowNPCProfileSO(NPCProfileSO npcProfileSO)
    {
        if (npcProfileSO == null) return;
        itemDictionary = npcProfileSO;
        itemName.text = npcProfileSO.npcName;
        itemImage.sprite = npcProfileSO.sprite;
    }
}