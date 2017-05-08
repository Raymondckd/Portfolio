using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour
{



    [SerializeField]
    bool  doesDrop = false, flicker = false;

    bool isBroken;
    [SerializeField]
    int hp;

    [SerializeField]
    GameObject[] itemDrop = null;

    Animator anim;
    SpriteRenderer rend;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        EventManager.OnPause += Pause;
        EventManager.OnUnpause += Unpause;
    }

    void Pause() {
        anim.enabled = false;
    }

    void Unpause() {
        anim.enabled = true;
    }

    void OnDestroy() {
        EventManager.OnPause -= Pause;
        EventManager.OnUnpause -= Unpause;
    }
    // Update is called once per frame
    void Update()
    {

        if (!isBroken)
        {
            if (hp <= 0)
            {
                isBroken = true;
                //Trigger broken animation
                anim.SetTrigger("broke");
                anim.SetBool("broken", true);
                GetComponent<Collider2D>().enabled = false;
            }
        }
        if(isBroken && flicker)
        {
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, rend.color.a - .01f);
            if (rend.color.a <= 0.001f)
                Destroy(gameObject);
        }

    }
    GameObject Choose()
    {
        GameObject drop = null;

        int index = Random.Range(0, itemDrop.Length);
        if (index != itemDrop.Length)
            drop = itemDrop[index];

        return drop;
    }
    void Drop()
    {
        GameObject temp = Choose();
        if(doesDrop && temp != null)
        {
            Instantiate(temp, transform.position, new Quaternion());
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Attack")
        {
            if (hp > 0)
            {
                hp -= 1;
            }
        }
    }

    void KillMe()
    {
        Destroy(gameObject);
    }
}
