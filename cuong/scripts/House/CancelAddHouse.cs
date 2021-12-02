using UnityEngine;

public class CancelAddHouse : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        Destroy(gameObject.transform.parent.parent.gameObject);
    }
}
