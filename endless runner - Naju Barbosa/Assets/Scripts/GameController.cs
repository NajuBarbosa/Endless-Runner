using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController Instance { get; private set; }

    [Header("Ground Properties")]

    public float destroyedGround;
    public float groundWidth;
    public float groundSpeed;
    public GameObject groundPrefab;


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


}
