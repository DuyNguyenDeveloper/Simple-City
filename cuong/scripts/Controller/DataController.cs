using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{

    public static List<GameObject> listContruct;
    public List<GameObject> listContructView;
    public static List<HouseData> listContructController;
    public List<HouseData> listContructControllerView;
    // Start is called before the first frame update
    void Start()
    {
        listContructController = new List<HouseData>();
        listContructController = SaveSystem.LoadListHouse();
        listContruct = listContructView;
        loadDataHouse();
    }
    private void loadDataHouse()
    {
        GameObject house;
        Vector3 objVector;
        int i = 0;
        foreach (HouseData houseData in listContructController)
        {
            objVector = new Vector3();
            objVector.x = houseData.positon[0];
            objVector.y = 0;
            objVector.z = houseData.positon[2];
            house = listContruct[houseData.typeHouse - 1];
            house.name = "house" + i;
            house = Instantiate(house, objVector, listContruct[houseData.typeHouse - 1].transform.rotation);
            Destroy(house.transform.GetChild(0).gameObject);
            Destroy(house.GetComponent<HouseMove>());
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        listContructControllerView = listContructController;

    }
    public static void addNewHouse(GameObject newHouse)
    {
        Debug.Log(newHouse.GetComponent<HouseController1>().typeHouse);
        Debug.Log(newHouse.transform.position.x);
        HouseData data = new HouseData(newHouse.GetComponent<HouseController1>().typeHouse, newHouse.transform.position);
        listContructController.Add(data);
        Debug.Log("test data" + listContructController[0].typeHouse);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveSystem.SaveListHouse(listContructController);
        }
        else
        {

        }
    }
    private void OnDestroy()
    {
        SaveSystem.SaveListHouse(listContructController);
    }
}
