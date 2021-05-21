using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineMapManager : MonoBehaviour
{

    public PlayerScript player;
    public PlayerScript.timelines desiredTimeline;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
    }




    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.currentTime = desiredTimeline;

        }
    }
}
