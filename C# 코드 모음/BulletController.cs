using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject makingBlockPrefab;
    public GameObject bullet;

    public float fixNum = 0.5f;
    public float Directionxx;
    public float Directionyy;
    public Vector2 bulletPos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BulletJenerator bullet = GameObject.Find("BulletJenerator").GetComponent<BulletJenerator>();
        this.Directionxx = bullet.Directionx;
        this.Directionyy = bullet.Directiony;
        transform.Translate(Directionxx/240.0f, Directionyy/240.0f,0);

    }

    public void RemoveAll()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            GameObject block = Instantiate(makingBlockPrefab) as GameObject;
            bulletPos = this.transform.position;
            if (Directionxx == 1)
            {
                block.transform.position = new Vector3(bulletPos.x - fixNum, bulletPos.y, 0);
                RemoveAll();
            }
            if (Directionxx == -1)
            {
                block.transform.position = new Vector3(bulletPos.x + fixNum, bulletPos.y, 0);
                RemoveAll();
            }
            if (Directionyy == 1)
            {
                block.transform.position = new Vector3(bulletPos.x, bulletPos.y - fixNum, 0);
                RemoveAll();
            }
            if (Directionyy == -1)
            {
                block.transform.position = new Vector3(bulletPos.x, bulletPos.y + fixNum, 0);
                RemoveAll();
            }
        }
    }
}
