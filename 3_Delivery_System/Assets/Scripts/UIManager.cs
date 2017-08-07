using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    // for score
    public float timer = 0;
	public Text scoreText;
    int seconds;
    // for present
	int mainPresent;
	int feverPresent;
    public Text presentText;
    public int presentNum = 0;
    // for speed
    public float speed;
    //FeverTime
    public GameObject FeverTime;
    public GameObject MainGame;

    // Use this for initialization
    void Start ()
    {
        speed = 0.045f;
        StartCoroutine(SpeedSetting());
    }
	
	// Update is called once per frame
	void Update()
	{
        //for setting time = score
        timer += Time.deltaTime;
		seconds = Mathf.FloorToInt(timer);
		scoreText.text = seconds.ToString();

        //for setting speical score
        presentText.text = presentNum.ToString();
    }

    //increasing speed every 30 seconds
    IEnumerator SpeedSetting()
    {
        if (speed < 0.1f)
        {
            yield return new WaitForSeconds(30);
            speed += 0.002f;
        }

        StartCoroutine(SpeedSetting());
    }
	
	public void PresentPlus()
	{
		presentNum += 1;
	}
}
