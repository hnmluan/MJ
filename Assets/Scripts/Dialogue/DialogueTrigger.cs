using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class DialogueTrigger : InitMonoBehaviour
{
    [SerializeField] private CharacterCtrl characterCtrl;

    [SerializeField] private TextAsset inkJSON;

    [SerializeField] private CircleCollider2D collider;

    private bool playerInRange = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadCollider();
    }

    private void LoadCollider()
    {
        if (this.collider != null) return;
        this.collider = transform.GetComponent<CircleCollider2D>();
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }


    protected virtual void LoadEnemyCtrl()
    {
        if (this.characterCtrl != null) return;
        this.characterCtrl = transform.GetComponentInParent<CharacterCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    private void Update()
    {
        if (inkJSON == null) return;

        characterCtrl.VisualCue.SetActive(playerInRange && !DialogueManager.Instance.dialogueIsPlaying);

        if (playerInRange && !DialogueManager.Instance.dialogueIsPlaying && InputManager.Instance.StartInteract())
            DialogueManager.Instance.EnterDialogueMode(inkJSON, characterCtrl.EmoteAnimator);

        characterCtrl.MoveFree.gameObject.SetActive(!DialogueManager.Instance.dialogueIsPlaying);
        characterCtrl.FollowPlayer.gameObject.SetActive(DialogueManager.Instance.dialogueIsPlaying);
    }

    private void OnTriggerEnter2D(Collider2D collider) => playerInRange = collider.gameObject.tag == "Player";

    private void OnTriggerExit2D(Collider2D collider) => playerInRange = !(collider.gameObject.tag == "Player");
}
