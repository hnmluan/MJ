using Assets.SimpleLocalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EDictionaryType
{
    Enemies,
    NPCs,
    Weapons
}

public class UIDictionary : UIBase, IObservationDictionary
{
    private static UIDictionary instance;
    public static UIDictionary Instance => instance;

    [SerializeField] protected EDictionaryType dictionaryType = EDictionaryType.Enemies;
    public EDictionaryType DictionaryType => dictionaryType;

    [SerializeField] protected UIDictionaryItemSpawner dictionaryItemSpawner;

    [SerializeField] protected UIDictionaryDetail dictionaryDetail;
    public UIDictionaryDetail DictionaryDetail => dictionaryDetail;

    [SerializeField] protected List<Transform> tabs;

    [SerializeField] protected Transform tabEnemy;

    [SerializeField] protected Transform tabNPC;

    [SerializeField] protected Transform tabWeapon;

    [SerializeField] protected Text unseenEnemiesCount;

    [SerializeField] protected Text unseenNPCsCount;

    [SerializeField] protected Text unseenWeaponsCount;

    [SerializeField] protected LocalizedText noteText;

    protected override void Awake()
    {
        base.Awake();
        if (UIDictionary.instance != null) Debug.LogError("Only 1 UIDictionary allow to exist");
        UIDictionary.instance = this;
    }

    protected override void OnEnable()
    {
        Dictionary.Instance.AddObservation(this);
        SwitchTab(EDictionaryType.Enemies);
        unseenEnemiesCount.text = "(" + Dictionary.Instance.GetNumUnseenEnemies() + ")";
        unseenNPCsCount.text = "(" + Dictionary.Instance.GetNumUnseenNpcs() + ")";
        unseenWeaponsCount.text = "(" + Dictionary.Instance.GetNumUnseenWeapons() + ")";
    }

    protected override void OnDisable() => Dictionary.Instance.RemoveObservation(this);

    private void ShowEnemies()
    {
        foreach (EnemyDataSO item in EnemyDataSO.GetAllSO()) dictionaryItemSpawner.SpawnItem(item);
    }

    private void ShowNPCs()
    {
        foreach (CharacterDataSO item in CharacterDataSO.GetAllSO()) dictionaryItemSpawner.SpawnItem(item);
    }

    private void ShowWeapons()
    {
        foreach (WeaponDataSO item in WeaponDataSO.GetAllSO()) dictionaryItemSpawner.SpawnItem(item);
    }

    protected virtual void ClearItems() => dictionaryItemSpawner.ClearItems();

    protected virtual void SortItems()
    {
        int itemCount = dictionaryItemSpawner.Content.childCount;
        bool isSorting = false;

        for (int i = 0; i < itemCount - 1; i++)
        {
            Transform currObj = dictionaryItemSpawner.Content.GetChild(i);
            Transform nextObj = dictionaryItemSpawner.Content.GetChild(i + 1);

            UIItemDictionary currentUIObj = currObj.GetComponent<UIItemDictionary>();
            UIItemDictionary nextUIObj = nextObj.GetComponent<UIItemDictionary>();

            ScriptableObject currentProfile = currentUIObj.ItemDictionary;
            ScriptableObject nextProfile = nextUIObj.ItemDictionary;

            string currentName =
                currentProfile is EnemyDataSO ? LocalizationManager.Localize((currentProfile as EnemyDataSO).keyName) :
                currentProfile is WeaponDataSO ? LocalizationManager.Localize((currentProfile as WeaponDataSO).keyName) :
                LocalizationManager.Localize((currentProfile as CharacterDataSO).keyName);

            string nextName =
                nextProfile is EnemyDataSO ? LocalizationManager.Localize((nextProfile as EnemyDataSO).keyName) :
                nextProfile is WeaponDataSO ? LocalizationManager.Localize((nextProfile as WeaponDataSO).keyName) :
                LocalizationManager.Localize((nextProfile as CharacterDataSO).keyName);

            bool isSwap = false;

            isSwap = string.Compare(currentName, nextName) == 1;

            if (isSwap)
            {
                this.SwapItems(currObj, nextObj);
                isSorting = true;
            }
        }

        if (isSorting) this.SortItems();
    }

    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }

    public void UnFocusAllTab()
    {
        foreach (Transform item in tabs)
        {
            Color targetColor = ColorUtility.TryParseHtmlString("#A9A9A9", out Color parsedColor) ? parsedColor : Color.white;
            item.GetComponent<Image>().color = targetColor;
        }
    }

    public void SwitchTab(EDictionaryType dictionaryType)
    {
        //if (this.dictionaryType == dictionaryType && dictionaryItemSpawner.Content.childCount == 0) return;

        this.dictionaryType = dictionaryType;

        this.ClearItems();

        switch (dictionaryType)
        {
            case EDictionaryType.Enemies:
                noteText.LocalizationKey = "Dictionary.NoteEnemies";
                ShowEnemies();
                break;
            case EDictionaryType.NPCs:
                noteText.LocalizationKey = "Dictionary.NoteNpcs";
                ShowNPCs();
                break;
            case EDictionaryType.Weapons:
                noteText.LocalizationKey = "Dictionary.NoteWeapons";
                ShowWeapons();
                break;
        }

        SortItems();
        UIDictionary.Instance.DictionaryDetail.Clear();
        UnFocusAllTab();
        noteText.Localize();
    }

    public void AddItem() { }

    public void SeenItem()
    {
        unseenEnemiesCount.text = "(" + Dictionary.Instance.GetNumUnseenEnemies() + ")";
        unseenNPCsCount.text = "(" + Dictionary.Instance.GetNumUnseenNpcs() + ")";
        unseenWeaponsCount.text = "(" + Dictionary.Instance.GetNumUnseenWeapons() + ")";
    }
}
