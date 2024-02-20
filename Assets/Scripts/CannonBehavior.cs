using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    public Transform cannonBarrel;
    [SerializeField] private GameObject brownGem;
    [SerializeField] private GameObject redGem;
    [SerializeField] private GameObject greenGem;
    [SerializeField] private GameObject yellowGem;
    [SerializeField] private GameObject whiteGem;
    [SerializeField] private GameObject blueGem;
    public float reloadDelay = 1.0f;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    public float currentDelay = 0;
    private float gemColorBase = 100/6;

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
            int random = Random.Range(0, 101);
            GameObject gem = new GameObject();

            if (random <= gemColorBase)
            {
                gem = Instantiate(brownGem);
            }
            else if (random > gemColorBase && random <= gemColorBase * 2)
            {
                gem = Instantiate(redGem);
            }
            else if (random > gemColorBase * 2 && random <= gemColorBase * 3)
            {
                gem = Instantiate(greenGem);
            }
            else if (random > gemColorBase * 3 && random <= gemColorBase * 4)
            {
                gem = Instantiate(yellowGem);
            }
            else if (random > gemColorBase * 4 && random <= gemColorBase * 5)
            {
                gem = Instantiate(whiteGem);
            }
            else if (random > gemColorBase * 5 && random <= gemColorBase * 6)
            {
                gem = Instantiate(blueGem);
            }

            gem.transform.position = cannonBarrel.position;
            gem.transform.localRotation = cannonBarrel.rotation;
            gem.GetComponent<GemBehavior>().Initialize();

            foreach (var collider in tankColliders)
            {
                Physics2D.IgnoreCollision(this.brownGem.GetComponent<Collider2D>(), collider);
                Physics2D.IgnoreCollision(this.redGem.GetComponent<Collider2D>(), collider);
                Physics2D.IgnoreCollision(this.greenGem.GetComponent<Collider2D>(), collider);
                Physics2D.IgnoreCollision(this.yellowGem.GetComponent<Collider2D>(), collider);
                Physics2D.IgnoreCollision(this.whiteGem.GetComponent<Collider2D>(), collider);
                Physics2D.IgnoreCollision(this.blueGem.GetComponent<Collider2D>(), collider);
            }
        }
    }
}