﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour {

    private GameObject[] backgrounds;
    private float lastY;

	// Use this for initialization
	void Start () {
        GetBackgroundAndSetLastY();
	}
	
	// Update is called once per frame
	void GetBackgroundAndSetLastY () {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        lastY = backgrounds[0].transform.position.y;

        for (int i = 1; i < backgrounds.Length; i++)
        {
            if(lastY > backgrounds[i].transform.position.y)
                lastY = backgrounds[i].transform.position.y;
        }
	}

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Background")
        {
            if(target.transform.position.y == lastY)
            {
                Vector3 temp = target.transform.position;
                float height = ((BoxCollider2D)target).size.y;

                for (int i = 0; i < backgrounds.Length; i++)
                {
                    if (!backgrounds[i].activeInHierarchy)
                    {
                        temp.y -= height;
                        lastY = temp.y;
                        backgrounds[i].transform.position = temp;
                        backgrounds[i].SetActive(true);
                    }
                }
            }
        }
    }

}
