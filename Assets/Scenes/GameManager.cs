using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomleft;
    public static Vector2 topRight;
    public TextMeshProUGUI score;
    public static int ballHit;



    // Start is called before the first frame update
    void Start()
    {

        bottomleft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //Create Ball
        Instantiate(ball);

        //Create two paddles
        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;
        //rightpaddle
        paddle1.Init(true);
        //leftpaddle
        paddle2.Init(false);

        ballHit = 0;
    }
    void Update()
    {
        score.text = ballHit.ToString();
    }
}
