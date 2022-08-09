using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;
    public static bool isRightPlayerWin;
    public static bool gameOver=false;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if(transform.position.y<GameManager.bottomleft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        if (transform.position.x < GameManager.bottomleft.x + radius && direction.x < 0)
        {
            Debug.Log("Right player wins");
            Time.timeScale = 0;
            enabled = false;
            isRightPlayerWin = true;
            gameOver = true;
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Left player wins");
            Time.timeScale = 0;
            enabled = false;
            isRightPlayerWin = false;
            gameOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle") {
            bool isRight = other.GetComponent<Paddle>().isRight;
            if(isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
                GameManager.ballHit += 1;
            }
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
                GameManager.ballHit += 1;
            }
        }
    }
}
