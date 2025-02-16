using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static UiManager uiManager;
    public static GameManager Instance { get; private set; }
    public static int playerHealth = 3;
    private static int roomsLeft;
    private void Awake()
    {
        if (Instance == null) { Instance = this; } else if (Instance != this) { Destroy(this); }
    }
    private void Start()
    {
        roomsLeft = FindObjectsByType<RoomCheck>(FindObjectsSortMode.None).Length;
        Cursor.lockState = CursorLockMode.Locked;
        playerHealth = 3;
        uiManager = FindAnyObjectByType<UiManager>();
        uiManager.SetHealth();
    }
    public static void PlayerDamaged()
    {
        if (playerHealth > 0)
        {
            playerHealth--;
            uiManager.SetHealth();
        }
        else
            RestartGame();
    }
    public static void RoomScanned() 
    {
        roomsLeft--;
        if (roomsLeft == 0)
        {
            uiManager.EndGameText();
        }
    }
    public static void ShowError()
    {
        uiManager.ShowError();
    }
    public static void RestartGame()
    {
        playerHealth = 3;
        SceneManager.LoadScene("DoorScan");
    }
}
