using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition;
    public int missileCount;
    public int currentHealth;
}
public static class SaveManager
{
    private static string savePath => Path.Combine(Application.persistentDataPath, "saveData.json");

    public static void Save(Vector3 position, int health, int missileCount)
    {
        SaveData data = new SaveData
        {
            playerPosition = position,
            currentHealth = health,
            missileCount = missileCount
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("[💾 저장됨] " + savePath);
    }

    public static SaveData Load()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning("[⚠️ 저장 파일 없음]");
            return null;
        }

        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        Debug.Log("[📂 불러오기 완료]");
        return data;
    }

    // ✅ 개발용: 유니티 재실행 시 초기화 원할 때 저장 파일 삭제 기능
    [UnityEditor.MenuItem("Tools/SaveSystem/Delete Save File")]
    public static void DeleteSaveFile()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("[🗑 저장 파일 삭제됨]");
        }
    }
}