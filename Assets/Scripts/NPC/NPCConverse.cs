using UnityEngine;

public class NPCConverse : NPCAbstract, IInteractable
{
    public float detectionConversableRange = 2f;

    public bool isPlayerInRange = false;

    [SerializeField] Dialog dialog;

    public void Interact() => StartCoroutine(DialogCtrl.Instance.ShowDialog(dialog));

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
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionConversableRange);
    }
}
