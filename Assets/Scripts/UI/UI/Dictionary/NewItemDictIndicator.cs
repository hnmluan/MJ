using UnityEngine;
using UnityEngine.UI;

public class NewItemDictIndicator : InitMonoBehaviour, IObservationDictionary
{
    [SerializeField] Transform indicatorIcon;

    [SerializeField] Text indicatorText;

    protected override void Awake()
    {
        base.Awake();
        Dictionary.Instance.AddObservation(this);
    }

    protected override void Start() => CheckUseenItem();


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadIndicatorIcon();
        this.LoadIndicatorText();
    }

    private void LoadIndicatorIcon()
    {
        if (indicatorIcon != null) return;
        this.indicatorIcon = transform.Find("IndicatorIcon");
        Debug.Log(transform.name + ": LoadIndicatorIcon", gameObject);
    }

    private void LoadIndicatorText()
    {
        if (indicatorText != null) return;
        this.indicatorText = indicatorIcon.Find("IndicatorText").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadIndicatorText", gameObject);
    }

    public void AddItem() => CheckUseenItem();

    public void SeenItem() => CheckUseenItem();

    public void CheckUseenItem()
    {
        indicatorIcon.gameObject.SetActive(Dictionary.Instance.GetNumUnseenItems() != 0);
        indicatorText.text = Dictionary.Instance.GetNumUnseenItems().ToString();
    }
}
