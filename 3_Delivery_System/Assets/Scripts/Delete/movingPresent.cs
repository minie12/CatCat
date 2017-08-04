using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPresent : MonoBehaviour
{
    //public GameObject present;
    float speed;
    int presentNum;

    public Sprite boxTo;

    void Start()
    {
        // the object is not on for 30 seconds, thus, no need to keep updating the speed
        speed = GameObject.Find("UIManager").GetComponent<UIManager>().speed;
        // for counting the special score(present)
        presentNum = GameObject.Find("UIManager").GetComponent<UIManager>().presentNum;
    }

    void Update()
    {
        float objPosition_x = gameObject.GetComponent<Transform>().position.x;

        if (objPosition_x < 1.25f)
        {
            gameObject.GetComponent<Transform>().position += new Vector3(speed, 0, 0);
        }

        else if (objPosition_x >= 1.25f && objPosition_x < 4.15f)
        {
            gameObject.GetComponent<Transform>().position += new Vector3(0.008f, -0.06f, 0);
        }

        else if (objPosition_x >= 4.15f)
        {
            gameObject.GetComponent<Transform>().position += new Vector3(speed, 0, 0);
        }
    }

    void OnMouseDown()
    {
        presentNum += 1;
        gameObject.transform.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "BoxTo") //turning box to toy
        {
            this.GetComponent<SpriteRenderer>().sprite = boxTo;
        }
    }
}
