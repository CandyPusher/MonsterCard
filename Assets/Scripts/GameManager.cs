using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameFlowManager gameFlowManager;
    public ArduinoManager arduinoManager_P1;
    public ArduinoManager arduinoManager_P2;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
