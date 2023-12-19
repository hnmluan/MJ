using Assets.SimpleLocalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITask : UIBase, IObservationTask
{
    private static UITask instance;
    public static UITask Instance => instance;

    [SerializeField] protected LocalizedText discription;
    public LocalizedText Discription => discription;

    [SerializeField] protected LocalizedText title;
    public LocalizedText Title => title;

    [SerializeField] protected Button btnAccept;
    public Button BtnAccept => btnAccept;

    [SerializeField] protected CriteriaTaskTextSpawner criteriaTaskTextSpawner;
    public CriteriaTaskTextSpawner CriteriaTaskTextSpawner => criteriaTaskTextSpawner;

    [SerializeField] protected LocalizedText note;

    protected override void Awake()
    {
        base.Awake();
        if (UITask.instance != null) Debug.LogError("Only 1 UITask allow to exist");
        UITask.instance = this;
    }

    public override void Open()
    {
        this.ResetContent();
        base.Open();
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Task.Instance.CurrentTask.status == TaskStatus.start) Task.Instance.AcceptTask();
        if (Input.GetKeyDown(KeyCode.Space) && Task.Instance.CurrentTask.status == TaskStatus.processing) this.Close();
        if (Input.GetKeyDown(KeyCode.Space) && Task.Instance.CurrentTask.status == TaskStatus.done) this.Close();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTitle();
        this.LoadDiscription();
        this.LoadBtnAccept();
        this.LoadNote();
        this.LoadCriteriaTaskTextSpawner();
    }

    protected void LoadTitle()
    {
        if (this.title != null) return;
        this.title = transform.Find("Title").Find("Title").GetComponent<LocalizedText>();
        Debug.Log(transform.name + ": LoadItemType", gameObject);
    }

    protected void LoadNote()
    {
        if (this.note != null) return;
        this.note = transform.Find("Note").GetComponent<LocalizedText>();
        Debug.Log(transform.name + ": LoadNote", gameObject);
    }

    protected void LoadDiscription()
    {
        if (this.discription != null) return;
        this.discription = transform.Find("Discription").GetComponent<LocalizedText>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    protected void LoadBtnAccept()
    {
        if (this.btnAccept != null) return;
        this.btnAccept = transform.GetComponentInChildren<Button>();
        Debug.Log(transform.name + ": LoadBtnAccept", gameObject);
    }

    protected void LoadCriteriaTaskTextSpawner()
    {
        if (this.criteriaTaskTextSpawner != null) return;
        this.criteriaTaskTextSpawner = transform.GetComponentInChildren<CriteriaTaskTextSpawner>();
        Debug.Log(transform.name + ": LoadCriteriaTaskTextSpawner", gameObject);
    }

    public void DoneCriteriaTask() { }

    public void Switch2NextTask() { }

    public void AcceptTask() => this.Close();

    protected void ResetContent()
    {
        this.btnAccept.gameObject.SetActive(Task.Instance.CurrentTask.status == TaskStatus.start);
        this.note.LocalizationKey =
            Task.Instance.CurrentTask.status == TaskStatus.start ? "Task.Accept" :
            Task.Instance.CurrentTask.status == TaskStatus.processing ? "Task.Countinue" : "Task.Done";
        TaskDataSO taskDataSO = Task.Instance.GetDataSO();
        this.title.LocalizationKey = taskDataSO == null ? "Dont found task SO" : taskDataSO.title;
        this.discription.LocalizationKey = taskDataSO == null ? "Dont found task SO" : taskDataSO.content;
        this.discription.Localize();
        this.title.Localize();
        this.note.Localize();


        this.ResetCriteriaContent();
    }

    protected void ResetCriteriaContent()
    {
        criteriaTaskTextSpawner.Clear();

        List<string> criterias = TaskDataSO.FindByItemCode(Task.Instance.CurrentTask.code).criterias;

        for (int i = 0; i < criterias.Count; i++) criteriaTaskTextSpawner.Spawn(criterias[i], Task.Instance.criterias[i]);
    }
}
