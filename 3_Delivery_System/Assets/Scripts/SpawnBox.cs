using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    //used to create 8 boxes
    GameObject box;
    Queue<GameObject> boxItem = new Queue<GameObject>();

    Vector3 spawnPlace = new Vector3(-11.5f, 0.42f, 1); //where the object is spawned (on top of the conveyor belt)

    Sprite boxSpr;
    
    void Start ()
    {
        box = GameObject.Find("Box");
        boxSpr = Resources.Load<Sprite>("Sprites/Item/Object_box");

        boxItem.Enqueue(box);

        for (int i = 0; i < 8; i++)
        {
            GameObject obj_box = (GameObject)Instantiate(box);
            obj_box.transform.parent = gameObject.transform;
            boxItem.Enqueue(obj_box);
            obj_box.SetActive(false);
        }

        box.SetActive(false);

        CallBox();       
    }

    //spawning box on top of the conveyor belt
    public void CallBox()
    {
        GameObject box_out = boxItem.Dequeue(); //getting box out of queue
        box_out.GetComponent<SpriteRenderer>().sprite = boxSpr;  //chaning sprite to box (since box come very first)
        box_out.transform.position = spawnPlace; //position = on top of conveyor belt
        box_out.SetActive(true);
    }

    //putting object back into queue
    public void OrganizeBox(GameObject obj)
    {
        boxItem.Enqueue(obj);//큐에 넣어주고
        obj.SetActive(false);//disable
    }
    
    public void StopBox()
    {
        GameObject spawning = GameObject.Find("Spawning");
        spawning.SetActive(false);
    }
}
