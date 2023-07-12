using UnityEngine;

public class Challenger : MonoBehaviour, IInteractable
{
    [SerializeField] Dialog dialog;
    public void Interact()
    {
        StartCoroutine(DialogCtrl.Instance.ShowDialog(dialog));
    }
}
