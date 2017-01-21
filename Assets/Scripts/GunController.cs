using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	public Transform weaponHold;
	public Gun[] allGuns;
	Gun equippedGun;

	void Start() {
	}

	public void EquipGun(Gun gunToEquip) {
		if (equippedGun != null) {
			Destroy(equippedGun.gameObject);
		}
		equippedGun = Instantiate (gunToEquip, weaponHold.position,weaponHold.rotation) as Gun;
		equippedGun.transform.parent = weaponHold;
	}

	public void EquipGun(int weaponIndex) {
		EquipGun (allGuns [weaponIndex]);
	}

	public void Shoot() {
        equippedGun.Shoot();
	}

	public float GunHeight {
		get {
			return weaponHold.position.y;
		}
	}

}