using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearDirector : MonoBehaviour
{
    public float star3;
    public float star2;
    public string star1;
    public Text star3Text;
    public Text star2Text;
    public Text star1Text;
    public Text ClearTime;
    public string starNumber;
    public float cleartime;
    public StarManager Manager;
    public float fill;
    public GameObject star;
    public int stageNum;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("StarManager").GetComponent<StarManager>();
        star3 = Manager.star3;
        star2 = Manager.star2;
        star1 = "클리어";
        stageNum = Manager.StageNum;
        cleartime = Manager.clearTime;
        if(cleartime <= star3)
        {
            starNumber = "3";
        }
        else if(cleartime <= star2)
        {
            starNumber = "2";
        }
        else
        {
            starNumber = "1";
        }
        fill = int.Parse(starNumber) * 0.333f;
        star = GameObject.Find("Star");
        star.GetComponent<Image>().fillAmount = fill;

        star3Text.text = "별 3개 : " + star3 + "초 이내";
        star2Text.text = "별 2개 : " + star2 + "초 이내";
        star1Text.text = "별 1개 : " + star1;
        ClearTime.text = "클리어 타임 : " + cleartime;
        Manager.StarNumber = int.Parse(starNumber);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
