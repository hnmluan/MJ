using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DialogueTrigger : InitMonoBehaviour
{
    [Header("Visual Cue")]

    [SerializeField] private GameObject visualCue;

    [SerializeField] private BoxCollider2D trigger;

    [Header("Ink JSON")]

    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    protected override void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
    }

    private void LoadTrigger()
    {
        if (this.trigger != null) return;
        this.trigger = transform.GetComponentInChildren<BoxCollider2D>();
        trigger.isTrigger = true;
        trigger.size = new Vector2(4, 4);
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (InputManager.Instance.InteractDialogue())
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
            visualCue.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            playerInRange = false;
    }
}