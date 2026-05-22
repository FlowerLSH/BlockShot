using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDirector : MonoBehaviour
{
    GameObject TimeText;
    public float TimeCost;
    // Start is called before the first frame update
    void Start()
    {
        this.TimeText = GameObject.Find("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        TimeCost += Time.deltaTime;
        this.TimeText.GetComponent<Text>().text = "Time : " + string.Format("{0:N2}", TimeCost);
    }
}
