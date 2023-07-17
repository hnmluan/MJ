using UnityEngine;

public class MakeSound : InitMonoBehaviour
{
    [SerializeField] protected Transform player;

    public float maxDistance = 10f;

    [SerializeField] private float timer;

    [SerializeField] public float minTimeToSpawnSound;

    [SerializeField] public float maxTimeToSpawnSound;

    [SerializeField] private float timeToSpawnSound;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }

    private void LoadPlayer()
    {
        if (this.player != null) return;
        player = GameObject.Find("Player").gameObject.transform;
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }

    protected override void Start() => RandomTimeToSpawnSound();

    private void Update()
    {
        if (CountDistanceToPlayer() > maxDistance)
        {
            timer = 0;
            return;
        };

        timer += Time.deltaTime;

        if (timer > timeToSpawnSound)
        {
            AudioController.Instance.PlayVFX("chicken_sound");
            timer = 0;
            RandomTimeToSpawnSound();
        }

    }

    private float CountDistanceToPlayer() => Vector3.Distance(player.position, transform.position);

    private void RandomTimeToSpawnSound() => timeToSpawnSound = Random.Range(minTimeToSpawnSound, maxTimeToSpawnSound);

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
