using System.Collections.Generic;
using UnityEngine;

public class NPCConverse : NPCAbstract, IInteractable
{
    public float detectionConversableRange = 2f;

    public bool isPlayerInRange = false;

    [SerializeField] NPCDialog npcDialog;

    public bool isConverable = false;

    public List<string> dialogsToShow;

    public void Interact()
    {
        if (IsConverable()) StartCoroutine(DialogCtrl.Instance.ShowDialog(dialogsToShow));
    }

    private bool IsConverable()
    {
        dialogsToShow = npcDialog.GetLocalizationKeysForTask("task_1");
        return dialogsToShow.Count != 0;
    }

    public void ToggleCommunicativeSign(bool isActive) => npcCtrl.DialogConversable.SetActive(isActive);

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionConversableRange);
    }
}
