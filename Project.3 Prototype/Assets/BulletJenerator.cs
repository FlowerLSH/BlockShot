using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletJenerator : MonoBehaviour
{
    public int Directionx = 0;
    public int Directiony = 0;
    public int BlockCount = 0;
    public Sprite sprite1;
    public Sprite sprite2;
    public bool Shoot = false;

    private SpriteRenderer spriteRenderer;
    public GameObject bulletPrefab;
    public GameObject Circle;
    public Vector2 CurrentPos;
    public bool CoolDown;
    public float CoolTime = 2.5f;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        CoolDown = true; 
        Circle = GameObject.Find("Circle");
        spriteRenderer = Circle.GetComponent<SpriteRenderer>();
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        BlockShot();
        GameObject[] bulletNumber = GameObject.FindGameObjectsWithTag("Bullet");
        GameObject[] blockNumber = GameObject.FindGameObjectsWithTag("makingBlock");
        BlockCount = bulletNumber.Length + bulletNumber.Length;

        if (CoolDown == false)
        { 
            time += Time.deltaTime;
        }
        if (time >= CoolTime)
        {
            SpriteChange();
            Directionx = 0;
            Directiony = 0;
            time = 0.0f;
            CoolDown = true;
            GameObject.FindWithTag("Bullet").GetComponent<BulletController>().RemoveAll();
        }
    }

    void SpriteChange()
    {
        if (spriteRenderer.sprite == sprite1)
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }
    }

    void Jenerator()
    {
        CurrentPos = Circle.transform.position;
        GameObject go = Instantiate(bulletPrefab) as GameObject;
        go.transform.position = new Vector2(CurrentPos.x, CurrentPos.y);
        BlockCount++;
        Debug.Log("Bullet Jenerated");
    }
    void BlockShot()
    {
        if (Input.GetKeyDown(KeyCode.S) && BlockCount == 0 && CoolDown == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Directiony = 1;
                Jenerator();
                CoolDown = false;
                Shoot = true;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                Directiony = -1;
                Jenerator();
                CoolDown = false;
                Shoot = true;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Directionx = -1;
                Jenerator();
                CoolDown = false;
                Shoot = true;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                Directionx = 1;
                Jenerator();
                CoolDown = false;
                Shoot = true;
            }
            if (Shoot == true)
            {
                SpriteChange();
                Shoot = false;
            }
        }
    }
}
