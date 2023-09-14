using UnityEngine;

public class AnimalMakeSound : InitMonoBehaviour
{
    [SerializeField] protected Transform player;

    public float maxDistance = 10f;

    [SerializeField] private float timer;

    [SerializeField] public float minTimeToSpawnSound;

    [SerializeField] public float maxTimeToSpawnSound;

    [SerializeField] private float timeToSpawnSound;

    [SerializeField] public string soundName;

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
            AudioController.Instance.AnimalVolume(CountVolumeByDistance(AudioController.Instance.SFXVolume()));
            AudioController.Instance.PlayAnimalSound(soundName);
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

    private float CountVolumeByDistance(float volume) => volume * (1 - CountDistanceToPlayer() / maxDistance);
}
