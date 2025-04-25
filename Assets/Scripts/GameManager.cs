using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �ٸ� Ŭ�������� �ν��Ͻ� ������ ���� ���� private��,
    // �ν��Ͻ��� �����ϱ� ���ؼ� static�� �ٿ��ݴϴ�.
    private static GameManager instance;

    // ������Ƽ�� ����ؼ� �ν��Ͻ��� �ʱ�ȭ�Ǳ� ���� �ν��Ͻ��� �����ϸ�,
    // �ν��Ͻ��� �������ݴϴ�.
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameManager();
            return instance;
        }
    }

    // Awake�� ���� ���� ����Ǵ� �Լ���,
    // ���⼭ �ν��Ͻ��� ���� �ʱ�ȭ�� �������ݴϴ�.
    private void Awake()
    {
        // �ν��Ͻ��� ����ִٸ� �Ҵ����ְ�, 
        //�ش� ������Ʈ�� �� �̵��� �ı����� �ʰ��մϴ�.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // �ν��Ͻ��� �̹� �Ҵ���ִٸ�(2�� �̻��̶��) �ı��մϴ�.
        else
        {
            Destroy(gameObject);
        }
    }
}