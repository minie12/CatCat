using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingToy : MonoBehaviour
{
    float speed;
    public Sprite boxTo;
    //related to up&down drag
    bool ableDrag = false; //used to determine whether the object is in the range where items can be dragged
    Vector3 mousePosOn;
    //gameOver
    public GameObject GameOver;
    public GameObject MainGame;

    // gameObject.transform.Find("Cat").gameObject;

    void Update()
    {
        speed = GameObject.Find("UIManager").GetComponent<UIManager>().speed;
        // the object is not on for 30 seconds, thus, no need to keep updating the speed;
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

    //when the mouse is clicked 
    void OnMouseDown()
    {
        //range that object can be moved
        if (gameObject.GetComponent<Transform>().position.x > -1f && gameObject.GetComponent<Transform>().position.x < 0.96f)
        {
            ableDrag = true;
            mousePosOn = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);   //get position of the mouse
        }
    }

    //moving box to upper or down coneyor belt according to the direction of the swipe
    void OnMouseUp()
    {
        Vector3 mousePosOff = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);   //get position of the mouse

        Vector3 direction = mousePosOff - mousePosOn;

        //range that object can be moved
        if (ableDrag == true)
        {
            if (direction.y > 0)    //swipe upward
            {
                gameObject.GetComponent<Transform>().position = new Vector3(4.5f, 3.87f, 0);
            }

            else //swipe downward
            {
                gameObject.GetComponent<Transform>().position = new Vector3(4.5f, -1.45f, 0);
            }

            ableDrag = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "BoxTo") //turning box to toy
        {
            this.GetComponent<SpriteRenderer>().sprite = boxTo; 
        }

        if (other.gameObject.name == "Fail") //when object falls
        {
            this.transform.gameObject.SetActive(false);
            MainGame.SetActive(false);
            GameOver.SetActive(true);
        }

        if (other.gameObject.name == "Upward") //when object reach the end of shelf
        {
            this.transform.gameObject.SetActive(false);
        }

        if (other.gameObject.name == "Downward") //when object reach the end of conveyor belt
        {
            this.transform.gameObject.SetActive(false);
        }
    }
}
