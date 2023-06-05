using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    public float groundWidth;
    public float obstacleWidth;
    private void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x;
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }

    }

    private void Update()
    {
        if (GameManager.gameOver == false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        }
        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);
            }
        }    
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x < GameManager.bottonLeft.x - obstacleWidth)
            {
                Destroy(gameObject);
            }
        }
    }

}
