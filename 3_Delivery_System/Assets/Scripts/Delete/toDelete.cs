using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toDelete : MonoBehaviour 
{
	public GameObject Cat;
    public GameObject[] Toy; //since there are 3 kinds of toy, making it into a array
    public GameObject[] Fake; //same as toy on top
    public GameObject Present;

    public Sprite box;

    private static GameObject[] boxItem;
    Vector3 spawnPlace = new Vector3(-8.9f, 0.42f, 1); //where the object is spawned (on top of the conveyor belt)

    float timer; //parameter from UIManager
    float speed; //parameter from UIManager
    float waitTime; //for setting the spawning time
    public GameObject Warehouse; //parent of Items //to organize the Items 

	void Start ()
	{
        boxItem = new GameObject[12]; //3 toys, 3 cats, 3 presents, 3 fakes --> total 12 item
        AddList ();

        //deactivating original items 
        Cat.SetActive(false);
        Present.SetActive(false);
        for (int i = 0; i<3; i++ ) //since fake&toy have 3 items
        {
            Fake[i].SetActive(false);
            Toy[i].SetActive(false);
        }

        StartCoroutine(CallBox()); 
	}

    void Update()
    {
        timer = GameObject.Find("UIManager").GetComponent<UIManager>().timer;
        speed = GameObject.Find("UIManager").GetComponent<UIManager>().speed; //to change spawn time
    }

    void AddList()
	{
		for (int i = 0; i<12; i ++) //creating 3 new objects under the Warehouse folder
		{
            if (i < 3)
            {
                boxItem[i] = Instantiate(Cat, spawnPlace, Quaternion.identity) as UnityEngine.GameObject;
            }
            else if (i < 6)
            {
                boxItem[i] = Instantiate(Toy[i-3], spawnPlace, Quaternion.identity) as UnityEngine.GameObject;
            }
            else if (i < 9)
            {
                boxItem[i] = Instantiate(Fake[i-6], spawnPlace, Quaternion.identity) as UnityEngine.GameObject;
            }
            else
            {
                boxItem[i] = Instantiate(Present, spawnPlace, Quaternion.identity) as UnityEngine.GameObject;
            }

			boxItem [i].SetActive (false);
            boxItem[i].transform.parent = Warehouse.transform;
        }
	}

	IEnumerator CallBox() 
	{
		//choosing which object is in the box
		int i = Random.Range (0, 100);
        GameObject MyItem = Cat;

        //probabilty before 90s = 48:48:4 (Cat:toy:Present)
        if (timer < 20)
        {
            if (0 <= i && i < 48) //Cat
            {
                for (int j = 0; j < 3; j++)
                {
                    if (boxItem[j].activeSelf == false)
                    {
                        MyItem = boxItem[j];
                        break;
                    }
                }
            }
            else if (48 <= i && i < 96) //Toy
            {
                for (int j = 3; j < 6; j++)
                {
                    if (boxItem[j].activeSelf == false)
                    {
                        MyItem = boxItem[j];
                        break;
                    }
                }
            }
            else //Present
            {
                for (int j = 9; j < 12; j++)
                {
                    if (boxItem[j].activeSelf == false)
                    {
                        MyItem = boxItem[j];
                        break;
                    }
                }
            }
        }

        //probabilty after 90s = 40:40:16:4 (Cat:toy:Fake:Present)
        else
        {
            if (0 <= i && i < 40) //Cat
            {
                for (int j = 0; j < 3; j++)
                {
                    if (boxItem[j].activeSelf == false)
                    {
                        MyItem = boxItem[j];
                        break;
                    }
                }
            }
            else if (40 <= i && i < 80) //Toy
            {
                for (int j = 3; j < 6; j++)
                {
                    if (boxItem[j].activeSelf == false)
                    {
                        MyItem = boxItem[j];
                        break;
                    }
                }
            }
            else if (80 <= i && i < 96) //Toy
            {
                for (int j = 6; j < 9; j++)
                {
                    if (boxItem[j].activeSelf == false)
                    {
                        MyItem = boxItem[j];
                        break;
                    }
                }
            }
            else //Present
            {
                for (int j = 6; j <= 9; j++)
                {
                    if (boxItem[j].activeSelf == false)
                    {
                        MyItem = boxItem[j];
                        break;
                    }
                }
            }
        }

        MyItem.GetComponent<Transform>().position = spawnPlace;
        //box.GetComponent<Transform>().scale = new Vector3 (0.9f, 0.9f, 1);
        MyItem.GetComponent<SpriteRenderer>().sprite = box;
        MyItem.SetActive (true);

        waitTime = 6.5f - 150*speed;
        yield return new WaitForSeconds(waitTime);

        StartCoroutine (CallBox());
	} 
		
}
