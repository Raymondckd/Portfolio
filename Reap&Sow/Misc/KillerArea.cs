using UnityEngine;
using System.Collections;

public class KillerArea : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Invoke("KillMe", 2);
	}
	
	

    void KillMe()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Enemy")
        {
            c.SendMessage("TakeDamage", 200);
        }
    }
    void OnTriggerStay2D(Collider2D c)
    {
        if (c.tag == "Enemy")
        {
            c.SendMessage("TakeDamage", 200);
        }
    }
    void OnTriggerExit2D(Collider2D c)
    {
        if (c.tag == "Enemy")
        {
            c.SendMessage("TakeDamage", 200);
        }
    }
}
