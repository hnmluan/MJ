using UnityEngine;
using UnityEngine.UI;

public class UIDictionaryIn4 : InitMonoBehaviour
{
    [Header("UI Dictionary Information")]

    private static UIDictionaryIn4 instance;
    public static UIDictionaryIn4 Instance => instance;

    [SerializeField] protected Text objName;
    public Text ObjName => objName;

    [SerializeField] protected Image objImage;
    public Image ObjImage => objImage;

    protected override void Awake()
    {
        base.Awake();
        if (UIDictionaryIn4.instance != null) Debug.LogError("Only 1 UIDictionary allow to exist");
        UIDictionaryIn4.instance = this;
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
    }

    private void ShowDetailEnemy(EnemyProfileSO enemySO)
    {
        objImage.sprite = enemySO.sprite;
        objName.text = enemySO.name;
    }

    private void ShowDetailNPC(NPCProfileSO npcSO)
    {
        objImage.sprite = npcSO.sprite;
        objName.text = npcSO.name;
    }

    public virtual void ShowEmptyObj()
    {
        //objImage.sprite = null;
        objName.text = "";
    }
}
