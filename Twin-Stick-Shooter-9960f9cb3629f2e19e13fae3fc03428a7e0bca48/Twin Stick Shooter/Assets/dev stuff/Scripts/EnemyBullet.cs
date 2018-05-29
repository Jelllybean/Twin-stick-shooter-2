using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour {

    [SerializeField]
    private HealthStat health;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            //Destroy(other.gameObject);
            //SceneManager.LoadScene("StartScreen (proto)");
            //PlayerPrefs.SetInt("TimesDied", PlayerPrefs.GetInt("TimesDied") + 1);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
