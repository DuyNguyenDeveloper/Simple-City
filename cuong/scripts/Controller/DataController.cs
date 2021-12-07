using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataController : MonoBehaviour
{
    public static GameData gameData;
    public GameData gameDataInspector;

    public static List<GameObject> listContruct;
    public List<GameObject> listContructInspector;

    public static List<HouseData> listContructController;
    public List<HouseData> listContructControllerInspector;

    public static List<Text> lsViewData;
    public List<Text> lsViewDataInspector;
    // Start is called before the first frame update
    void Start()
    {
        listContructController = SaveSystem.LoadListHouse();
        gameData = SaveSystem.LoadGameData();

        listContruct = listContructInspector;
        lsViewData = lsViewDataInspector;

        loadDataHouse();
        loadDataView();

    }
    // Update is called once per frame
    void Update()
    {
        listContructControllerInspector = listContructController;
        gameDataInspector = gameData;


    }
    public static void updateData(int coin, int stone, int iron, int food, int old, int diamon)
    {
        gameData.coin += coin;
        gameData.stone += stone;
        gameData.iron += iron;
        gameData.food += food;
        gameData.oil += old;
        gameData.diamon += diamon;
        loadDataView();
    }
    public static void loadDataView()
    {
        // Debug.Log(gameData.coin);
        lsViewData[0].text = gameData.coin + "";
        lsViewData[1].text = gameData.stone + "";
        lsViewData[2].text = gameData.iron + "";
        lsViewData[3].text = gameData.food + "";
        lsViewData[4].text = gameData.oil + "";
        lsViewData[5].text = gameData.diamon + "";
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


    public static void addNewHouse(GameObject newHouse)
    {
        HouseData data = new HouseData(newHouse.GetComponent<HouseController1>().typeHouse, newHouse.transform.position);
        listContructController.Add(data);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveSystem.SaveListHouse(listContructController, gameData);
        }
    }
    private void OnDestroy()
    {
        SaveSystem.SaveListHouse(listContructController, gameData);
    }
}
