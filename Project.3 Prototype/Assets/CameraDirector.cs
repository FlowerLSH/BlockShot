using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirector : MonoBehaviour
{
    GameObject player;


    void Start()
    {
        this.player = GameObject.Find("Circle");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nowPlayerPos = this.player.transform.position;
        transform.position = new Vector3(nowPlayerPos.x, nowPlayerPos.y, nowPlayerPos.z - 10.0f);
    }
}
