using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class TankBehavior : MonoBehaviour
{


    [SerializeField]
    GameObject[] turrets = null, tSpots = null;

    [SerializeField]
    GameObject Top = null, Bottom = null;
    GameObject nlvl;

    TankTop TopScript;

    GameObject Player;
    bool attack, active = false, actuallyDead = false;
    CircleCollider2D circle;
    Stopwatch attackTimer;
    List<GameObject> activeTurrets;
    BaseEnemyStatus status;
    Animator BottomAnim;


    // Use this for initialization
    void Start()
    {
        BottomAnim = Bottom.GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        TopScript = Top.GetComponent<TankTop>();
        circle = GetComponent<CircleCollider2D>();
        attackTimer = new Stopwatch();
        attackTimer.Start();

        status = GetComponent<BaseEnemyStatus>();
        activeTurrets = new List<GameObject>();
        nlvl = GameObject.Find("NextAreaMarker");
        EventManager.OnPause += Pause;
        EventManager.OnUnpause += Unpause;
    }

    void Pause()
    {
        BottomAnim.enabled = false;
    }

    void Unpause()
    {
        BottomAnim.enabled = true;
    }

    void BeStunned()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EventManager.IsPaused())
        {
            return;
        }

        if (!active)
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= 40)
            {
                active = true;
                TopScript.Activate();
            }
            return;
        }
        if (status.Currenthealth <= 0)
            actuallyDead = true;

        if (Vector3.Distance(Player.transform.position, transform.position) <= 20 && activeTurrets.Count <= 7)
        {
            spawnTurret();
        }
        for (int i = 0; i < activeTurrets.Count; i++)
        {
            if (activeTurrets[i] == null)
            {
                activeTurrets.RemoveAt(i);
            }
        }

        if (attackTimer.ElapsedMilliseconds % Random.Range(120, 121) * 1000 == 0)
        {
            if (attack == false)
            {
                TopScript.Attack();
                attack = true;
            }
        }
        else
        {
            attack = false;
        }


    }

    void OnDestroy()
    {
        if (actuallyDead)
        {
            if (nlvl)
            {
                for (int i = 0; i < activeTurrets.Count; i++)
                {
                    Destroy(activeTurrets[i].gameObject);
                }
                nlvl.GetComponent<NextLevel>().SetLevel("Win 2");
                nlvl.GetComponent<NextLevel>().MakeMeWork();
                EventManager.OnPause -= Pause;
                EventManager.OnUnpause -= Unpause;
            }
        }
    }


    void spawnTurret()
    {
        GameObject t = (GameObject)Instantiate(turrets[0], tSpots[Random.Range(0, tSpots.Length)].transform.position, new Quaternion());
        activeTurrets.Add(t);
    }
}
