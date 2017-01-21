using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public enum FireMode {Auto, Burst, Single};
	public FireMode fireMode;

	public Transform[] projectileSpawn;
	public Projectile projectile;
	public float msBetweenShots = 100;
	public float muzzleVelocity = 35;
	public int burstCount;
	public int projectilesPerMag;
	public float reloadTime = .3f;

	[Header("Recoil")]
	public Vector2 kickMinMax = new Vector2(.05f,.2f);
	public Vector2 recoilAngleMinMax = new Vector2(3,5);
	public float recoilMoveSettleTime = .1f;
	public float recoilRotationSettleTime = .1f;

	[Header("Effects")]
	public Transform shell;
	public Transform shellEjection;
	public AudioClip shootAudio;
	public AudioClip reloadAudio;

	MuzzleFlash muzzleflash;
	float nextShotTime;

	bool triggerReleasedSinceLastShot;
	int shotsRemainingInBurst;
	int projectilesRemainingInMag;
	bool isReloading;

	Vector3 recoilSmoothDampVelocity;
	float recoilRotSmoothDampVelocity;
	float recoilAngle;

	void Start() {
		muzzleflash = GetComponent<MuzzleFlash> ();
		shotsRemainingInBurst = burstCount;
		projectilesRemainingInMag = projectilesPerMag;
	}

	public void Shoot() {

		if (!isReloading && Time.time > nextShotTime && projectilesRemainingInMag > 0) {
			if (fireMode == FireMode.Burst) {
				if (shotsRemainingInBurst == 0) {
					return;
				}
				shotsRemainingInBurst --;
			}
			else if (fireMode == FireMode.Single) {
				if (!triggerReleasedSinceLastShot) {
					return;
				}
			}

			for (int i =0; i < projectileSpawn.Length; i ++) {
				if (projectilesRemainingInMag == 0) {
					break;
				}
				projectilesRemainingInMag --;
				nextShotTime = Time.time + msBetweenShots / 1000;
				Projectile newProjectile = Instantiate (projectile, projectileSpawn[i].position, projectileSpawn[i].rotation) as Projectile;
				newProjectile.SetSpeed (muzzleVelocity);
			}

			Instantiate(shell,shellEjection.position, shellEjection.rotation);
			muzzleflash.Activate();
			transform.localPosition -= Vector3.forward * Random.Range(kickMinMax.x, kickMinMax.y);
			recoilAngle += Random.Range(recoilAngleMinMax.x, recoilAngleMinMax.y);
			recoilAngle = Mathf.Clamp(recoilAngle, 0, 30);

			AudioManager.instance.PlaySound (shootAudio, transform.position);
		}
	}

}
