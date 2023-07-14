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
        if (IsConverable())
            StartCoroutine(DialogCtrl.Instance.ShowDialog(dialogsToShow));
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionConversableRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                isPlayerInRange = true;
                break;
            }
            isPlayerInRange = false;
        }
        npcCtrl.DialogConversable.SetActive(isPlayerInRange);

        if (isPlayerInRange)
        {
            if (Input.GetKeyUp(KeyCode.C) & GameController.Instance.State != GameState.Dialog) Interact();
        }
    }

    private bool IsConverable()
    {
        dialogsToShow = npcDialog.GetLocalizationKeysForTask("task_1");
        return dialogsToShow.Count != 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionConversableRange);
    }
}
