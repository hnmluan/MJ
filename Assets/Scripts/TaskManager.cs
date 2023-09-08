using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public enum TaskCode
{
    NoTask = 0,
    Greeting = 1,
    Task_1 = 2,
    Task_2 = 3,
    Task_3 = 4,
    Task_4 = 5,
    Ending = 6,
}

public class TaskManager : Singleton<TaskManager>
{
    public TaskCode currentTask = TaskCode.NoTask;

    [SerializeField] private GameObject taskPanel;

    [SerializeField] private Text taskName;

    [SerializeField] private Text taskDescription;

    public void Switch2NextTaskEnumCode()
    {
        if (currentTask == TaskCode.Ending) return;
        currentTask++;
        OpenTaskPanel();
        taskPanel.SetActive(true);
        Debug.Log("Switch2NextTaskEnumCode");
    }

    public void OpenTaskPanel()
    {
        taskName.text = "";
        taskDescription.text = "";

        TaskDataSO taskDataSO = TaskDataSO.FindByItemCode(currentTask);
        if (taskDataSO == null)
        {
            Debug.Log("Don't have any availabel Task Data SO");
            return;
        };

        taskName.text = LocalizationManager.Localize(taskDataSO.keyName);
        taskDescription.text = LocalizationManager.Localize(taskDataSO.keyDescription);

        taskPanel.SetActive(true);
    }
}
