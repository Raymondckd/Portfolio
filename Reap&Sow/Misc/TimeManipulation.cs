using UnityEngine;
using System.Collections;

public class TimeManipulation : BasePowerUp {

    public override void Action()
    {
        EventManager.TimeM();
        Invoke("ReturnToNormal", 5);
    }

    void ReturnToNormal()
    {
        EventManager.ReturnT();
        Destroy(gameObject);
    }
}
