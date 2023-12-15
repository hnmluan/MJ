using UnityEngine;

public class TaskCustomeElement : MonoBehaviour
{
    public TaskInformation task;

    public void Show() => this.gameObject.SetActive(true);

    public void Hide() => this.gameObject.SetActive(false);
}
