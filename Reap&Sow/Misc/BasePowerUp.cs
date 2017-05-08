using UnityEngine;
using System.Collections;
using System.Diagnostics;



public class BasePowerUp : MonoBehaviour
{

    [SerializeField]
    int lifeTime = 0;
    public GameObject player;
    [SerializeField]
    string collect = "", death = "", living = "";
   
    Stopwatch lifeTimer;
    bool allgood = true;

    // Use this for initialization
    void Start()
    {

        lifeTimer = new Stopwatch();
        lifeTimer.Start();
        SoundManager.PlaySFX(living);
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        if ((lifeTimer.ElapsedMilliseconds >= lifeTime * 1000) && allgood)
        {
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            SoundManager.PlaySFX(death);
            Destroy(gameObject);
        }

    }

    public virtual void Action()
    {

    }


    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            Action();
            SoundManager.PlaySFX(collect);
            allgood = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
