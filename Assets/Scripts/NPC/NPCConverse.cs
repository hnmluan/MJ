using System.Collections.Generic;
using UnityEngine;

public class NPCConverse : NPCAbstract, IInteractable
{
    [SerializeField] protected float conversableRange = 2f;

    [SerializeField] protected bool isConverable = false;

    [SerializeField] protected List<string> dialogsToShow;

    public void Interact()
    {
        if (IsConverable()) StartCoroutine(DialogCtrl.Instance.ShowDialog(dialogsToShow, npcCtrl.NPCSO.faceset));
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, conversableRange);
    }
}
