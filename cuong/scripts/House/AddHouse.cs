using UnityEngine;

public class AddHouse : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        Destroy(gameObject.transform.parent.parent.gameObject.GetComponent<HouseMove>());
        gameObject.transform.parent.parent.gameObject.name = "house" + (DataController.listContructController.Count);
        gameObject.transform.parent.parent.gameObject.AddComponent<Rigidbody>();
        gameObject.transform.parent.parent.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject.transform.parent.gameObject);
        DataController.addNewHouse(gameObject.transform.parent.parent.gameObject);
    }
}
