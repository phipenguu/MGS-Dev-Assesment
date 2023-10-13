using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    public Transform cannonBarrel;
    public GameObject gemPrefab;
    public float reloadDelay = 1.0f;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    public float currentDelay = 0;

    //private ObjectPool bulletPool;
    //[SerializeField] private int bulletPoolCount = 10;

    private void Awake()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
        //bulletPool = GetComponent<ObjectPool>();
    }

    void Start()
    {
        //bulletPool.Initialize(bullet, bulletPoolCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;

            GameObject gem = Instantiate(gemPrefab);
            gem.transform.position = cannonBarrel.position;
            gem.transform.localRotation = cannonBarrel.rotation;
            gem.GetComponent<GemBehavior>().Initialize();

            foreach (var collider in tankColliders)
            {
                Physics2D.IgnoreCollision(this.gemPrefab.GetComponent<Collider2D>(), collider);
            }
        }
    }
}