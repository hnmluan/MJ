using UnityEngine;

public class AnimalMoveFree : MoveFree
{
    [SerializeField] protected AnimalCtrl animalCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimalCtrl();
    }

    protected virtual void LoadAnimalCtrl()
    {
        if (animalCtrl != null) return;
        animalCtrl = transform.parent.GetComponent<AnimalCtrl>();
        Debug.Log(transform.name + ": LoadAnimalCtrl", gameObject);
    }

    protected override void Update()
    {
        base.Update();
        SetAnimation();
    }

    private void SetAnimation()
    {
        float x = moveDirection.x;
        animalCtrl.Animator.SetBool("isMoving", this.isMoving);
        if (x == 0) return;
        if (x > 0)
        {
            animalCtrl.Model.localScale = new Vector3(1, 1, 1);
            return;
        }
        if (x < 0)
        {
            animalCtrl.Model.localScale = new Vector3(-1, 1, 1);
            return;
        }
    }
}
