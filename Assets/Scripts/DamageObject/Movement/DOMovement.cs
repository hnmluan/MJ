using UnityEngine;

public abstract class DOMovement : DOAbstract
{
    [SerializeField] protected float timeMovement;

    [SerializeField] protected float timer;

    protected override void OnEnable() => timer = 0;

    protected void Update()
    {
        if (CanMove()) Move();
    }

    protected abstract void Move();

    protected bool CanMove() => timer + Time.deltaTime < timeMovement;

    public void SetTimeMovement(float timeMovement) => this.timeMovement = timeMovement;
}
