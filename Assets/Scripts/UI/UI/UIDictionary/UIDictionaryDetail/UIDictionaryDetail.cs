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

    protected override void OnDisable() => this.ShowEmptyObj();

    public void ShowDetailObj(ScriptableObject objSO)
    {
        if (objSO is EnemyProfileSO) ShowDetailEnemy(objSO as EnemyProfileSO);
        if (objSO is NPCProfileSO) ShowDetailNPC(objSO as NPCProfileSO);
        if (objSO is DamageObjectSO) ShowDetailDamageObject(objSO as DamageObjectSO);
        if (!Dictionary.Instance.CheckAvailableItemInDictonary(objSO)) HideDetail();
    }

    private void HideDetail()
    {
        objImage.color = Color.black;
        objName.text = "???????";
    }

    private void ShowDetailEnemy(EnemyProfileSO enemySO)
    {
        itemDictionary = enemySO;
        objImage.sprite = enemySO.sprite;
        objName.text = enemySO.name;
        objImage.color = Color.white;
    }

    private void ShowDetailNPC(NPCProfileSO npcSO)
    {
        itemDictionary = npcSO;
        objImage.sprite = npcSO.sprite;
        objName.text = npcSO.name;
        objImage.color = Color.white;
    }

    private void ShowDetailDamageObject(DamageObjectSO damageObjectSO)
    {
        itemDictionary = damageObjectSO;
        objImage.sprite = damageObjectSO.spriteInHand;
        objName.text = damageObjectSO.name;
        objImage.color = Color.white;
    }

    public virtual void ShowEmptyObj()
    {
        //objImage.sprite = null;
        objName.text = "";
    }
}
