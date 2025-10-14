using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private GameController gameController;

    private Rigidbody2D rbObstacle;

    void Start()
    {
        rbObstacle = GetComponent<Rigidbody2D>();
        gameController = GameController.Instance;
    }

    void FixedUpdate()
    {
        MoveObstacle();
        CheckOffScreen();
    }

    void MoveObstacle()
    {
        transform.Translate(Vector2.left * gameController.obstacleVelocity * Time.smoothDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameController.fxGame.PlayOneShot(gameController.fxHit);
            gameController.lifes--;
            if (gameController.lifes < 0)
            {
                Debug.Log("Game Over");
            }
            else
            {
                gameController.lifesText.text = gameController.lifes.ToString("0");
            }
        }
    }

    void CheckOffScreen()
    {
        if (transform.position.x < gameController.destroyedGround)
        {
            Destroy(gameObject);
        }
    }


}
