using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class CriteriaTaskTextSpawner : Spawner
{
    [SerializeField] protected Transform content;

    public static string item = "CriteriaText";

    protected override void LoadHolder() => this.holder = this.content;

    public virtual void Clear() { foreach (Transform item in this.holder) this.Despawn(item); }

    public virtual void Spawn(string LocalizationKey, CriteriaStatus criteriaStatus)
    {
        Transform uiItem = this.Spawn(CriteriaTaskTextSpawner.item, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);

        LocalizedText localizedText = uiItem.GetComponent<LocalizedText>();
        localizedText.LocalizationKey = LocalizationKey;
        Text text = uiItem.GetComponent<Text>();
        text.color = new Color(0.7412f, 0.4157f, 0.3882f);
        if (criteriaStatus == CriteriaStatus.done) text.color = new Color(0f, 0.4235f, 0f); ;

        uiItem.gameObject.SetActive(true);
    }
}
