using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalStarManager : MonoBehaviour
{
    public StarManager Manager;
    public static TotalStarManager totalstarManager = null;
    public int[] star = new int[15];

    private void Awake()
    {
        if (totalstarManager == null)
        {
            totalstarManager = this;
            Debug.Log("1");
        }
        else if (totalstarManager != this)
        {

            Debug.Log("2");
        }
        Debug.Log("3");
        DontDestroyOnLoad(totalstarManager);
    }

    void Start()
    {
        Manager = GameObject.Find("StarManager").GetComponent<StarManager>();
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        Manager = GameObject.Find("StarManager").GetComponent<StarManager>();
        star = Manager.star;
        if(Manager.StageNum != 0 && Manager.StarNumber != 0)
        {
            print("if문 작동");
            star[Manager.StageNum - 1] = Manager.StarNumber;
            Manager.StageNum = 0;
            Manager.StarNumber = 0;
        }
    }
}
