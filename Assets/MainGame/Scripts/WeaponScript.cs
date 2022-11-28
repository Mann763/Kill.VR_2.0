using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
	[Header("Prefab Refrences")]
	public GameObject bulletPrefab;
	public GameObject muzzleFlashPrefab;

	[Header("Location Refrences")]
	[SerializeField] private Transform barrelLocation;

	[Header("Settings")]
	[Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
	[Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;

    public float shootForce, upwardForce;

	public AudioClip Hit_Sound;
	public ParticleSystem HitEffect;

    private void Start()
    {
		if (barrelLocation == null)
			barrelLocation = transform;
	}

    public void Shoot()
	{
		if (muzzleFlashPrefab)
		{
			//Create the muzzle flash
			GameObject tempFlash;
			tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

			//Destroy the muzzle flash effect
			Destroy(tempFlash, destroyTimer);
		}

		//cancels if there's no bullet prefeb
		if (!bulletPrefab)
		{ return; }

		// Create a bullet and add force on it in direction of the barrel
		Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

	}
}
