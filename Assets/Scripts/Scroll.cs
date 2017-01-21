using System.Collections;
using System.Collections;
using UnityEngine;

public class Scroll : MonoBehaviour {
	public float speed = 0f;
	private bool onMovement = false;

	// Use this for initialization
	void Start () {
		
	}

	void playerRun(){
		onMovement = true;
	}

	// Update is called once per frame
	void Update () {
		if (onMovement) {
		}
	}
}
