using UnityEngine;

public class NPCConverse : NPCAbstract, IInteractable
{
    public float detectionConversableRange = 2f;

    [SerializeField] Dialog dialog;

    public void Interact()
    {
        StartCoroutine(DialogCtrl.Instance.ShowDialog(dialog));
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionConversableRange);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                npcCtrl.DialogConversable.SetActive(true);
                Debug.Log("Hello");
                break;
            }
            npcCtrl.DialogConversable.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Vẽ hình cầu để hiển thị phạm vi phát hiện trong Scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionConversableRange);
    }
}
