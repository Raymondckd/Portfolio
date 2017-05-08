using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class SoulController : MonoBehaviour {

    Animator anim;
    HUDBars playerStatus;
    GameObject player;
    Vector3 vel;
    float SoulMultipler = 1.0f;
    bool chasing = false;
    bool death = false;
    [SerializeField]
    int LifeTime = 0;
    [SerializeField]
    float HealAmount = 5;

    Stopwatch lifeTimer;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatus = player.GetComponent<HUDBars>();
        vel = new Vector3(0, 0, 0);
        lifeTimer = new Stopwatch();
        lifeTimer.Start();

        anim = GetComponent<Animator>();
        EventManager.OnPause += Pause;
        EventManager.OnUnpause += Unpause;

        anim.SetTrigger("Live");
    }

    // Update is called once per frame
    void Update() {
        if (playerStatus.lastchanceActive)     //If time is less than 1
        {
            SoulMultipler = EventManager.EventTime * 5;
        }
        if (!anim.enabled) {
            return;
        }

        if (lifeTimer.ElapsedMilliseconds >= LifeTime * 1000 && !chasing)
            death = true; ;
        if (chasing) {
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, player.transform.position, ref vel, .5f, 10);
        } else if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= 6) {
            chasing = true;
        } else if (Vector3.Distance(gameObject.transform.position, player.transform.position) >= 7) {
            chasing = false;
        }
        if (death)
            anim.SetTrigger("Kill");


    }

    void KillMe() {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D c) {
        if (c.tag == "Player") {
            playerStatus.AddHealth((int)(HealAmount * SoulMultipler));
            Destroy(gameObject);
        }
    }

    void Pause() {
        if (anim) {
            anim.enabled = false;
        }
        lifeTimer.Stop();
    }

    void Unpause() {
        if (anim) {
            anim.enabled = true;
        }
        lifeTimer.Start();
    }
}
