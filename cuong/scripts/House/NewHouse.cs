using UnityEngine;

public class NewHouse : MonoBehaviour {
    public GameObject mainCamera;
    public void newHouse(int i) {
        GameObject house;
        house = GameObject.Find("" + (DataController.listContructController.Count));
        if (house == null) {
            house = Instantiate(DataController.listContruct[i], new Vector3(mainCamera.transform.position.x, 0, mainCamera.transform.position.z + 10), DataController.listContruct[i].transform.rotation);
            house.name = "" + (DataController.listContructController.Count);
            house.GetComponent<HouseController1>().typeHouse = i;
            house.GetComponent<HouseMove>().enabled = true;
            house.AddComponent<Rigidbody>();
            house.GetComponent<Rigidbody>().isKinematic = true;
        } else {
            Destroy(house);
            house = Instantiate(DataController.listContruct[i], new Vector3(mainCamera.transform.position.x, 0, mainCamera.transform.position.z + 10), DataController.listContruct[i].transform.rotation);
            house.name = "" + (DataController.listContructController.Count);
            house.GetComponent<HouseMove>().enabled = true;
            house.GetComponent<HouseController1>().typeHouse = i;
            house.AddComponent<Rigidbody>();
            house.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
