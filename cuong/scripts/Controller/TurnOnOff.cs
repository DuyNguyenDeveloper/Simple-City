using UnityEngine;

public class TurnOnOff : MonoBehaviour
{
    [System.Obsolete]
    public void turnOnOff(GameObject gameObject)
    {
        gameObject.active = !gameObject.active;
    }
}
