using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private float speed = 1f;
    private float acceleration = 0.2f;
    private float maxSpeed = 3.2f;

    private float easySpeed = 3.2f;
    private float mediumSpeed = 3.7f;
    private float hardSpeed = 4.2f;

    [HideInInspector]
    public bool moveCamera;

	// Use this for initialization
	void Start () {
        if (GamePreferences.GetEasyDifficulty() == 1)
            maxSpeed = easySpeed;
        else if (GamePreferences.GetMediumDifficulty() == 1)
            maxSpeed = mediumSpeed;
        else if (GamePreferences.GetHardDifficulty() == 1)
            maxSpeed = hardSpeed;

        moveCamera = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(moveCamera)
        {
            MoveCamera();
        }
	}

    void MoveCamera()
    {
        Vector3 temp = transform.position;
        float oldY = temp.y;
        float newY = temp.y - (speed * Time.deltaTime);
        temp.y = Mathf.Clamp(temp.y, oldY, newY);
        transform.position = temp;
        speed += acceleration * Time.deltaTime;

        if (speed > maxSpeed)
            speed = maxSpeed;
    }

}
