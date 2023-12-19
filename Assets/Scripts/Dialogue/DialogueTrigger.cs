using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class DialogueTrigger : InitMonoBehaviour, IObservationTask
{
    [SerializeField] private CharacterCtrl characterCtrl;

    [SerializeField] private TextAsset inkJSONDialogue;

    [SerializeField] private CircleCollider2D collider;

    private bool inConversationRange = false;

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

    protected void Update()
    {
        bool inConversationMode =
            DialogueManager.Instance.speaker == transform.parent.ToString()
            && DialogueManager.Instance.dialogueIsPlaying;

        characterCtrl.MoveFree.gameObject.SetActive(!inConversationMode);
        characterCtrl.FollowPlayer.gameObject.SetActive(inConversationMode);

        characterCtrl.VisualCue.SetActive(inConversationRange && !DialogueManager.Instance.dialogueIsPlaying && inkJSONDialogue != null);

        if (inkJSONDialogue == null) return;

        if (inConversationRange && !DialogueManager.Instance.dialogueIsPlaying && InputManager.Instance.StartInteract())
        {
            DialogueManager.Instance.EnterDialogueMode(inkJSONDialogue, characterCtrl.EmoteAnimator);
            DialogueManager.Instance.SetSpeaker(transform.parent.ToString());
        }
    }

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") inConversationRange = true;
    }

    protected void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") inConversationRange = false;
    }

    protected void ResetJSONDialogue() => this.inkJSONDialogue = characterCtrl.DataSO.GetDialogueJSONOf(Task.Instance.CurrentTask);

    public void DoneCriteriaTask() => this.ResetJSONDialogue();

    public void Switch2NextTask() => this.ResetJSONDialogue();

    public void AcceptTask() => this.ResetJSONDialogue();
}
