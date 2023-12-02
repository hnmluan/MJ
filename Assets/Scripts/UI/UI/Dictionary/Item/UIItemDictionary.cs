using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class UIItemDictionary : InitMonoBehaviour, IObservationDictionary
{
    protected ScriptableObject itemDictionary;
    public ScriptableObject ItemDictionary => itemDictionary;

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Image itemImage;
    public Image Image => itemImage;

    [SerializeField] protected Transform unseenIcon;
    public Transform NewIcon => unseenIcon;

    [SerializeField] protected Transform focus;
    public Transform Focus => focus;

    protected override void OnEnable()
    {
        Dictionary.Instance.AddObservation(this);
        unseenIcon.gameObject.SetActive(false);
        if (Dictionary.Instance.isUnseenItem(itemDictionary)) unseenIcon.gameObject.SetActive(true);
    }

    protected override void OnDisable() => Dictionary.Instance.RemoveObservation(this);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemImage();
        this.LoadIconNewItem();
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

    protected virtual void LoadIconNewItem()
    {
        if (this.unseenIcon != null) return;
        this.unseenIcon = transform.Find("New");
        Debug.Log(transform.name + ": LoadIonNewItem", gameObject);
    }

    public virtual void ShowItem(ScriptableObject item)
    {
        if (item is EnemyDataSO) ShowEnemy(item as EnemyDataSO);
        if (item is CharacterDataSO) ShowNPC(item as CharacterDataSO);
        if (item is WeaponDataSO) ShowWeapon(item as WeaponDataSO);
        if (!Dictionary.Instance.isAvailableItem(item)) HideItem(item);
    }

    private void HideItem(ScriptableObject item)
    {
        if (item is EnemyDataSO) itemName.text = LocalizationManager.Localize((item as EnemyDataSO).keyName);
        if (item is CharacterDataSO) itemName.text = LocalizationManager.Localize((item as CharacterDataSO).keyName);
        if (item is WeaponDataSO) itemName.text = LocalizationManager.Localize((item as WeaponDataSO).keyName);
        itemImage.color = Color.black;
    }

    private void ShowWeapon(WeaponDataSO damageObjectProfileSO)
    {
        if (damageObjectProfileSO == null) return;
        itemDictionary = damageObjectProfileSO;
        itemName.text = LocalizationManager.Localize(damageObjectProfileSO.keyName);
        itemImage.sprite = damageObjectProfileSO.spriteInHand;
        itemImage.color = Color.white;
    }

    private void ShowEnemy(EnemyDataSO enemyProfileSO)
    {
        if (enemyProfileSO == null) return;
        itemDictionary = enemyProfileSO;
        itemName.text = LocalizationManager.Localize(enemyProfileSO.keyName);
        itemImage.color = Color.white;
        itemImage.sprite = enemyProfileSO.portrait;
    }

    private void ShowNPC(CharacterDataSO npcProfileSO)
    {
        if (npcProfileSO == null) return;
        itemDictionary = npcProfileSO;
        itemName.text = LocalizationManager.Localize(npcProfileSO.keyName);
        itemImage.color = Color.white;
        itemImage.sprite = npcProfileSO.portrait;
    }

    public void AddItem()
    {
        if (Dictionary.Instance.isAvailableItem(itemDictionary)) ShowItem(itemDictionary);
    }

    public void SeenItem()
    {
        if (Dictionary.Instance.isSeenItem(itemDictionary)) unseenIcon.gameObject.SetActive(false);
    }
}