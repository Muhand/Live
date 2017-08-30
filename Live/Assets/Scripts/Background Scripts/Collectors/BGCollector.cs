using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Background")
            target.gameObject.SetActive(false);
    }
}
