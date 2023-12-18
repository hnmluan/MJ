using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class DialogueTrigger : InitMonoBehaviour, IObservationTask
{
    [SerializeField] private CharacterCtrl characterCtrl;

    [SerializeField] private TextAsset inkJSONDialogue;

    [SerializeField] private CircleCollider2D collider;

    protected override void Start()
    {
        base.Start();
        this.ResetJSONDialogue();
        Task.Instance.AddObservation(this);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
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

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            characterCtrl.VisualCue.SetActive(inkJSONDialogue != null);

            if (!DialogueManager.Instance.dialogueIsPlaying && InputManager.Instance.StartInteract() && inkJSONDialogue != null)
            {
                DialogueManager.Instance.EnterDialogueMode(inkJSONDialogue, characterCtrl.EmoteAnimator);
                characterCtrl.MoveFree.gameObject.SetActive(false);
                characterCtrl.FollowPlayer.gameObject.SetActive(true);
            }
            else
            {
                characterCtrl.MoveFree.gameObject.SetActive(true);
                characterCtrl.FollowPlayer.gameObject.SetActive(false);
            }
        }
    }

    protected void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            characterCtrl.VisualCue.SetActive(false);
            characterCtrl.FollowPlayer.gameObject.SetActive(false);
            characterCtrl.MoveFree.gameObject.SetActive(true);
        }
    }

    protected void ResetJSONDialogue() => this.inkJSONDialogue = characterCtrl.DataSO.GetDialogueJSONOf(Task.Instance.CurrentTask);

    public void DoneCriteriaTask() => this.ResetJSONDialogue();

    public void Switch2NextTask() => this.ResetJSONDialogue();

    public void AcceptTask() => this.ResetJSONDialogue();
}
