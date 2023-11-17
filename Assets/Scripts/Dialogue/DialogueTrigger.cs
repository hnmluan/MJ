using UnityEngine;

public class DialogueTrigger : InitMonoBehaviour
{
    [SerializeField] private CharacterCtrl characterCtrl;

    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();

    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.characterCtrl != null) return;
        this.characterCtrl = transform.GetComponentInParent<CharacterCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }



    private void Update()
    {
        characterCtrl.VisualCue.SetActive(playerInRange && !DialogueManager.Instance.dialogueIsPlaying);

        if (playerInRange && !DialogueManager.Instance.dialogueIsPlaying)
        {
            if (InputManager.Instance.StartInteract())
            {
                DialogueManager.Instance.EnterDialogueMode(inkJSON, characterCtrl.EmoteAnimator);
            }
        }

        characterCtrl.ObjMoveFree.gameObject.SetActive(!DialogueManager.Instance.dialogueIsPlaying);
        characterCtrl.ObjMoveToPlayer.gameObject.SetActive(DialogueManager.Instance.dialogueIsPlaying);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") playerInRange = false;
    }

}

