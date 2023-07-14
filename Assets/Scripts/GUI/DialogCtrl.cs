using System;
using System.Collections;
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

    [SerializeField] protected int lettersPerSecond = 40;

    public event Action OnShowDialog, OnHideDialog;

    Dialog dialog;

    int currentLocalizationKeys = 0;

    bool isTyping;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDialogBox();
        this.LoadDialogText();
        this.LoadFaceset();
        this.LoadLocalizedDialog();
    }

    private void LoadFaceset()
    {
        if (this.faceset != null) return;
        this.faceset = dialogBox.GetComponentInChildren<Image>(); ;
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

    protected override void Awake()
    {
        base.Awake();

        if (DialogCtrl.instance != null) Debug.LogError("Only 1 DialogCtrl allow to exist");

        DialogCtrl.instance = this;
    }

    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();

        OnShowDialog?.Invoke();

        this.dialog = dialog;

        dialogBox.SetActive(true);

        StartCoroutine(TypeDialog(LocalizedDialog.GetDialogLocalizedText(dialog.LocalizationKeys[0])));
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !isTyping)
        {
            ++currentLocalizationKeys;

            if (currentLocalizationKeys < dialog.LocalizationKeys.Count)
            {
                StartCoroutine(TypeDialog(LocalizedDialog.GetDialogLocalizedText(dialog.LocalizationKeys[currentLocalizationKeys])));
            }
            else
            {
                dialogBox.SetActive(false);
                currentLocalizationKeys = 0;
                OnHideDialog?.Invoke();
            }
        }
    }

    public IEnumerator TypeDialog(string text)
    {
        isTyping = true;

        dialogText.text = "";

        foreach (var letter in text.ToCharArray())
        {
            dialogText.text += letter;

            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        isTyping = false;
    }


}
