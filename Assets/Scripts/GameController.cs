using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {
	public GameObject enemyBlue;
	public GameObject enemyRed;
	public GameObject enemyGreen;
	public Vector2 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waverWait;
	//public GUIText scoreText;
	private int score;
	void Start ()
	{	
		//score = 0;
		//UpdateScore ();
		StartCoroutine(SpawnWaves ());
	}

	IEnumerator SpawnWaves()
	{	
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {				
				Vector3 spawnPosition = new Vector2 (spawnValues.x, spawnValues.y);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemyGreen, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waverWait);
		}
	}

//	public void AddScore(int newScoreValue){
//		score += newScoreValue;
//		UpdateScore ();
//	}

//	void UpdateScore(){
//		scoreText.text = "Score: " + score;
//	}

}
