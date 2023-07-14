using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class TaskDialogue
{
    public string taskName;
    public string[] texts;
}

[System.Serializable]
public class NPCDialogue
{
    public string name;
    public TaskDialogue[] tasks;
}

[System.Serializable]
public class DialogueData
{
    public NPCDialogue[] characters;
}

public class DialogueManager : InitMonoBehaviour
{
    private static DialogueManager instance;
    public static DialogueManager Instance { get { return instance; } }

    public string jsonFileName = "dialogue"; // Tên tệp tin JSON

    [SerializeField] private DialogueData dialogueData; // Dữ liệu được đọc từ file JSON

    protected override void Awake()
    {
        base.Awake();

        if (DialogueManager.instance != null) Debug.LogError("Only 1 DialogueManager allow to exist");

        DialogueManager.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFileJSON();
    }

    private void LoadFileJSON()
    {
        string jsonFilePath = FindJSONFilePath(jsonFileName);
        if (!string.IsNullOrEmpty(jsonFilePath))
            LoadDialogueData(jsonFilePath); // Gọi phương thức để đọc file JSON khi bắt đầu
        else
            Debug.LogError("Không tìm thấy tệp tin JSON");
    }

    private string FindJSONFilePath(string fileName)
    {
        // Tìm đường dẫn tương đối của tệp tin JSON
        string[] filePaths = Directory.GetFiles(Application.dataPath, "*.json", SearchOption.AllDirectories);
        foreach (string filePath in filePaths)
        {
            if (Path.GetFileNameWithoutExtension(filePath) == fileName)
            {
                return filePath;
            }
        }

        return string.Empty;
    }

    private void LoadDialogueData(string jsonFilePath)
    {
        // Đọc nội dung từ file JSON
        string jsonContent = File.ReadAllText(jsonFilePath);

        // Chuyển đổi JSON thành đối tượng DialogueData
        dialogueData = JsonUtility.FromJson<DialogueData>(jsonContent);
    }

    public List<string> StartDialogue(string characterName, int taskIndex)
    {
        List<string> dialogueList = new List<string>();

        // Tìm kiếm nhân vật theo tên
        NPCDialogue character = FindCharacter(characterName);

        if (character != null && taskIndex >= 0 && taskIndex < character.tasks.Length)
        {
            // Lấy nội dung lời thoại của nhiệm vụ từ nhân vật
            TaskDialogue task = character.tasks[taskIndex];

            // Lưu trữ lời thoại vào danh sách
            foreach (string text in task.texts)
            {
                dialogueList.Add(text);
            }
        }

        return dialogueList;
    }

    private NPCDialogue FindCharacter(string characterName)
    {
        // Tìm kiếm nhân vật trong danh sách
        foreach (NPCDialogue character in dialogueData.characters)
        {
            if (character.name == characterName)
            {
                return character;
            }
        }

        // Trả về null nếu không tìm thấy nhân vật
        return null;
    }
}
