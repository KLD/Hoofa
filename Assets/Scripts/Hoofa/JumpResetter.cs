using ChainedRam.Core.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpResetter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player;
        if ((player = collision.gameObject.GetComponent<Player>()) != null)
        {
            player.CanJump = true; 
        }
    }
}
