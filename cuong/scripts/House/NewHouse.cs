using UnityEngine;

public class NewHouse : MonoBehaviour
{
    public GameObject mainCamera;
    // Start is called before the first frame update
    public void newHouse(int i)
    {
        GameObject house;
        house = GameObject.Find("house" + (DataController.listContructController.Count));
        if (house == null)
        {
            house = Instantiate(DataController.listContruct[i], new Vector3(mainCamera.transform.position.x, 0, mainCamera.transform.position.z + 10), DataController.listContruct[i].transform.rotation);
            house.name = "house" + (DataController.listContructController.Count);
            house.GetComponent<HouseMove>().enabled = true;
        }
        else
        {
            house.transform.position = new Vector3(mainCamera.transform.position.x, 0, mainCamera.transform.position.z + 10);
            house.GetComponent<HouseMove>().enabled = true;
        }
        Destroy(house.GetComponent<Rigidbody>());
    }
}
