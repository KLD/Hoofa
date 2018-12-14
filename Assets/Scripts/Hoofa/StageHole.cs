using System;
using System.Collections;
using System.Collections.Generic;
using ChainedRam.Core.Player;
using UnityEngine;

public class StageHole : MonoBehaviour {

	public Action OnFall; 
	
	private void OnTriggerEnter2D(Collider2D other) {
		Player player; 

		if((player=other.gameObject.GetComponent<Player>())!= null){
			OnFall?.Invoke(); 
		}

	}

}
