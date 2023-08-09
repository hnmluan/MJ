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
        UIDialog.Instance.OnHideDialog += () => this.isInConversation = false;
    }

    private void Update()
    {
        if (isInConversation)
        {
            npcCtrl.ObjMoveToPlayer.enabled = true;
            npcCtrl.ObjMoveFree.enabled = false;
            return;
        }
        npcCtrl.ObjMoveToPlayer.enabled = false;
        npcCtrl.ObjMoveFree.enabled = true;
    }

    public void Interact()
    {
        if (!IsConverable()) return;
        StartCoroutine(UIDialog.Instance.ShowDialog(dialogsToShow, npcCtrl.NPCSO.faceset));
        isInConversation = true;

    }

    private bool IsConverable()
    {
        dialogsToShow = npcCtrl.NPCSO.npcDialog.GetLocalizationKeysForTask("task_1");
        //nếu không có lời thoại nào của npc trong nhiệm vụ đó thì không thể giao tiếp
        return dialogsToShow.Count != 0;
    }

    public void ToggleCommunicativeSign(bool isActive)
    {
        if (IsConverable()) npcCtrl.DialogConversable.SetActive(isActive);
    }
}
