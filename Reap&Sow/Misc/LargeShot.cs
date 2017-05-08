using UnityEngine;
using System.Collections;

public class LargeShot : BasePowerUp {

    [SerializeField] GameObject shot = null;

    public override void Action()
    {
        Invoke("FireMe", 2);
    }

    void FireMe()
    {
        Instantiate(shot, player.transform.position, player.transform.rotation);
    }

}
