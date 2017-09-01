using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds;
    [SerializeField]
    private GameObject[] collectables;
    private float distanceBetweenClouds = 2.25f;
    private float minX, maxX;
    private float lastCloudPositionY;
    private float controlX;
    private GameObject player;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player");
        controlX = 0f;
        SetMinAndMaxX();
        CreateClouds();

        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].SetActive(false);
        }
    }

    private void Start()
    {
        PositionThePlayer();
    }

    // Update is called once per frame
    void SetMinAndMaxX () {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x-0.5f;               // subtract 0.5 so in case the coud spawns outside the camera then we want to see half of it at least
        minX = -bounds.x + 0.5f;

	}

    void Shuffle(GameObject[] cloudsToShuffle)
    {
        for (int i = 0; i < cloudsToShuffle.Length; i++)
        {
            //Create temp as a gameobject based on current index
            //Create a random number ranging from 0 to the length of the array
            //replace the value of cloudsToShuffle of index i to be the value of the cloudsToShuffle of the random index
            //Put back the temp into the random position
            //This way we just swaped values

            GameObject temp = cloudsToShuffle[i];
            int random = Random.Range(i, cloudsToShuffle.Length);
            cloudsToShuffle[i] = cloudsToShuffle[random];
            cloudsToShuffle[random] = temp;

            //If we have more than 1 cloud
            if(i>0)
            {
                //Check if the previous cloud is deadly or not, if it's deadly then replace it with the next one, 
                //this way we avoid any 2 deadly clouds after each other
                if(cloudsToShuffle[i-1].tag == "Deadly" && cloudsToShuffle[i].tag == "Deadly")
                {
                    temp = cloudsToShuffle[i];
                    cloudsToShuffle[i] = cloudsToShuffle[i+1];
                    cloudsToShuffle[i + 1] = temp;
                }
            }

        }
    }

    void CreateClouds()
    {
        Shuffle(clouds);
        float positionY = 0f;
        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;
            
            if(controlX == 0)
            {
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;
            }
            else if(controlX == 1)
            {
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }

            lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;
            positionY -= distanceBetweenClouds;
        }
    }

    void PositionThePlayer()
    {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for (int i = 0; i < darkClouds.Length; i++)
        {
            if(darkClouds[i].transform.position.y == 0f)
            {
                Vector3 t = darkClouds[i].transform.position;
                darkClouds[i].transform.position = new Vector3(cloudsInGame[0].transform.position.x, 
                                                               cloudsInGame[0].transform.position.y,
                                                               cloudsInGame[0].transform.position.z);

                cloudsInGame[0].transform.position = t;
            }
        }

        Vector3 temp = cloudsInGame[0].transform.position;
        for (int i = 1; i < cloudsInGame.Length; i++)
        {
            if(temp.y < cloudsInGame[i].transform.position.y)
                temp = cloudsInGame[i].transform.position;
        }
        temp.y += 0.8f;
        player.transform.position = temp;

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Cloud" || target.tag == "Deadly")
        {
            if(target.transform.position.y == lastCloudPositionY)
            {
                Shuffle(clouds);
                Shuffle(collectables);

                Vector3 temp = target.transform.position;

                for (int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy)
                    {
                        if (controlX == 0)
                        {
                            temp.x = Random.Range(0.0f, maxX);
                            controlX = 1;
                        }
                        else if (controlX == 1)
                        {
                            temp.x = Random.Range(0.0f, minX);
                            controlX = 2;
                        }
                        else if (controlX == 2)
                        {
                            temp.x = Random.Range(1.0f, maxX);
                            controlX = 3;
                        }
                        else if (controlX == 3)
                        {
                            temp.x = Random.Range(-1.0f, minX);
                            controlX = 0;
                        }

                        temp.y -= distanceBetweenClouds;

                        lastCloudPositionY = temp.y;

                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

                        int random = Random.Range(0, collectables.Length);

                        if (clouds[i].tag != "Deadly")
                        {
                            if (!collectables[random].activeInHierarchy)
                            {
                                Vector3 temp2 = clouds[i].transform.position;
                                temp2.y += 0.7f;

                                if(collectables[random].tag == "Life")
                                {
                                    if(PlayerScore.lifeCount < 2)
                                    {
                                        collectables[random].transform.position = temp2;
                                        collectables[random].SetActive(true);
                                    }
                                }
                                else
                                {
                                    collectables[random].transform.position = temp2;
                                    collectables[random].SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

} // CloudSpawner
