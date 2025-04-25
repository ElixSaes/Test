using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // 연결될 컴포넌트
    public PlayerInventory playerInventory;
    public PlayerHealth playerHealth;
    public Transform playerTransform;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            LoadGame();
        }
    }
    public void SaveGame()
    {
        if (playerInventory != null && playerHealth != null && playerTransform != null)
        {
            SaveManager.Save(
                playerTransform.position,                  // Vector3
                playerHealth.CurrentHealth,                // int
                playerInventory.currentMissileCount        // int
            );
        }
    }

    public void LoadGame()
    {
        if (playerInventory != null && playerHealth != null && playerTransform != null)
        {
            SaveData data = SaveManager.Load();
            if (data != null)
            {
                playerTransform.position = data.playerPosition;
                playerInventory.currentMissileCount = data.missileCount;
                playerHealth.SetHealth(data.currentHealth);
            }
        }
    }
}
