using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {
/*
    //sprites
    Sprite catSpr;
    Sprite[] toySpr = new Sprite[3];
    Sprite[] fakeSpr = new Sprite[3];
    Sprite presentSpr;
    Sprite mySprite; // used to determine which sprite the object is

    //for cat walking on the shelf
    int walkindex = 0;
    Sprite[] catWalking;

    void Start ()
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

        mySprite = this.GetComponent<SpriteRenderer>().sprite;
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

    void AfterBox() //for fake
    {
        for (int i = 0; i < 3; i++)
        {
            if (mySprite = fakeSpr[i]) //cat walking by itself
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

                if (other.gameObject.name == "Upward") //when object reach the end of shelf
                {
                    this.transform.gameObject.SetActive(false);
                    StopCoroutine("WalkingCat");
                    GameObject.Find("Warehouse").GetComponent<SpawnBox>().OrganizeBox(gameObject);
                }

                if (other.gameObject.name == "Downward") //when object reach the end of conveyor belt
                {
                    this.transform.gameObject.SetActive(false);
                    MainGame.SetActive(false);
                    GameOver.SetActive(true);
                }
            }
        }
    } */
}
