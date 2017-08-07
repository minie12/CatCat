using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalManager : MonoBehaviour {
    GameObject mainGame;
    GameObject feverTime;
    GameObject gameOver;
    GameObject gameOverScene;

    Sprite[] gameoverSpr = new Sprite[2];

    // Use this for initialization
    void Start ()
    {
        mainGame = GameObject.Find("MainGame");
        feverTime = GameObject.Find("FeverTime");
        gameOver = GameObject.Find("GameOver");
        for (int i = 0; i < 2; i++)
        {
            gameoverSpr[i] = Resources.Load<Sprite>("Sprites/Item/GameOver_box_" + (i + 1));
        }
        gameOverScene = GameObject.Find("GameOverScene");

        mainGame.SetActive(true);
        feverTime.SetActive(false);
        gameOver.SetActive(false);
    }

    void IsFever()
    {
	mainGame.SetActive(false);
	feverTime.SetActive(true);
    }
	
    public void CatEnd()
    {
        mainGame.SetActive(false);
        gameOver.SetActive(true);
        gameOverScene.GetComponent<SpriteRenderer>().sprite = gameoverSpr[0];
    }

    public void ToyEnd()
    {
        mainGame.SetActive(false);
        gameOver.SetActive(true);
        gameOverScene.GetComponent<SpriteRenderer>().sprite = gameoverSpr[1];
    }
}
