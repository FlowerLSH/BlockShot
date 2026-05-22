using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite DefaultStand;
    public Sprite Defaultwalk1;
    public Sprite Defaultwalk2;
    public Sprite Defaultjump1;
    public Sprite Defaultjump2;
    public Sprite coolStand;
    public Sprite coolwalk1;
    public Sprite coolwalk2;
    public Sprite cooljump1;
    public Sprite cooljump2;

    public GameObject jen;
    public bool cool;
    Rigidbody2D rigid2D;

    public bool up;
    public bool right;
    public bool stand;
    public bool walk;
    public bool move;
    private float time;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        stand = true;
        walk = false;
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.rigid2D = this.GetComponent<Rigidbody2D>();
        jen = GameObject.Find("BulletJenerator");
        cool = jen.GetComponent<BulletJenerator>().CoolDown;
        right = GetComponent<CircleController>().right;
        move = GetComponent<CircleController>().moving;
        spriteRenderer.flipX = !right;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.flipX = right;
        right = GetComponent<CircleController>().right;
        move = GetComponent<CircleController>().moving;
        cool = jen.GetComponent<BulletJenerator>().CoolDown;
        if (move == true)
        {
            walk = true;
        }
        else
        {
            walk = false;
        }
        if (rigid2D.velocity.y != 0)
        {
            stand = false;
            if (rigid2D.velocity.y > 0)
            {
                if(cool == true)
                {
                    spriteRenderer.sprite = Defaultjump1;
                }
                else
                {
                    spriteRenderer.sprite = cooljump1;
                }
            }
            else
            {
                if (cool == true)
                {
                    spriteRenderer.sprite = Defaultjump2;
                }
                else
                {
                    spriteRenderer.sprite = cooljump2;
                }
            }
        }
        else
        {
            if (walk == true)
            {
                if (count == 0)
                {
                    count = 1;
                }
                time += Time.deltaTime;
                if (time >= 0.35f)
                {
                    count++;
                    time = 0;
                }
                if (count == 1)
                {
                    if (cool == true)
                    {
                        spriteRenderer.sprite = Defaultwalk1;
                    }
                    else
                    {
                        spriteRenderer.sprite = coolwalk1;
                    }
                }
                else if (count == 2)
                {
                    if (cool == true)
                    {
                        spriteRenderer.sprite = Defaultwalk2;
                    }
                    else
                    {
                        spriteRenderer.sprite = coolwalk2;
                    }
                }
                else if (count == 3)
                {
                    count = 0;
                }

            }
            else
            {
                count = 0;
                time = 0;
                if (cool == true)
                {
                    spriteRenderer.sprite = DefaultStand;
                }
                else
                {
                    spriteRenderer.sprite = coolStand;
                }
            }
            stand = true;
        }

        
    }

}

