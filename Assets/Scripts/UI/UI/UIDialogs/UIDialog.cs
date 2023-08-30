using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDialog : InitMonoBehaviour
{
    private static UIDialog instance;
    public static UIDialog Instance { get => instance; }

    [SerializeField] protected int lettersPerSecond = 40;

    public event Action OnShowDialog, OnHideDialog;

    public List<String> dialogsToShow;

    int currentLocalizationKeys = 0;

    bool isTyping;

    protected override void Awake()
    {
        base.Awake();
        if (UIDialog.instance != null) Debug.Log("Only 1 UIDialog allow to exist");
        UIDialog.instance = this;
    }

    protected override void Start() => DialogCtrl.Instance.DialogBox.SetActive(false);

    public IEnumerator ShowDialog(List<String> dialogsToShow, Sprite faceset)
    {
        yield return new WaitForEndOfFrame();

        OnShowDialog?.Invoke();

        this.dialogsToShow = dialogsToShow;

        DialogCtrl.Instance.DialogBox.SetActive(true);

        string dialog = DialogCtrl.Instance.LocalizedDialog.GetDialogLocalizedText(dialogsToShow[0]);

        StartCoroutine(TypeDialog(dialog));

        DialogCtrl.Instance.Faceset.sprite = faceset;
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !isTyping)
        {
            ++currentLocalizationKeys;

            if (currentLocalizationKeys < dialogsToShow.Count)
            {
                string dialog = DialogCtrl.Instance.LocalizedDialog.GetDialogLocalizedText(dialogsToShow[currentLocalizationKeys]);
                StartCoroutine(TypeDialog(dialog));
            }
            else
            {
                DialogCtrl.Instance.DialogBox.SetActive(false);
                currentLocalizationKeys = 0;
                OnHideDialog?.Invoke();
            }
        }
    }

    public IEnumerator TypeDialog(string text)
    {
        isTyping = true;

        DialogCtrl.Instance.DialogText.text = "";

        foreach (var letter in text.ToCharArray())
        {
            DialogCtrl.Instance.DialogText.text += letter;

            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        isTyping = false;
    }


}
