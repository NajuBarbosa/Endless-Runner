using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{

    public static GameController Instance { get; private set; }

    [Header("Ground Properties")]

    public float destroyedGround;
    public float groundWidth;
    public float groundSpeed;
    public GameObject groundPrefab;

    [Header("Obstacle Properties")]

    public GameObject obstaclePrefab;
    public float obstacleVelocity;
    public float obstacleTime;

    [Header("Coin Properties")]

    public GameObject coinPrefab;
    public float coinTime;

    [Header("UI Properties")]

    public int score;
    public Text scoreText;

    public int lifes;
    public Text lifesText;

    [Header("Music Properties")]

    public AudioSource fxGame;
    public AudioClip fxPoint;
    public AudioClip fxJump;
    public AudioClip fxHit;


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

    void Start()
    {
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnCoin());
    }

    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(obstacleTime);

        GameObject newObstacle = Instantiate(obstaclePrefab);
        StartCoroutine(SpawnObstacle());

        yield return new WaitForSeconds(1.5f);
        //Spawn coins together with obstacles
        StartCoroutine(SpawnCoin());
    }

    IEnumerator SpawnCoin()
    {
        int randomCoin = Random.Range(1, 7);
        for (int cont = 1; cont <= randomCoin; cont++)
        {
            yield return new WaitForSeconds(coinTime);

            GameObject newCoin = Instantiate(coinPrefab);
            newCoin.transform.position = new Vector3(newCoin.transform.position.x, newCoin.transform.position.y, 0);
        }

    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = score.ToString("0");
    }


}
