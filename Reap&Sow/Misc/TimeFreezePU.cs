using UnityEngine;
using System.Collections;

public class TimeFreezePU : BasePowerUp {

   public override void Action()
    {
        EventManager.Freeze();
        Invoke("Thaw", 5);
    }

    void Thaw()
    {
        EventManager.Thaw();
        Destroy(gameObject);
    }
}
