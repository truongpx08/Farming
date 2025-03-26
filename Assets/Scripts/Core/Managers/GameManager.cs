using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<GameManager>();

                if (instance == null)
                {
                    GameObject gameManagerObject = new GameObject("GameManager");
                    instance = gameManagerObject.AddComponent<GameManager>();
                }
            }

            return instance;
        }
    }

    [SerializeField] private PlayerController player;

    private void Awake()
    {
        // Đảm bảo chỉ có một instance của GameManager
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Khởi tạo game
        InitializeGame();
    }

    private void InitializeGame()
    {
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        PlayerModel playerModel = new PlayerModel();
        player.Initialize(playerModel);
    }
}