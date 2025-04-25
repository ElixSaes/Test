using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class GoogleSheetConfigExporter : EditorWindow
{
    string csvUrl = "https://docs.google.com/spreadsheets/d/e/2PACX-1vQrwlTvZMWNpARZfvbvCZST2BwpQIz50fw1aBO4Sfp3ARtPHfJzQAa5vuPvjo9HQ-v-Bj5IJLeUbyUt/pub?output=csv";
    string outputPath = "Assets/Resources/Config/gameConfig.json";

    [MenuItem("Tools/GoogleSheet → Config JSON")]
    static void ShowWindow() => GetWindow<GoogleSheetConfigExporter>("Config Exporter");

    void OnGUI()
    {
        EditorGUILayout.LabelField("CSV URL", EditorStyles.boldLabel);
        csvUrl = EditorGUILayout.TextField(csvUrl);
        EditorGUILayout.LabelField("Output Path", EditorStyles.boldLabel);
        outputPath = EditorGUILayout.TextField(outputPath);

        if (GUILayout.Button("Export Config"))
            DownloadAndSave();
    }

    async void DownloadAndSave()
    {
        var uwr = UnityWebRequest.Get(csvUrl);
        await uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("CSV download failed: " + uwr.error);
            return;
        }

        var lines = uwr.downloadHandler.text
            .Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length < 2)
        {
            Debug.LogError("CSV 데이터가 부족합니다.");
            return;
        }

        var headers = lines[0].Split(',');
        var values = lines[1].Split(',');

        // ? 외부 선언된 GameConfig 사용
        GameConfig config = new GameConfig();

        for (int i = 0; i < headers.Length && i < values.Length; i++)
        {
            string key = headers[i].Trim();
            string rawValue = values[i].Trim();

            if (!float.TryParse(rawValue, out float v))
            {
                Debug.LogWarning($"[파싱 실패] key: {key}, value: {rawValue}");
                continue;
            }

            switch (key)
            {
                case "missileSpeed": config.missileSpeed = v; break;
                case "missileCooldown": config.missileCooldown = v; break;
                case "dashDistance": config.dashDistance = v; break;
                case "dashDuration": config.dashDuration = v; break;
                case "missileDamage": config.missileDamage = v; break;
                case "maxHealth": config.maxHealth = (int)v; break;
                default:
                    Debug.LogWarning($"[알 수 없는 필드] '{key}'");
                    break;
            }
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        string json = JsonUtility.ToJson(config, true);
        File.WriteAllText(outputPath, json);
        AssetDatabase.Refresh();
        Debug.Log("Config JSON exported to: " + outputPath);
        Debug.Log("Generated JSON:\n" + json);
    }
}
