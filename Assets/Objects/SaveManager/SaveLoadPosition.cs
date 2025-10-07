using System.Collections.Generic;
using System.IO;
using UnityEngine;

[ExecuteAlways] // so that the buttons are active in the editor
public class SaveLoadPosition : MonoBehaviour
{
    [SerializeField] private string fileName = "positions.json";
    [SerializeField] private List<Transform> objectsToSave = new();

    [System.Serializable]
    private class ObjectData
    {
        public string name;
        public Vector3 position;
    }

    [System.Serializable]
    private class SaveData
    {
        public List<ObjectData> objects = new();
    }

    private string FilePath => Path.Combine(Application.persistentDataPath, fileName);

    [ContextMenu("Save")] // button in the inspector
    public void Save()
    {
        var saveData = new SaveData();

        foreach (var obj in objectsToSave)
        {
            if (obj == null) continue;

            saveData.objects.Add(new ObjectData
            {
                name = obj.name,
                position = obj.position
            });
        }

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(FilePath, json);
        Debug.Log($"✅ Saved to {FilePath}");
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (!File.Exists(FilePath))
        {
            Debug.LogWarning("⚠️ No save file found!");
            return;
        }

        string json = File.ReadAllText(FilePath);
        var saveData = JsonUtility.FromJson<SaveData>(json);

        foreach (var data in saveData.objects)
        {
            var obj = objectsToSave.Find(o => o != null && o.name == data.name);
            if (obj != null)
                obj.position = data.position;
        }

        Debug.Log("✅ Loaded positions from file");
    }
}