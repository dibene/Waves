using UnityEngine;

[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
public class Player : LivingEntity {

	public float dashSpeed = 5;

	PlayerController controller;
	GunController gunController;
	
	protected override void Start () {
		base.Start ();
	}

	void Awake() {
		controller = GetComponent<PlayerController> ();
		gunController = GetComponent<GunController> ();
		//FindObjectOfType<Spawner> ().OnNewWave += OnNewWave;
	}

	void OnNewWave(int waveNumber) {
		//health = startingHealth;
		//gunController.EquipGun (waveNumber - 1);
	}

	void Update () {
		// Movement input
		float dashInput = Input.GetAxisRaw ("Horizontal");
		controller.Dash (dashInput);

		// Weapon input
		if (Input.GetMouseButton(0)) {
            gunController.Shoot();
		}

		if (transform.position.y < -50) {
			TakeDamage (health);
		}
	}

	public override void Die () {
		AudioManager.instance.PlaySound ("Player Death", transform.position);
		base.Die ();
	}
		
}
