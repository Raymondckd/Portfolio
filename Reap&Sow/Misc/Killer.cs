using UnityEngine;
using System.Collections;

public class Killer : BasePowerUp {

    [SerializeField]
    GameObject effect = null, effect2 = null, effect3 = null;

    public override void Action()
    {
        Instantiate(effect, player.transform.position, new Quaternion());
        GameObject one = Instantiate(effect2, player.transform.position, new Quaternion()) as GameObject;
        GameObject two = Instantiate(effect3, player.transform.position, new Quaternion()) as GameObject;
        Destroy(one, 3);
        Destroy(two, 3);
        Destroy(gameObject);
    }


}
