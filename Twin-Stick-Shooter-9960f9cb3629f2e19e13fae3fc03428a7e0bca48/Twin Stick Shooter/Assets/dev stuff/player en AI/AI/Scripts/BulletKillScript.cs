using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKillScript : MonoBehaviour {

    int timesHit;
    bool death;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            timesHit = timesHit + 1;
            Destroy(other.gameObject);
        }
    }


    private void Update()
    {
        print(timesHit);
        if(timesHit >= 3)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
        }
    }
}
