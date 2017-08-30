using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    [SerializeField]
    private AudioClip coinClip;
    [SerializeField]
    private AudioClip lifeClip;
    private CameraScript cameraScript;
    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }

    // Use this for initialization
    void Start () {
        previousPosition = transform.position;
        countScore = true;
	}
	
	// Update is called once per frame
	void Update () {
        CountScore();
	}

    void CountScore()
    {
        if (countScore)
        {
            if(transform.position.y < previousPosition.y)
                scoreCount++;

            previousPosition = transform.position;
            GameplayController.instance.SetScore(scoreCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;

            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetCoinScore(coinCount);

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if(target.tag == "Life")
        {
            lifeCount++;
            scoreCount += 3;

            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetLifeScore(lifeCount);

            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if(target.tag == "Bounds" || target.tag == "Deadly")
            die();
    }

    private void die()
    {
        cameraScript.moveCamera = false;
        countScore = false;


        transform.position = new Vector3(500, 500, 0);
        lifeCount--;

        GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
    }
}
