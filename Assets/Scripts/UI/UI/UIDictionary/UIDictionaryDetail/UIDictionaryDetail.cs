using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class UIDictionaryDetail : InitMonoBehaviour
{
    [Header("UI Dictionary Information")]

    private static UIDictionaryDetail instance;
    public static UIDictionaryDetail Instance => instance;

    [SerializeField] protected ScriptableObject itemDictionary;

    [SerializeField] protected Text objName;
    public Text ObjName => objName;

    [SerializeField] protected Text objDescription;
    public Text ObjDescription => objDescription;

    [SerializeField] protected Image objImage;
    public Image ObjImage => objImage;

    protected override void Awake()
    {
        base.Awake();
        if (UIDictionaryDetail.instance != null) Debug.LogError("Only 1 UIDictionary allow to exist");
        UIDictionaryDetail.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemImage();
        this.LoadItemDescription();
    }

    private void LoadItemImage()
    {
        if (this.objImage != null) return;
        this.objImage = transform.Find("Image").Find("Image").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadItemDictionarytory", gameObject);
    }

    protected virtual void LoadItemName()
    {
        if (this.objName != null) return;
        this.objName = transform.Find("Name").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    protected virtual void LoadItemDescription()
    {
        if (this.objDescription != null) return;
        this.objDescription = transform.Find("Scroll View").Find("Viewport").Find("Content").Find("Description").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemDescription", gameObject);
    }

    protected override void OnDisable() => this.ShowEmptyObj();

    public void ShowDetailObj(ScriptableObject objSO)
    {
        if (objSO is EnemyProfileSO) ShowDetailEnemy(objSO as EnemyProfileSO);
        if (objSO is NPCProfileSO) ShowDetailNPC(objSO as NPCProfileSO);
        if (objSO is WeaponDataSO) ShowDetailDamageObject(objSO as WeaponDataSO);
        if (!Dictionary.Instance.CheckAvailableItemInDictonary(objSO)) HideDetail(objSO);
    }

    private void HideDetail(ScriptableObject objSO)
    {
        objImage.color = Color.black;
        if (objSO is EnemyProfileSO) objName.text = LocalizationManager.Localize((objSO as EnemyProfileSO).keyName);
        if (objSO is NPCProfileSO) objName.text = LocalizationManager.Localize((objSO as NPCProfileSO).keyName);
        if (objSO is WeaponDataSO) objName.text = LocalizationManager.Localize((objSO as WeaponDataSO).keyName);
        objDescription.text = "???????";
    }

    private void ShowDetailEnemy(EnemyProfileSO enemySO)
    {
        itemDictionary = enemySO;
        objImage.sprite = enemySO.sprite;
        objName.text = LocalizationManager.Localize(enemySO.keyName);
        objDescription.text = LocalizationManager.Localize(enemySO.keyDescription);
        objImage.color = Color.white;
    }

    private void ShowDetailNPC(NPCProfileSO npcSO)
    {
        itemDictionary = npcSO;
        objImage.sprite = npcSO.sprite;
        objName.text = LocalizationManager.Localize(npcSO.keyName);
        objDescription.text = LocalizationManager.Localize(npcSO.keyDescription);
        objImage.color = Color.white;
    }

    private void ShowDetailDamageObject(WeaponDataSO damageObjectSO)
    {
        itemDictionary = damageObjectSO;
        objImage.sprite = damageObjectSO.spriteInHand;
        objName.text = LocalizationManager.Localize(damageObjectSO.keyName);
        objDescription.text = LocalizationManager.Localize(damageObjectSO.keyDescription);
        objImage.color = Color.white;
    }

    public virtual void ShowEmptyObj()
    {
        objImage.color = Color.white;
        objImage.sprite = null;
        objName.text = "";
        objDescription.text = "";
    }
}
