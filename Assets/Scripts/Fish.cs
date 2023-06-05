using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]private float speed = 9f;

    int angle;
    int maxangle = 20;
    int minangle = -60;

    public Score score;

    bool touchedGround;
    public GameManager gameManager;

    public Sprite fishDied;
    SpriteRenderer sp;

    Animator anim;

    public ObstacleSpawner obstacleSpawner;

    [SerializeField]private AudioSource swim,hit,point;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        FishSwim();
    }
    private void FixedUpdate()
    {
        FishRotation();

    }

    public void FishSwim()
    {
        if (Input.GetMouseButtonDown(0)  && GameManager.gameOver == false)
        {
            swim.Play();
            if (GameManager.gameStarted == false)
            {
                _rb.gravityScale = 4f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x,speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, speed);
            }

        }
    }
    public void FishRotation()
    {
        if (_rb.velocity.y > 0 && maxangle > angle)
        {
            angle = angle + 4;
        }
        else if (_rb.velocity.y < 0 && minangle < angle)
        {
            angle = angle - 2;
        }

        if (touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            score.Scored();
            point.Play();
        }
        else if (collision.CompareTag("Column") && GameManager.gameOver == false)
        {
            FishDieEffect();
            gameManager.GameOver();
        }
    }

    void FishDieEffect()
    {
        hit.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                FishDieEffect();
                gameManager.GameOver();
                GameOver();

            }
            else
            {
                GameOver();
            }
        }
    }
    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0,0,-90);
        sp.sprite = fishDied;
        anim.enabled = false;
    }
}
