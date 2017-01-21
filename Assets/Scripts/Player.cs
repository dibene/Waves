using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
public class Player : LivingEntity {

	public float dashSpeed = 5;

	private PlayerController controller;
	private GunController gunController;
    private bool m_Jump;
    private float dashInput;

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

        // Jump input
        if (!m_Jump) {
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
              Debug.Log("Jump " + m_Jump);
        }

        // Movement input
        dashInput = Input.GetAxisRaw ("Horizontal");
        Debug.Log("Dash " + dashInput);

		// Weapon input
		if (Input.GetMouseButton(0)) {
            gunController.Shoot();
            Debug.Log("Shoot!");
        }

		if (transform.position.y < -50) {
			TakeDamage (health);
            Debug.Log("Falling.. die");
		}
	}



    private void FixedUpdate() {
        controller.Move(dashInput, m_Jump);
        m_Jump = false;
    }

    public override void Die () {
		AudioManager.instance.PlaySound ("Player Death", transform.position);
		base.Die ();
	}
		
}
