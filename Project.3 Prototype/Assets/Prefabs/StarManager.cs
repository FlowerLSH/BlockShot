using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public float clearTime;
    public float star3 = 10.0f;
    public float star2 = 30.0f;
    public float star1;
    public int StarNumber;
    public CircleController circle;
    public TimeChecker time;
    public ClearDirector cleardirector;
    public static StarManager starManager = null;
    public int StageNum;
    public int StageNumber;
    public int[] star = new int[15];
    public TotalStarManager totalstarmanager;

    void Awake()
    {
        if(starManager == null)
        {
            starManager = this;
            Debug.Log("1");
        }
        else if(starManager != this)
        {
            
            Debug.Log("2");
        }
        Debug.Log("3");
        DontDestroyOnLoad(starManager);
    }
    // Start is called before the first frame update
    void Start()
    {
        cleardirector = GameObject.Find("ClearManager").GetComponent<ClearDirector>();
        circle = GameObject.Find("Circle").GetComponent<CircleController>();
        totalstarmanager = GameObject.Find("StageStarManager").GetComponent<TotalStarManager>();
    }

    // Update is called once per frame
    void Update()
    {
        time = GameObject.Find("StarTime").GetComponent<TimeChecker>();
        star3 = time.star3;
        star2 = time.star2;

        //StarNumber = int.Parse(cleardirector.starNumber);
        StageNumber = cleardirector.stageNum;
    }
}
