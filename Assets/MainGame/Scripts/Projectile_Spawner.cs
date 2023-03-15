using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Spawner : MonoBehaviour
{
    private int _poolSize = 5;
    public GameObject firePoint;
    public GameObject Projectile;

    public float FireRate;

    private Animator anim;

    private List<GameObject> _projectilePool;
    private int _poolIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        InitiliazePool();

        StartCoroutine(FireProjectile());
    }

    private IEnumerator FireProjectile()
    {
        anim.SetTrigger("Fire");
        yield return new WaitForSeconds(FireRate);
        StartCoroutine(FireProjectile());
    }

    public void spawnanimation()
    {
        _projectilePool[_poolIndex].transform.position = firePoint.transform.position;
        _projectilePool[_poolIndex].SetActive(true);
        _poolIndex = (_poolIndex + 1) % _projectilePool.Count;   
    }

    private void OnDestroy()
    {
        // Loop through the object pool and destroy each projectile
        foreach (GameObject projectile in _projectilePool)
        {
            Destroy(projectile);
        }
    }

    private void InitiliazePool()
    {
        // Initialize the pool
        _projectilePool = new List<GameObject>();
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject vfx = Instantiate(Projectile, Vector3.zero, Quaternion.identity);

            vfx.SetActive(false);
            _projectilePool.Add(vfx);
        }
    }
}