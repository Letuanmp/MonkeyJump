using System;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject objectToDisappear;
    public GameObject Bomb;
    private Vector2 targetPos;
    public float xPlus=3.2f;
    public float speed = 5f;
    private bool isMoving = false;
    private float maxLeft=-4.6f;
    private float maxRight=4.6f;
    private Animator aim;
    private Touch touch;

    AudioManager audioManager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
        aim = GetComponent<Animator>();    
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        // Khởi tạo targetPos với vị trí hiện tại của nhân vật 
        targetPos = rb.position;
        
    }
    private void Update()
    {
        rb.position = Vector2.MoveTowards(rb.position, targetPos, speed * Time.deltaTime);

        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving && transform.position.x > maxLeft )
            {
                LeftArrow();
                audioManager.PlaySFX(audioManager.jump);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving && transform.position.x < maxRight)
            {
               RightArrow();
               audioManager.PlaySFX(audioManager.jump);

            }
        }
        if(rb.position == targetPos)
        {
            isMoving = false;
        }
        aim.SetBool("grounded", !isMoving);
    }

    public void LeftArrow()
    {
        if (!isMoving && transform.position.x > maxLeft)
        {
            targetPos = new Vector2(rb.position.x - xPlus, transform.position.y);
            transform.localScale = new Vector3(0.75f, 0.75f, 1f);
            isMoving = true;
            audioManager.PlaySFX(audioManager.jump);

        }
    }
    public void RightArrow()
    {

        if (!isMoving && transform.position.x < maxRight)
        {
            targetPos = new Vector2(rb.position.x + xPlus, transform.position.y);
            transform.localScale = new Vector3(-0.75f, 0.75f, 1f);
            isMoving = true;
            audioManager.PlaySFX(audioManager.jump);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            Vector2 contactPoint = collision.bounds.center;

            // Kiểm tra nếu player va chạm từ dưới lên
            if (contactPoint.y <= transform.position.y-1f)
            {
                // Player chết
                Destroy(gameObject);
                audioManager.PlaySFX(audioManager.die);
                FindObjectOfType<GameManager>().GameOver();

            }
            else
            {
                // Spawner chết
                Destroy(collision.gameObject);
                FindObjectOfType<GameManager>().SpawnerDeath();
                audioManager.PlaySFX(audioManager.kill);

            }
        }
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            aim.SetBool("Bomb", true);
            if(Bomb)
            Instantiate(Bomb,transform.position,Quaternion.identity);
            audioManager.PlaySFX(audioManager.bomb);
            FindObjectOfType<GameManager>().GameOver();


        }
    }
    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }
    }

}
