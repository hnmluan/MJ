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

    [SerializeField] protected Transform focus;
    public Transform Focus => focus;

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
        this.LoadFocus();
    }

    private void LoadItemImage()
    {
        if (this.itemImage != null) return;
        this.itemImage = transform.Find("Image").Find("Image").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadItemDictionarytory", gameObject);
    }

    private void LoadFocus()
    {
        if (this.focus != null) return;
        this.focus = transform.Find("Focus");
        Debug.Log(transform.name + ": LoadFocus", gameObject);
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
        if (item is EnemyDataSO) ShowEnemyProfileSO(item as EnemyDataSO);
        if (item is CharacterDataSO) ShowNPCProfileSO(item as CharacterDataSO);
        if (item is WeaponDataSO) ShowDamageObjectSO(item as WeaponDataSO);
        if (!Dictionary.Instance.CheckAvailableItemInDictonary(item)) HideItem(item);
    }

    private void HideItem(ScriptableObject item)
    {
        if (item is EnemyDataSO) itemName.text = LocalizationManager.Localize((item as EnemyDataSO).keyName);
        if (item is CharacterDataSO) itemName.text = LocalizationManager.Localize((item as CharacterDataSO).keyName);
        if (item is WeaponDataSO) itemName.text = LocalizationManager.Localize((item as WeaponDataSO).keyName);
        itemImage.color = Color.black;
    }

    private void ShowDamageObjectSO(WeaponDataSO damageObjectProfileSO)
    {
        if (damageObjectProfileSO == null) return;
        itemDictionary = damageObjectProfileSO;
        itemName.text = LocalizationManager.Localize(damageObjectProfileSO.keyName);
        itemImage.sprite = damageObjectProfileSO.spriteInHand;
        itemImage.color = Color.white;
    }

    private void ShowEnemyProfileSO(EnemyDataSO enemyProfileSO)
    {
        if (enemyProfileSO == null) return;
        itemDictionary = enemyProfileSO;
        itemName.text = LocalizationManager.Localize(enemyProfileSO.keyName);
        itemImage.color = Color.white;
        itemImage.sprite = enemyProfileSO.portrait;
    }

    private void ShowNPCProfileSO(CharacterDataSO npcProfileSO)
    {
        if (npcProfileSO == null) return;
        itemDictionary = npcProfileSO;
        itemName.text = LocalizationManager.Localize(npcProfileSO.keyName);
        itemImage.color = Color.white;
        itemImage.sprite = npcProfileSO.portrait;
    }

    private bool CheckNewItem() =>
        Dictionary.Instance.NpcSOsAvailNotSeen.Contains(itemDictionary as CharacterDataSO)
            || Dictionary.Instance.EnemySOsAvailNotSeen.Contains(itemDictionary as EnemyDataSO)
            || Dictionary.Instance.WeaponSOsAvailNotSeen.Contains(itemDictionary as WeaponDataSO);

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