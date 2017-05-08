using UnityEngine;
using System.Collections;

public class Shadow : BasePowerUp {

    [SerializeField]
    GameObject shadow = null;

    public override void Action()
    {
        Invoke("Spawn", .2f);
        Invoke("KillMe", .3f);
    }

    void Spawn()
    {
        Instantiate(shadow, transform.position, new Quaternion());
    }

    void KillMe()
    {

        Destroy(gameObject);
    }
}
