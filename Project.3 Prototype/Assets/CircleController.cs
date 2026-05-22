using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleController : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip sound;
    // Start is called before the first frame update
    Rigidbody2D rigid2D;
    public GameObject bulletPrefab;
    public StarManager Manager;
    public float jumpforce = 560.0f;
    public int DoubleJumpCount = 0;
    public int BlockCount = 0;
    public float MovingSpeed = 3.0f;
    private float DelayTime = 0.0f;
    public float DownSpeed;
    public float ClearTime;
    public bool Goal = false;
    private SpriteRenderer spriteRenderer;
    public bool right;
    public bool moving;

    Vector2 CurrentPos;

    void Start()
    {
        Goal = false;
        DownSpeed = 500.0f;
        this.rigid2D = GetComponent<Rigidbody2D>();
        CurrentPos = rigid2D.gameObject.transform.position;
        Debug.Log(CurrentPos);
        SwitchAndGate OnOff = GameObject.Find("Switch").GetComponent<SwitchAndGate>();
        this.audiosource = this.gameObject.AddComponent<AudioSource>();
        this.audiosource.clip = this.sound;
        this.audiosource.loop = false;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            TimerDirector timer = GameObject.Find("Timer").GetComponent<TimerDirector>();
            Debug.Log(timer.TimeCost);
            ClearTime = timer.TimeCost;
            Manager = GameObject.Find("StarManager").GetComponent<StarManager>();
            Manager.clearTime = ClearTime;
            Debug.Log("골");
            timer.TimeCost = 0;
            SceneManager.LoadScene("StageClear");
        }

        else if(other.CompareTag("Floor") || other.CompareTag("makingBlock"))
        {
            this.DoubleJumpCount = 0;
        }

        else if(other.CompareTag("Switch"))
        {
            SwitchAndGate OnOff = GameObject.Find("Switch").GetComponent<SwitchAndGate>();
            if(OnOff.SwitchisActivated == false)
            {
                OnOff.SwitchisActivated = true;
            }
        }
    }

    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && DoubleJumpCount < 2)
        {
            this.audiosource.Play();
            if (Mathf.Abs(rigid2D.velocity.y) <= 0.05f)
            {
                DoubleJumpCount++;
            }
            else
            {
                DoubleJumpCount++;
                DoubleJumpCount++;
            }
            rigid2D.velocity = new Vector2(0, 0.000001f);
         
            this.rigid2D.AddForce(transform.up * this.jumpforce);
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moving = true;
            right = true;
            transform.position = new Vector2(transform.position.x - MovingSpeed * Time.deltaTime, transform.position.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            right = false;
            moving = true;
            transform.position = new Vector2(transform.position.x + MovingSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            moving = false;
        }
    }
}
