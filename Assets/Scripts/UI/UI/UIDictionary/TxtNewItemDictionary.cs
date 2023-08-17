using UnityEngine;
using UnityEngine.UI;

public class TxtNewItemDictionary : InitMonoBehaviour, IActionDictionaryObserver
{
    [SerializeField] protected Transform iconNew;

    [SerializeField] protected Text numberOfNewItem;

    protected override void OnEnable()
    {
        if (Dictionary.Instance.GetNumberOfItemInNotSeen() == 0)
        {
            iconNew.gameObject.SetActive(false);
            return;
        }
        iconNew.gameObject.SetActive(true);
        numberOfNewItem.text = Dictionary.Instance.GetNumberOfItemInNotSeen().ToString();
    }

    protected override void Start() => Dictionary.Instance.AddObserver(this);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNumberOfNewItem();
        this.LoadIconNew();
    }

    protected virtual void LoadNumberOfNewItem()
    {
        if (this.numberOfNewItem != null) return;
        this.numberOfNewItem = transform.GetComponentInChildren<Text>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadIconNew()
    {
        if (this.iconNew != null) return;
        this.iconNew = transform.Find("New");
        Debug.Log(transform.name + ": LoadIconNew", gameObject);
    }

    public void OnAddItem()
    {
        iconNew.gameObject.SetActive(true);
        numberOfNewItem.text = Dictionary.Instance.GetNumberOfItemInNotSeen().ToString();
    }

    public void OnSeenItem()
    {
        numberOfNewItem.text = Dictionary.Instance.GetNumberOfItemInNotSeen().ToString();
        if (Dictionary.Instance.GetNumberOfItemInNotSeen() == 0) iconNew.gameObject.SetActive(false);
    }
}
