using UnityEngine;

public static class ConfigLoader
{
    private static GameConfig _config;
    public static GameConfig Config
    {
        get
        {
            if (_config == null)
            {
                var text = Resources.Load<TextAsset>("Config/gameConfig");
                _config = JsonUtility.FromJson<GameConfig>(text.text);
                Debug.Log("Loaded JSON:\n" + text.text);
                _config = JsonUtility.FromJson<GameConfig>(text.text);
                Debug.Log($"Config ¡æ speed:{_config.missileSpeed}, cd:{_config.missileCooldown}, dash:{_config.dashDistance}, dmg:{_config.missileDamage}");

            }
            return _config;
        }
    }
}
