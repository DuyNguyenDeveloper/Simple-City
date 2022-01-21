using UnityEngine;

public class TurnOnOffObject : MonoBehaviour {
    // Start is called before the first frame update

    [System.Obsolete]
    public void turnOnOff(GameObject gameObject) {
        gameObject.active = !gameObject.active;
    }
}
