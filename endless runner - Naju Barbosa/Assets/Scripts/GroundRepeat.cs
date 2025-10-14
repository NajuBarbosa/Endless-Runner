using UnityEngine;

public class GroundRepeat : MonoBehaviour
{

    private GameController gameController;

    public bool repositionGround = false;
    


    void Start()
    {
        gameController = GameController.Instance;
    }


    void Update()
    {
        if (repositionGround == false)
        {
            if (transform.position.x <= 0)
            {
                repositionGround = true;
                GameObject newGround = Instantiate(gameController.groundPrefab);
                newGround.transform.position = new Vector2(transform.position.x + gameController.groundWidth, transform.position.y);
            }
        }
        
        if (transform.position.x <= gameController.destroyedGround)
        {
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        MoveGround();
    }

    void MoveGround()
    {
        transform.Translate(Vector2.left * gameController.groundSpeed * Time.deltaTime);

    }
    
}
