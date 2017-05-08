using UnityEngine;
using System.Collections;

public class Shield : BasePowerUp {

    [SerializeField] GameObject shieldEffect = null;

    public override void Action()
    {
        shieldEffect.transform.position = player.transform.position;
        Instantiate(shieldEffect);
        Destroy(gameObject);
    }

}
