using System.Collections.Generic;
using UnityEngine;

public class NPCConverse : NPCAbstract, IInteractable
{
    [SerializeField] protected bool isConverable = false;

    [SerializeField] protected List<string> dialogsToShow;

    [SerializeField] protected bool isInConversation;

    [SerializeField] protected bool isDialog;

    protected override void Start()
    {
        UIDialog.Instance.OnHideDialog += () => MoveFree();
        UIDialog.Instance.OnShowDialog += () => MoveToPlayer();
        MoveFree();
    }

    public void Interact()
    {
        if (!IsConverable()) return;
        StartCoroutine(UIDialog.Instance.ShowDialog(dialogsToShow, npcCtrl.NPCSO.faceset));
        isInConversation = true;
        Dictionary.Instance.AddDictionary(npcCtrl.NPCSO);
    }

    private void MoveToPlayer()
    {
        npcCtrl.ObjMoveToPlayer.enabled = true;
        npcCtrl.ObjMoveFree.enabled = false;
    }
    private void MoveFree()
    {
        npcCtrl.ObjMoveToPlayer.enabled = false;
        npcCtrl.ObjMoveFree.enabled = true;
    }

    private bool IsConverable()
    {
        dialogsToShow = npcCtrl.NPCSO.npcDialog.GetLocalizationKeysForTask("task_1");
        return dialogsToShow.Count != 0;
    }

    public void ToggleCommunicativeSign(bool isActive)
    {
        if (IsConverable()) npcCtrl.DialogConversable.SetActive(isActive);
    }
}
