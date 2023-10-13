using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehavior : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Initialize()
    {
        rigidbody2D.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void DisableObject()
    {
        rigidbody2D.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with " + collision.name);

        //var damagable = collision.GetComponent<Damageable>();
        //if (damagable != null)
        //{
        //    damagable.Hit();
        //}

        DisableObject();
    }
}