using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public float BulletSpeed;
    bool seen = false;
    Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
    }



    // Update is called once per frame
    void Update()
    {
        //if (EventManager.IsPaused() || EventManager.IsFrozen())
        //{
        //    return;
        //}

        transform.position += transform.up * BulletSpeed * Time.deltaTime * EventManager.EventTime;
        if (rend.isVisible)
            seen = true;

        if (seen && !rend.isVisible)
            Destroy(gameObject);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.SendMessage("TakeDamage", 120);
        }

    }
}
