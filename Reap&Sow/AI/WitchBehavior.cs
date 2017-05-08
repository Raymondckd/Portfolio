using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.SceneManagement;


public class WitchBehavior : MonoBehaviour
{

    [SerializeField]
    GameObject fireball = null, particle = null;
    [SerializeField]
    GameObject fireSpot = null;
    [SerializeField]
    GameObject[] corners = null;

    GameObject player, clone;
    HUDBars PStat;

    Animator anim;
    SpriteRenderer spriterend;
    Color col;
    BaseEnemyStatus status;

    GameObject nlvl;
    //States
    bool attacking, moving, exhausted, chargeAtk = false;
    bool isCorner = false;
    bool rage = false;
    [SerializeField]
    float timeStep = 6.0f, exhaustStep = 30.0f, chargeTransition = 10.0f;
    string LevelName;
    public bool IsClone = false;

    [SerializeField]
    int index, prevIndex;
    Vector3 velocity;
    Quaternion temprot;

    int times = 0;

    // Use this for initialization
    void Start()
    {
        spriterend = GetComponent<SpriteRenderer>();
        col = spriterend.color;
        anim = GetComponent<Animator>();
        status = GetComponent<BaseEnemyStatus>();
        player = GameObject.FindGameObjectWithTag("Player");
        velocity = new Vector3();
        index = Random.Range(1, int.MaxValue) % 4;
        status.Currenthealth = status.Maxhealth;
        nlvl = GameObject.Find("NextAreaMarker");
        PStat = player.GetComponent<HUDBars>();
        LevelName = SceneManager.GetActiveScene().name;
        EventManager.OnPause += Pause;
        EventManager.OnUnpause += Unpause;
    }

    void Pause()
    {
        anim.enabled = false;
    }

    void Unpause()
    {
        anim.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventManager.IsPaused())
        {
            return;
        }

        if (!rage)
        {
            if (!isCorner)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward, corners[index].transform.position - transform.position);
                transform.position = Vector3.SmoothDamp(transform.position, corners[index].transform.position, ref velocity, 0.8f);
                moving = true;

                if (Mathf.Abs(transform.position.x - corners[index].transform.position.x) <= 1f && Mathf.Abs(transform.position.y - corners[index].transform.position.y) <= 1f)
                {
                    isCorner = true;
                    moving = false;
                }
            }
            else if (Vector3.Distance(player.transform.position, transform.position) <= 10 && !attacking)
            {
                SoundManager.PlaySFX("WitchWhoosh");
                prevIndex = index;
                do
                {
                    index = Random.Range(1, int.MaxValue) % 4;
                } while (index == prevIndex);
                isCorner = false;
            }
            else {
                attacking = true;
                if (!moving)
                    Attack();
            }

            if (status.Currenthealth <= status.Maxhealth / 2)
            {
                rage = true;
                Instantiate(particle, transform.position, transform.rotation);
                transform.localScale = new Vector3(20, 20, 1);
                attacking = true;
                moving = true;
                clone = (GameObject)Instantiate(gameObject);
                clone.GetComponent<WitchBehavior>().CloneMade();
                clone.GetComponent<WitchBehavior>().IsClone = true;
                clone.GetComponent<SpriteRenderer>().color = new Color(clone.GetComponent<SpriteRenderer>().color.r, clone.GetComponent<SpriteRenderer>().color.g, clone.GetComponent<SpriteRenderer>().color.b, clone.GetComponent<SpriteRenderer>().color.a / 2);
            }
        }
        else if (rage)
        {

            //transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref velocity, .5f);
            if (attacking && moving)
            {
                Attack();
                attacking = false;
                chargeAtk = true;
                transform.rotation = temprot;
            }
            else if (anim.GetBool("rage"))
            {
                chargeTransition -= .2f;
                if (chargeTransition <= 0)
                {
                    anim.SetBool("rage", false);
                    anim.SetBool("charge", true);
                    chargeTransition = 10.0f;
                }
            }
            else if (!anim.GetBool("rage") && (chargeAtk && !(timeStep <= 0)))
            {
                transform.position += transform.up * 10 * Time.deltaTime;
                timeStep -= .1f;
            }
            else if (times <= 6 && timeStep <= 0)
            {
                times += 1;
                timeStep = 6.0f;
            }
            else if (chargeAtk && timeStep <= 0 && times >= 6)
            {
                chargeAtk = false;
                exhausted = true;
                timeStep = 6.0f;
                times = 0;
                anim.SetBool("charge", false);
                anim.SetBool("exhaustion", true);
            }
            else if (!chargeAtk && exhaustStep > 0)
            {
                exhaustStep -= .1f;
                moving = false;
            }
            else if (exhausted && exhaustStep <= 0)
            {
                moving = true;
                attacking = true;
                exhausted = false;
                anim.SetBool("exhaustion", false);
                exhaustStep = 30.0f;
            }
        }


    }

    void Attack()
    {
        if (rage)
        {
            temprot = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
            anim.SetBool("rage", true);
        }
        else {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
            anim.SetTrigger("normal");
        }
    }

    void Shoot()
    {
        Instantiate(fireball, fireSpot.transform.position, fireSpot.transform.rotation);
    }

    void Transition()
    {
        attacking = false;
    }

    void OnDestroy()
    {
        if (!IsClone && nlvl!=null )
        {
            nlvl.GetComponent<NextLevel>().SetLevel("Win");
            nlvl.GetComponent<NextLevel>().MakeMeWork();
        }
        if (SceneManager.GetActiveScene().name != LevelName)
        {
            SoundManager.PlaySFX("WitchDeath");
        }
        EventManager.OnPause -= Pause;
        EventManager.OnUnpause -= Unpause;
        //ChangeScene("Win");
        if (clone != null)
        {
            Destroy(clone);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player" && rage)
        {
            PStat.TakeDamage(60);
        }
    }

    public void CloneMade()
    {
        rage = true;
        Instantiate(particle, transform.position, transform.rotation);
        transform.localScale = new Vector3(20, 20, 1);
        attacking = true;
        moving = true;
        status = GetComponent<BaseEnemyStatus>();
        status.Currenthealth = (status.Maxhealth / 2) - 1;
    }

    void BeStunned(int frames)
    { }
}
