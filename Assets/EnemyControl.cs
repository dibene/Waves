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
		
			m_Rigidbody.velocity = new Vector2 (moveSpeed, m_Rigidbody.velocity.y);

	}
}
