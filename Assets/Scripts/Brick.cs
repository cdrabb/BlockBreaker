using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public AudioClip crack;

	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "breakable");
        //Keep track of breakable bricks
        if (isBreakable)
            breakableCount++;

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);
        if (isBreakable)
            HandleHits();
    }

    void HandleHits()
    {
        print("Collision");
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex])
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    //TODO remove once we can actually win
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
