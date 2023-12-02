using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class UIDictionaryDetail : InitMonoBehaviour
{
    [SerializeField] protected Text objName;
    public Text ObjName => objName;

    [SerializeField] protected Text objDescription;
    public Text ObjDescription => objDescription;

    [SerializeField] protected Image objImage;
    public Image ObjImage => objImage;

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

    protected override void OnDisable() => this.Clear();

    public void ShowDetailObj(ScriptableObject objSO)
    {
        if (objSO is EnemyDataSO) ShowDetailEnemy(objSO as EnemyDataSO);
        if (objSO is CharacterDataSO) ShowDetailNPC(objSO as CharacterDataSO);
        if (objSO is WeaponDataSO) ShowDetailDamageObject(objSO as WeaponDataSO);
        if (!Dictionary.Instance.isAvailableItem(objSO)) HideDetail(objSO);
    }

    private void HideDetail(ScriptableObject objSO)
    {
        objImage.color = Color.black;
        if (objSO is EnemyDataSO) objName.text = LocalizationManager.Localize((objSO as EnemyDataSO).keyName);
        if (objSO is CharacterDataSO) objName.text = LocalizationManager.Localize((objSO as CharacterDataSO).keyName);
        if (objSO is WeaponDataSO) objName.text = LocalizationManager.Localize((objSO as WeaponDataSO).keyName);
        objDescription.text = "???????";
    }

    private void ShowDetailEnemy(EnemyDataSO enemySO)
    {
        objImage.sprite = enemySO.portrait;
        objName.text = LocalizationManager.Localize(enemySO.keyName);
        objDescription.text = LocalizationManager.Localize(enemySO.keyDescription);
        objImage.color = Color.white;
    }

    private void ShowDetailNPC(CharacterDataSO npcSO)
    {
        objImage.sprite = npcSO.portrait;
        objName.text = LocalizationManager.Localize(npcSO.keyName);
        objDescription.text = LocalizationManager.Localize(npcSO.keyDescription);
        objImage.color = Color.white;
    }

    private void ShowDetailDamageObject(WeaponDataSO damageObjectSO)
    {
        objImage.sprite = damageObjectSO.spriteInHand;
        objName.text = LocalizationManager.Localize(damageObjectSO.keyName);
        objDescription.text = LocalizationManager.Localize(damageObjectSO.keyDescription);
        objImage.color = Color.white;
    }

    public virtual void Clear()
    {
        objImage.color = Color.white;
        objImage.sprite = null;
        objName.text = "";
        objDescription.text = "";
    }
}
