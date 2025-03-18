using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 다른 클래스에서 인스턴스 생성을 막기 위해 private로,
    // 인스턴스를 공유하기 위해서 static을 붙여줍니다.
    private static GameManager instance;

    // 프로퍼티를 사용해서 인스턴스가 초기화되기 전에 인스턴스에 접근하면,
    // 인스턴스를 생성해줍니다.
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameManager();
            return instance;
        }
    }

    // Awake는 가장 먼저 실행되는 함수로,
    // 여기서 인스턴스에 대한 초기화를 진행해줍니다.
    private void Awake()
    {
        // 인스턴스가 비어있다면 할당해주고, 
        //해당 오브젝트를 씬 이동간 파괴하지 않게합니다.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // 인스턴스가 이미 할당돼있다면(2개 이상이라면) 파괴합니다.
        else
        {
            Destroy(gameObject);
        }
    }
}