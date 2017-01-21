using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
	public float moveSpeed;

	private Rigidbody2D m_Rigidbody;         

	// Use this for initialization
	void Start () {
		m_Rigidbody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		float omega = 1f;
		//float movimiento = (1 /Mathf.PI *( Mathf.Sin(omega*Time.time) + 1/3 * Mathf.Sin(3*omega*Time.time) + 1/5 * Mathf.Sin(5*omega*Time.time) ) );
		//m_Rigidbody.position = new Vector2 (Time.time,  movimiento );
		//m_Rigidbody.velocity = new Vector2 (moveSpeed,  Mathf.Abs(Mathf.Sin(2*Time.time)) );
	}
}
