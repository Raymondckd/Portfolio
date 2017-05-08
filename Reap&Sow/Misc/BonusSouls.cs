using UnityEngine;
using System.Collections;

public class BonusSouls : BasePowerUp
{
    [SerializeField]
    GameObject soul = null;

    public override void Action()
    {
        Invoke("SpawnSouls", 2);
    }

    void SpawnSouls()
    {
        for (int i = 0; i < 100; i++)
            Instantiate(soul, new Vector3(transform.position.x + (Random.Range(-1, 2) * (i / 30)), transform.position.y + (Random.Range(-1, 2) * (i / 30)), 0), new Quaternion());

    }

}
