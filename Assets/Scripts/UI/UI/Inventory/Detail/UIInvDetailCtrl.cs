using UnityEngine;
using UnityEngine.UI;

public class UIInvDetailCtrl : InitMonoBehaviour
{
    [Header("UI Inv Detail Ctrl")]

    [SerializeField] protected Image itemImage;
    public Image ItemImage => itemImage;

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Text itemType;
    public Text ItemType => itemType;

    [SerializeField] protected Text itemDescription;
    public Text ItemDescription => itemDescription;

    [SerializeField] protected Text itemQuantity;
    public Text ItemQuantity => itemQuantity;

    [SerializeField] protected BtnInvUse btnInvUse;
    public BtnInvUse BtnInvUse => btnInvUse;

    [SerializeField] protected BtnInvUseAll btnInvUseAll;
    public BtnInvUseAll BtnInvUseAll => btnInvUseAll;

    [SerializeField] protected BtnInvBuy btnInvBuy;
    public BtnInvBuy BtnInvBuy => btnInvBuy;

    [SerializeField] protected BtnInvBuyAll btnInvBuyAll;
    public BtnInvBuyAll BtnInvBuyAll => btnInvBuyAll;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemType();
        this.LoadItemName();
        this.LoadItemQuantity();
        this.LoadBtnUse();
        this.LoadBtnUseAll();
        this.LoadItemImage();
        this.LoadItemDiscription();
        this.LoadBtnBuy();
        this.LoadBtnBuyAll();
    }

    private void LoadItemType()
    {
        if (this.itemType != null) return;
        this.itemType = transform.Find("Information").Find("Grid").Find("ItemType").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemType", gameObject);
    }

    private void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("Information").Find("Grid").Find("ItemName").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    private void LoadItemQuantity()
    {
        if (this.itemQuantity != null) return;
        this.itemQuantity = transform.Find("Information").Find("Grid").Find("ItemQuantity").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    private void LoadItemDiscription()
    {
        if (this.itemDescription != null) return;
        this.itemDescription = transform.Find("Information").
            Find("Scroll View").
            Find("Viewport").
            Find("Content").
            Find("Description").
            GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemDiscription", gameObject);
    }

    private void LoadItemImage()
    {
        if (this.itemImage != null) return;
        this.itemImage = transform.Find("Image").Find("ItemImage").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadItemImage", gameObject);
    }

    protected virtual void LoadBtnUse()
    {
        if (this.btnInvUse != null) return;
        this.btnInvUse = transform.GetComponentInChildren<BtnInvUse>();
        Debug.Log(transform.name + ": LoadBtnUse", gameObject);
    }

    protected virtual void LoadBtnUseAll()
    {
        if (this.btnInvUseAll != null) return;
        this.btnInvUseAll = transform.GetComponentInChildren<BtnInvUseAll>();
        Debug.Log(transform.name + ": LoadBtnUse", gameObject);
    }

    protected virtual void LoadBtnBuy()
    {
        if (this.btnInvBuy != null) return;
        this.btnInvBuy = transform.GetComponentInChildren<BtnInvBuy>();
        Debug.Log(transform.name + ": LoadBtnUse", gameObject);
    }

    protected virtual void LoadBtnBuyAll()
    {
        if (this.btnInvBuyAll != null) return;
        this.btnInvBuyAll = transform.GetComponentInChildren<BtnInvBuyAll>();
        Debug.Log(transform.name + ": LoadBtnUse", gameObject);
    }
}
