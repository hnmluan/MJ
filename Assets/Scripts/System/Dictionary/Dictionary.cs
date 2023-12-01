using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ListEnemy = System.Collections.Generic.List<EnemyDataSO>;
using ListNPC = System.Collections.Generic.List<CharacterDataSO>;
using ListWeapon = System.Collections.Generic.List<WeaponDataSO>;

public class Dictionary : Singleton<Dictionary>
{
    private List<IObservationDictionary> observations = new List<IObservationDictionary>();

    [SerializeField] ListWeapon seenWeapons, unseenWeapons;
    [SerializeField] ListEnemy seenEnemies, unseenEnemies;
    [SerializeField] ListNPC seenNPCs, unseenNPCs;

    public ListWeapon SeenWeapons { get => seenWeapons; }
    public ListWeapon UnseenWeapons { get => unseenWeapons; }
    public ListNPC SeenNPCs { get => seenNPCs; }
    public ListNPC UnseenNPCs { get => unseenNPCs; }
    public ListEnemy SeenEnemies { get => seenEnemies; }
    public ListEnemy UnseenEnemies { get => unseenEnemies; }

    protected override void Awake()
    {
        base.Awake();
        LoadData();
    }

    public void LoadData()
    {
        DictionaryData dictionaryData = SaveLoadHandler.LoadFromFile<DictionaryData>(FileNameData.Dictionary);

        if (dictionaryData == null) return;

        this.seenEnemies = dictionaryData.seenEnemies
            .Where(item => EnemyCodeParser.FromString(item) != EnemyCode.NoEnemy)
            .Select(item => EnemyDataSO.FindByName(item)).ToList();

        this.unseenEnemies = dictionaryData.unseenEnemies
            .Where(item => EnemyCodeParser.FromString(item) != EnemyCode.NoEnemy)
            .Select(item => EnemyDataSO.FindByName(item)).ToList();

        this.seenWeapons = dictionaryData.seenWeapons
            .Where(item => WeaponCodeParser.FromString(item) != WeaponCode.NoWeapon)
            .Select(item => WeaponDataSO.FindByName(item)).ToList();
        this.unseenWeapons = dictionaryData.unseenWeapons
            .Where(item => WeaponCodeParser.FromString(item) != WeaponCode.NoWeapon)
            .Select(item => WeaponDataSO.FindByName(item)).ToList();

        this.seenNPCs = dictionaryData.seenNPCs
            .Where(item => CharacterCodeParser.FromString(item) != CharacterCode.NoActor)
            .Select(item => CharacterDataSO.FindByName(item)).ToList();
        this.unseenNPCs = dictionaryData.unseenNPCs
            .Where(item => CharacterCodeParser.FromString(item) != CharacterCode.NoActor)
            .Select(item => CharacterDataSO.FindByName(item)).ToList();
    }

    public void SaveData() => SaveLoadHandler.SaveToFile(FileNameData.Dictionary, new DictionaryData(this));

    private void AddItem<T>(T SO, List<T> seenItems, List<T> unseenItems)
        where T : ScriptableObject
    {
        if (seenItems.Contains(SO) || unseenItems.Contains(SO)) return;
        unseenItems.Add(SO);
        SaveData();
    }

    public void AddItem(ScriptableObject profileSO)
    {
        if (profileSO is EnemyDataSO enemyProfileSO) AddItem(enemyProfileSO, seenEnemies, unseenEnemies);
        else if (profileSO is CharacterDataSO npcProfileSO) AddItem(npcProfileSO, seenNPCs, unseenNPCs);
        else if (profileSO is WeaponDataSO damageObjectSO) AddItem(damageObjectSO, SeenWeapons, unseenWeapons);
        ExcuteAddItemObservation();
        SaveData();
    }

    private void SeenItem<T>(T SO, List<T> seenItems, List<T> unseenItems) where T : ScriptableObject
    {
        if (!unseenItems.Contains(SO)) return;

        seenItems.Add(SO);
        unseenItems.Remove(SO);
        SaveData();
    }

    public void SeenItem(ScriptableObject profileSO)
    {
        if (profileSO is EnemyDataSO enemyProfileSO) SeenItem(enemyProfileSO, seenEnemies, unseenEnemies);
        else if (profileSO is CharacterDataSO npcProfileSO) SeenItem(npcProfileSO, seenNPCs, unseenNPCs);
        else if (profileSO is WeaponDataSO damageObjectSO) SeenItem(damageObjectSO, SeenWeapons, unseenWeapons);
        ExcuteSeenItemObservation();
        SaveData();
    }

    public bool isAvailableItem(ScriptableObject SO) => isSeenItem(SO) || isUnseenItem(SO);

    public bool isSeenItem(ScriptableObject SO)
    => seenWeapons.Contains(SO as WeaponDataSO)
    || seenNPCs.Contains(SO as CharacterDataSO)
    || seenEnemies.Contains(SO as EnemyDataSO);

    public bool isUnseenItem(ScriptableObject SO)
    => unseenWeapons.Contains(SO as WeaponDataSO)
    || unseenNPCs.Contains(SO as CharacterDataSO)
    || unseenEnemies.Contains(SO as EnemyDataSO);

    public int GetNumUnseenItems() => unseenEnemies.Count + unseenNPCs.Count + unseenWeapons.Count;

    public int GetNumUnseenNpcs() => unseenNPCs.Count;

    public int GetNumUnseenEnemies() => unseenEnemies.Count;

    public int GetNumUnseenWeapons() => unseenWeapons.Count;

    public void AddObservation(IObservationDictionary observation) => observations.Add(observation);

    public void RemoveObservation(IObservationDictionary observation) => observations.Remove(observation);

    public void ExcuteSeenItemObservation()
    {
        foreach (IObservationDictionary observation in observations) observation.SeenItem();
    }

    public void ExcuteAddItemObservation()
    {
        foreach (IObservationDictionary observation in observations) observation.AddItem();
    }
}
