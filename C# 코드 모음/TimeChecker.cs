using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChecker : MonoBehaviour
{
    public int stageNumber;
    public float star3;
    public float star2;
    public StarManager Manager;
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("StarManager").GetComponent<StarManager>();
        Manager.StageNum = stageNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
