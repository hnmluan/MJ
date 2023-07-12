using UnityEngine;

public class ProjectileSpawner : Spawner
{
    private static ProjectileSpawner instance;
    public static ProjectileSpawner Instance { get => instance; }

    public static string projectileOne = "ButterflyProjectile";

    public static string projectileTwo = "Projectile";

    protected override void Awake()
    {
        base.Awake();
        if (ProjectileSpawner.instance != null) Debug.LogError("Only 1 ProjectileSpawner allow to exist");
        ProjectileSpawner.instance = this;
    }
}
