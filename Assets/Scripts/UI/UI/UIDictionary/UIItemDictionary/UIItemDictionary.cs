using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class UIItemDictionary : InitMonoBehaviour, IActionDictionaryObserver
{
    [Header("UI Item Dictionary")]
    [SerializeField] protected ScriptableObject itemDictionary;
    public ScriptableObject ItemDictionary => itemDictionary;

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Image itemImage;
    public Image Image => itemImage;

    [SerializeField] protected Transform iconNewItem;
    public Transform IconNewItem => iconNewItem;

    protected override void Start() => Dictionary.Instance.AddObserver(this);

    protected override void OnEnable()
    {
        if (CheckNewItem()) iconNewItem.gameObject.SetActive(true);
        else iconNewItem.gameObject.SetActive(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemImage();
        this.LoadIonNewItem();
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

    protected virtual void LoadIonNewItem()
    {
        if (this.iconNewItem != null) return;
        this.iconNewItem = transform.Find("New");
        Debug.Log(transform.name + ": LoadIonNewItem", gameObject);
    }

    public virtual void ShowItem(ScriptableObject item)
    {
        if (item is EnemyProfileSO) ShowEnemyProfileSO(item as EnemyProfileSO);
        if (item is NPCProfileSO) ShowNPCProfileSO(item as NPCProfileSO);
        if (item is DamageObjectSO) ShowDamageObjectSO(item as DamageObjectSO);
        if (!Dictionary.Instance.CheckAvailableItemInDictonary(item)) HideItem(item);
    }

    private void HideItem(ScriptableObject item)
    {
        if (item is EnemyProfileSO) itemName.text = LocalizationManager.Localize((item as EnemyProfileSO).keyName);
        if (item is NPCProfileSO) itemName.text = LocalizationManager.Localize((item as NPCProfileSO).keyName);
        if (item is DamageObjectSO) itemName.text = LocalizationManager.Localize((item as DamageObjectSO).keyName);
        itemImage.color = Color.black;
    }

    private void ShowDamageObjectSO(DamageObjectSO damageObjectProfileSO)
    {
        if (damageObjectProfileSO == null) return;
        itemDictionary = damageObjectProfileSO;
        itemName.text = LocalizationManager.Localize(damageObjectProfileSO.keyName);
        itemImage.sprite = damageObjectProfileSO.spriteInHand;
        itemImage.color = Color.white;
    }

    private void ShowEnemyProfileSO(EnemyProfileSO enemyProfileSO)
    {
        if (enemyProfileSO == null) return;
        itemDictionary = enemyProfileSO;
        itemName.text = LocalizationManager.Localize(enemyProfileSO.keyName);
        itemImage.color = Color.white;
        itemImage.sprite = enemyProfileSO.sprite;
    }

    private void ShowNPCProfileSO(NPCProfileSO npcProfileSO)
    {
        if (npcProfileSO == null) return;
        itemDictionary = npcProfileSO;
        itemName.text = LocalizationManager.Localize(npcProfileSO.keyName);
        itemImage.color = Color.white;
        itemImage.sprite = npcProfileSO.sprite;
    }

    private bool CheckNewItem() =>
        Dictionary.Instance.NpcsAvailableButNotSeen.Contains(itemDictionary as NPCProfileSO)
            || Dictionary.Instance.EnemiesAvailableButNotSeen.Contains(itemDictionary as EnemyProfileSO)
            || Dictionary.Instance.DamageObjectSOsAvailableButNotSeen.Contains(itemDictionary as DamageObjectSO);

    public void OnAddItem()
    {
        if (CheckNewItem()) iconNewItem.gameObject.SetActive(true);
        else iconNewItem.gameObject.SetActive(false);
    }

    public void OnSeenItem()
    {
        if (CheckNewItem()) iconNewItem.gameObject.SetActive(true);
        else iconNewItem.gameObject.SetActive(false);
    }
}