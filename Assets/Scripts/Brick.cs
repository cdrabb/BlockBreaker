using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public int maxHits;
    private int timesHit;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
        timesHit++;

        if(timesHit >= maxHits)
            Destroy(gameObject);
    }

    //TODO remove once we can actually win
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
