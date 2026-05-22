using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAndGate : MonoBehaviour
{
    public Sprite SwitchspriteOff;
    public Sprite SwitchspriteOn;
    public Sprite GatespriteOff;
    public Sprite GatespriteOn;
    public bool SwitchisActivated = false;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRenderer2;
    public GameObject gate;
    public string gateName = "Gate";
    private Rigidbody2D rigid2d;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gate = GameObject.Find("Gate");
        spriteRenderer2 = gate.GetComponent<SpriteRenderer>();
        rigid2d = gate.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SwitchisActivated == false)
        {
            spriteRenderer.sprite = SwitchspriteOff;
            spriteRenderer2.sprite = GatespriteOff;
            rigid2d.simulated = true;
        }
        else
        {
            spriteRenderer.sprite = SwitchspriteOn;
            spriteRenderer2.sprite = GatespriteOn;
            rigid2d.simulated = false;
        }
    }
}
