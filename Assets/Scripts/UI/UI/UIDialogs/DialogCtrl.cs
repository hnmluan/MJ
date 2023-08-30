using UnityEngine;
using UnityEngine.UI;

public class DialogCtrl : InitMonoBehaviour
{
    private static DialogCtrl instance;
    public static DialogCtrl Instance { get => instance; }

    [SerializeField] protected GameObject dialogBox;
    public GameObject DialogBox { get => dialogBox; }

    [SerializeField] protected Text dialogText;
    public Text DialogText { get => dialogText; }

    [SerializeField] protected LocalizedDialog localizedDialog;
    public LocalizedDialog LocalizedDialog { get => localizedDialog; }

    [SerializeField] protected Image faceset;
    public Image Faceset { get => faceset; }

    protected override void Awake()
    {
        base.Awake();
        if (DialogCtrl.instance != null) Debug.Log("Only 1 DialogCtrl allow to exist");
        DialogCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDialogBox();
        this.LoadDialogText();
        this.LoadLocalizedDialog();
        this.LoadFaceset();
    }

    private void LoadFaceset()
    {
        if (this.faceset != null) return;
        this.faceset = dialogBox.transform.Find("Faceset").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadFaceset", gameObject);
    }

    private void LoadDialogText()
    {
        if (this.dialogText != null) return;
        this.dialogText = dialogBox.GetComponentInChildren<Text>();
        Debug.Log(transform.name + ": LoadDialogText", gameObject);
    }

    private void LoadLocalizedDialog()
    {
        if (this.localizedDialog != null) return;
        this.localizedDialog = dialogBox.GetComponentInChildren<LocalizedDialog>();
        Debug.Log(transform.name + ": LoadLocalizedDialog", gameObject);
    }

    private void LoadDialogBox()
    {
        if (this.dialogBox != null) return;
        this.dialogBox = transform.Find("DialogBox").gameObject;
        Debug.Log(transform.name + ": LoadDialogBox", gameObject);
    }




}
