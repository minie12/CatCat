using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    float speed;
    float timer;
    Sprite boxTo;

    //sprites
    Sprite boxSpr;
    Sprite catSpr;
    Sprite[] toySpr = new Sprite[3];
    Sprite[] fakeSpr = new Sprite[3];
    Sprite presentSpr;
    Sprite mySprite; // used to determine which sprite the object is

    //related to up&down drag
    bool ableDrag = false; //used to determine whether the object is in the range where items can be dragged
    Vector3 mousePosOn;

    //for cat walking on the shelf
    int walkindex = 0;
    Sprite[] catWalking = new Sprite[2];

    //gameOver
    public GameObject GameOver;
    public GameObject MainGame;

    // gameObject.transform.Find("Cat").gameObject;

    void Start()
    {
        //finding sprite resources
        for (int i = 0; i < 2; i++)
        {
            toySpr[i] = Resources.Load<Sprite>("Sprites/Item/Object_toy_" + (i + 1));
            fakeSpr[i] = Resources.Load<Sprite>("Sprites/Item/Object_fake_" + (i + 1));
            catWalking[i] = Resources.Load<Sprite>("Sprites/Cat_white_" + (i + 1));
        }
        toySpr[2] = Resources.Load<Sprite>("Sprites/Item/Object_toy_" + 3);
        fakeSpr[2] = Resources.Load<Sprite>("Sprites/Item/Object_fake_" + 3);
        catSpr = Resources.Load<Sprite>("Sprites/Item/Object_cat_white");
        presentSpr = Resources.Load<Sprite>("Sprites/fever_score");
        boxSpr = Resources.Load<Sprite>("Sprites/Item/Object_box");
    }

    void Update()
    {
        mySprite = this.GetComponent<SpriteRenderer>().sprite;

        timer = GameObject.Find("UIManager").GetComponent<UIManager>().timer;
        speed = GameObject.Find("UIManager").GetComponent<UIManager>().speed;

        float objPosition_x = gameObject.GetComponent<Transform>().position.x;

        if (objPosition_x < 1.25f)
        {
            gameObject.GetComponent<Transform>().position += new Vector3(speed, 0, 0);
        }

        else if (objPosition_x >= 1.25f && objPosition_x < 4.15f)
        {
            gameObject.GetComponent<Transform>().position += new Vector3(0.008f, -speed, 0);
        }

        else if (objPosition_x >= 4.15f)
        {
            gameObject.GetComponent<Transform>().position += new Vector3(speed, 0, 0);
        }
    }

    void ChooseSprite()
    {
        //choosing which object is in the box
        int i = Random.Range(0, 100);
        Sprite setSprite = catSpr;

        if (0 <= i && i < 48) //Cat
        {
            setSprite = catSpr;
        }
        else if (48 <= i && i < 96) //Toy
        {
            int toy_index = i % 3;
            setSprite = toySpr[toy_index];
        }
        else //Present
        {
            setSprite = presentSpr;
        }

        this.GetComponent<SpriteRenderer>().sprite = setSprite;
    }

    //for the cat to walk (changing sprite constantly)
    IEnumerator WalkingCat()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.45f);
            walkindex = (walkindex + 1) % 2;
            gameObject.GetComponent<SpriteRenderer>().sprite = catWalking[walkindex];
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (mySprite == boxSpr)
        {
            if (other.gameObject.name == "Spawning") //spawn new box
            {
                GameObject.Find("Warehouse").GetComponent<SpawnBox>().CallBox();
            }

            if (other.gameObject.name == "BoxTo") //turning box to toy
            {
                ChooseSprite();
            }
        }

        if (mySprite == catSpr) //if the obj is cat
        {
            if (other.gameObject.name == "CatWalk") //cat walking by itself
            {
                StartCoroutine("WalkingCat");
            }

            if (other.gameObject.name == "Fail") //when object falls
            {
                this.transform.gameObject.SetActive(false);
                MainGame.SetActive(false);
                GameOver.SetActive(true);
            }

            if (other.gameObject.name == "Downward") //when object reach the end of conveyor belt
            {
                this.transform.gameObject.SetActive(false);
                MainGame.SetActive(false);
                GameOver.SetActive(true);
            }
        }

        //for cat&fake (end of the top shelf)
        for (int i = 0; i < 2; i++)
        {
            if (mySprite == catWalking[i])
            {
                if (other.gameObject.name == "Upward") //when object reach the end of shelf
                {
                    this.transform.gameObject.SetActive(false);
                    StopCoroutine("WalkingCat");
                    StopCoroutine("WalkingCat");
                    GameObject.Find("Warehouse").GetComponent<SpawnBox>().OrganizeBox(gameObject);
                }
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (mySprite == toySpr[i]) //cat walking by itself
            {
                //after 90 seconds, fake comes out HAVE TO CHANGE TIMEEE
                if (timer < 10)
                {
                    if (other.gameObject.name == "Fail") //when object falls
                    {
                        this.transform.gameObject.SetActive(false);
                        MainGame.SetActive(false);
                        GameOver.SetActive(true);
                    }

                    if (other.gameObject.name == "Upward") //when object reach the end of shelf
                    {
                        this.transform.gameObject.SetActive(false);
                        MainGame.SetActive(false);
                        GameOver.SetActive(true);
                    }

                    if (other.gameObject.name == "Downward") //when object reach the end of conveyor belt
                    {
                        this.transform.gameObject.SetActive(false);
                        GameObject.Find("Warehouse").GetComponent<SpawnBox>().OrganizeBox(gameObject);
                    }
                }

                else
                {
                    int fake_num = Random.Range(0, 3);//0.33 chance of toy changing to fake

                    if (fake_num == 0) //sprite == fake
                    {
                        if (other.gameObject.name == "ToyTo") //toy to fake
                        {
                            this.GetComponent<SpriteRenderer>().sprite = fakeSpr[i];
                        }
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
                        MainGame.SetActive(false);
                        GameOver.SetActive(true);
                    }

                    if (other.gameObject.name == "Downward") //when object reach the end of conveyor belt
                    {
                        this.transform.gameObject.SetActive(false);
                        GameObject.Find("Warehouse").GetComponent<SpawnBox>().OrganizeBox(gameObject);
                    }
                }
            }

            if (mySprite == fakeSpr[i]) //cat walking by itself
            {

                if (other.gameObject.name == "CatWalk") //cat walking by itself
                {
                    StartCoroutine("WalkingCat");
                }

                if (other.gameObject.name == "Fail") //when object falls
                {
                    this.transform.gameObject.SetActive(false);
                    MainGame.SetActive(false);
                    GameOver.SetActive(true);
                }

                if (other.gameObject.name == "Downward") //when object reach the end of conveyor belt
                {
                    this.transform.gameObject.SetActive(false);
                    MainGame.SetActive(false);
                    GameOver.SetActive(true);
                }
            }
        }
    }

    //when the mouse is clicked 
    void OnMouseDown()
    {
        if (mySprite == presentSpr)
        {
            gameObject.SetActive(false);
        }

        else
        {
            //range that object can be moved
            if (gameObject.GetComponent<Transform>().position.x > -3.7f && gameObject.GetComponent<Transform>().position.x < 1.55f)
            {
                ableDrag = true;
                mousePosOn = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);   //get position of the mouse
            }
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
}
