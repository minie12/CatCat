using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverTime : MonoBehaviour
{
    int presentNum;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Transform>().position = new Vector3(-8.5f, 0.38f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        float objPosition_x = gameObject.GetComponent<Transform>().position.x;

        if (objPosition_x < 1.55f)
        {
            gameObject.GetComponent<Transform>().position += new Vector3(0.03f, 0, 0);
        }

        else
        {
            gameObject.GetComponent<Transform>().position += new Vector3(0.008f, -0.06f, 0);
        }
    }

    void OnMouseDown()
    {
        /*
        Vector3 MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);	//get position of the mouse
        Vector3 ObjPos = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y, 10); //get position of the object
        */

        GameObject.Find("UIManager").GetComponent<UIManager>().PresentPlus();
        Debug.Log(presentNum);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Fail") //when object falls
        {
            this.transform.gameObject.SetActive(false);
            GameObject.Find("TotalManager").GetComponent<TotalManager>().MainGameOn();
        }
    }
}
