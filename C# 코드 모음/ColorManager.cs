using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public TotalStarManager totalstarmanager;
    public Image image;
    public int[] star;
    public int StageNumber;

    // Start is called before the first frame update
    void Start()
    {
        totalstarmanager = GameObject.Find("StageStarManager").GetComponent<TotalStarManager>();
        star = totalstarmanager.star;
        image = this.GetComponent<Image>();
        if(star[StageNumber-1] == 0)
        {
            image.color = new Color(0, 0, 0);
        }
        else if (star[StageNumber - 1] == 1)
        {
            image.color = new Color(1, 1, 0);
        }
        else if (star[StageNumber - 1] == 2)
        {
            image.color = new Color(0, 1, 0);
        }
        else if (star[StageNumber - 1] == 3)
        {
            image.color = new Color(0, 0, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
