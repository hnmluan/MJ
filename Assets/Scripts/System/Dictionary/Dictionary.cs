using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ListEnemy = System.Collections.Generic.List<EnemyDataSO>;
using ListNPC = System.Collections.Generic.List<CharacterDataSO>;
using ListWeapon = System.Collections.Generic.List<WeaponDataSO>;

public class Dictionary : Singleton<Dictionary>
{
    [SerializeField] protected List<IActionDictionaryObserver> observers = new List<IActionDictionaryObserver>();

    [SerializeField] ListWeapon weaponSOsAvailSeen;
    public ListWeapon WeaponSOsAvailSeen { get => weaponSOsAvailSeen; }

    [SerializeField] ListWeapon weaponSOsAvailNotSeen;
    public ListWeapon WeaponSOsAvailNotSeen { get => weaponSOsAvailNotSeen; }

    [SerializeField] ListNPC npcSOsAvailSeen;
    public ListNPC NpcSOsAvailSeen { get => npcSOsAvailSeen; }

    [SerializeField] ListNPC npcSOsAvailNotSeen;
    public ListNPC NpcSOsAvailNotSeen { get => npcSOsAvailNotSeen; }

    [SerializeField] ListEnemy enemySOsAvailSeen;
    public ListEnemy EnemySOsAvailSeen { get => enemySOsAvailSeen; }

    [SerializeField] ListEnemy enemySOsAvailNotSeen;
    public ListEnemy EnemySOsAvailNotSeen { get => enemySOsAvailNotSeen; }

    protected override void Awake()
    {
        base.Awake();
        LoadData();
    }

    public void LoadData()
    {
        DictionaryData dictionaryData = SaveLoadHandler.LoadFromFile<DictionaryData>(FileNameData.Dictionary);

        if (dictionaryData == null) return;

        this.enemySOsAvailSeen = dictionaryData.enemySOsAvailSeen
            .Where(item => EnemyCodeParser.FromString(item) != EnemyCode.NoEnemy)
            .Select(item => EnemyDataSO.FindByName(item)).ToList();

        this.enemySOsAvailNotSeen = dictionaryData.enemySOsAvailNotSeen
            .Where(item => EnemyCodeParser.FromString(item) != EnemyCode.NoEnemy)
            .Select(item => EnemyDataSO.FindByName(item)).ToList();

        this.weaponSOsAvailSeen = dictionaryData.weaponSOsAvailSeen
            .Where(item => WeaponCodeParser.FromString(item) != WeaponCode.NoWeapon)
            .Select(item => WeaponDataSO.FindByName(item)).ToList();
        this.weaponSOsAvailNotSeen = dictionaryData.weaponSOsAvailNotSeen
            .Where(item => WeaponCodeParser.FromString(item) != WeaponCode.NoWeapon)
            .Select(item => WeaponDataSO.FindByName(item)).ToList();

        this.npcSOsAvailSeen = dictionaryData.npcSOsAvailSeen
            .Where(item => CharacterCodeParser.FromString(item) != CharacterCode.NoActor)
            .Select(item => CharacterDataSO.FindByName(item)).ToList();
        this.npcSOsAvailNotSeen = dictionaryData.npcSOsAvailNotSeen
            .Where(item => CharacterCodeParser.FromString(item) != CharacterCode.NoActor)
            .Select(item => CharacterDataSO.FindByName(item)).ToList();
    }

    public void SaveData() => SaveLoadHandler.SaveToFile(FileNameData.Dictionary, new DictionaryData(this));

    private void AddDictionary(WeaponDataSO damageObjectSO)
    {
        if (weaponSOsAvailSeen.Contains(damageObjectSO) || weaponSOsAvailNotSeen.Contains(damageObjectSO)) return;
        weaponSOsAvailNotSeen.Add(damageObjectSO);
        SaveData();
    }

    private void AddDictionary(CharacterDataSO npcProfileSO)
    {
        if (npcSOsAvailSeen.Contains(npcProfileSO) || npcSOsAvailNotSeen.Contains(npcProfileSO)) return;
        npcSOsAvailNotSeen.Add(npcProfileSO);
        SaveData();
    }

    private void AddDictionary(EnemyDataSO enemyProfileSO)
    {
        if (enemySOsAvailSeen.Contains(enemyProfileSO) || enemySOsAvailNotSeen.Contains(enemyProfileSO)) return;
        enemySOsAvailNotSeen.Add(enemyProfileSO);
        SaveData();
    }

    public void AddDictionary(ScriptableObject profileSO)
    {
        if (profileSO is EnemyDataSO) AddDictionary(profileSO as EnemyDataSO);
        if (profileSO is CharacterDataSO) AddDictionary(profileSO as CharacterDataSO);
        if (profileSO is WeaponDataSO) AddDictionary(profileSO as WeaponDataSO);
        OnAddItem();
        SaveData();
    }

    private void SeenItemDictionary(EnemyDataSO enemyProfileSO)
    {
        if (enemySOsAvailNotSeen.Contains(enemyProfileSO))
        {
            enemySOsAvailSeen.Add(enemyProfileSO);
            enemySOsAvailNotSeen.Remove(enemyProfileSO);
        }
        SaveData();
    }

    private void SeenItemDictionary(CharacterDataSO npcProfileSO)
    {
        if (npcSOsAvailNotSeen.Contains(npcProfileSO))
        {
            npcSOsAvailSeen.Add(npcProfileSO);
            npcSOsAvailNotSeen.Remove(npcProfileSO);
        }
        SaveData();
    }

    private void SeenItemDictionary(WeaponDataSO damageObjectSO)
    {
        if (weaponSOsAvailNotSeen.Contains(damageObjectSO))
        {
            WeaponSOsAvailSeen.Add(damageObjectSO);
            weaponSOsAvailNotSeen.Remove(damageObjectSO);
        }
        SaveData();
    }

    public void SeenItemDictionary(ScriptableObject profileSO)
    {
        if (profileSO is EnemyDataSO) SeenItemDictionary(profileSO as EnemyDataSO);
        if (profileSO is CharacterDataSO) SeenItemDictionary(profileSO as CharacterDataSO);
        if (profileSO is WeaponDataSO) SeenItemDictionary(profileSO as WeaponDataSO);
        this.OnAddItem();
        SaveData();
    }

    public bool CheckAvailableItemInDictonary(ScriptableObject profileSO)
        => weaponSOsAvailSeen.Contains(profileSO as WeaponDataSO)
        || weaponSOsAvailNotSeen.Contains(profileSO as WeaponDataSO)
        || npcSOsAvailSeen.Contains(profileSO as CharacterDataSO)
        || npcSOsAvailNotSeen.Contains(profileSO as CharacterDataSO)
        || enemySOsAvailSeen.Contains(profileSO as EnemyDataSO)
        || enemySOsAvailNotSeen.Contains(profileSO as EnemyDataSO);

    public int GetNumberOfItemInNotSeen() =>
    Dictionary.Instance.EnemySOsAvailNotSeen.Count
    + Dictionary.Instance.NpcSOsAvailNotSeen.Count
    + Dictionary.Instance.WeaponSOsAvailNotSeen.Count;

    public int GetNumberOfNpcsInNotSeen() => Dictionary.Instance.NpcSOsAvailNotSeen.Count;

    public int GetNumberOfEnemiesInNotSeen() => Dictionary.Instance.enemySOsAvailNotSeen.Count;

    public int GetNumberOfWeaponsInNotSeen() => Dictionary.Instance.weaponSOsAvailNotSeen.Count;

    public virtual void AddObserver(IActionDictionaryObserver observer) => this.observers.Add(observer);

    protected virtual void OnAddItem()
    {
        foreach (IActionDictionaryObserver observer in this.observers) observer.OnAddItem();
    }

    protected virtual void OnDeductItem()
    {
        foreach (IActionDictionaryObserver observer in this.observers) observer.OnSeenItem();
    }
}
