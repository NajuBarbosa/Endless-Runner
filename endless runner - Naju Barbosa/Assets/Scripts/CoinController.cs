using System;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    GameController gameController;
    private Rigidbody2D rbCoin;


    void Start()
    {
        gameController = GameController.Instance;
        rbCoin = GetComponent<Rigidbody2D>();
        rbCoin.linearVelocity = new Vector2(-6f, 0);
    }

    void FixedUpdate()
    {
        CheckOffScreen();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameController.fxGame.PlayOneShot(gameController.fxPoint);
            gameController.UpdateScore(1);
            Destroy(gameObject);
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
