using UnityEngine;
using System.Collections;

public class ShadowAI : MonoBehaviour
{

    [SerializeField]
    float Health;
    GameObject player;
    HUDBars HUD;

    GameObject[] enemy;
    [SerializeField] int index = 0;

   // bool chasing = true;

    Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        Health = 50;
        InvokeRepeating("Dying", 1, 1);
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        HUD = player.GetComponent<HUDBars>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Health <= 0)
            Die();

        if (index == enemy.Length)
                Die();
         else if(enemy.Length != 0 && enemy[index] == null)
                index++;
        transform.position = Vector3.SmoothDamp(transform.position, enemy[index].transform.position, ref velocity, 1);

    }

    void TakeDamage(float i)
    {
        Health -= i;
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void Dying()
    {
        Health -= 5;
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Enemy")
        {
            c.SendMessage("TakeDamage", 1);
        }
        if(c.tag == "Soul")
        {
            Destroy(c.gameObject);
            HUD.AddHealth(1);
        }
    }
    void OnTriggerStay2D(Collider2D c)
    {
        if (c.tag == "Enemy")
        {
            c.SendMessage("TakeDamage", 1);
        }
    }
}
