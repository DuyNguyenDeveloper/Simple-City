using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataController : MonoBehaviour {
    public static GameData gameData;
    public GameData gameDataInspector;

    public static List<GameObject> listContruct;
    public List<GameObject> listContructInspector;

    public static List<HouseData> listContructController;
    public List<HouseData> listContructControllerInspector;

    public static List<Text> lsViewData;
    public List<Text> lsViewDataInspector;

    public static List<Button> lsBtnBuy;
    public List<Button> lsBtnBuyInspector;
    // Start is called before the first frame update
    void Start() {
        listContructController = SaveSystem.LoadListHouse();
        gameData = SaveSystem.LoadGameData();

        listContruct = listContructInspector;
        lsViewData = lsViewDataInspector;
        lsBtnBuy = lsBtnBuyInspector;

        loadDataHouse();
        loadDataView();

    }
    // Update is called once per frame
    void Update() {
        listContructControllerInspector = listContructController;
        gameDataInspector = gameData;


    }
    public static void updateData(int[] addData) {
        for (int i = 0; i <= gameData.data.Length - 1; i++) {
            gameData.data[i] += addData[i];
        }
        loadDataView();
    }
    public static void loadDataView() {
        for (int i = 0; i <= gameData.data.Length - 1; i++) {
            lsViewData[i].text = gameData.data[i] + "";
        }
    }
    private void loadDataHouse() {
        GameObject house;
        Vector3 objVector;
        int i = 0;
        foreach (HouseData houseData in listContructController) {
            objVector = new Vector3();
            objVector.x = houseData.positon[0];
            objVector.y = 0;
            objVector.z = houseData.positon[2];
            house = listContruct[houseData.typeHouse];
            /* switch (houseData.typeHouse) {
                 case 1:

                     break;
                 case 2:
                     break;
                 case 3:
                     break;
                 case 4:
                     break;
                 case 5:
                     break;
             }*/
            house = Instantiate(house, objVector, listContruct[houseData.typeHouse].transform.rotation);
            house.GetComponent<HouseController1>().typeHouse = houseData.typeHouse;
            house.GetComponent<HouseController1>().timeBuilt = houseData.timeBuilt;
            house.GetComponent<HouseController1>().timeClickRun = houseData.timeClickRun;
            house.name = i + "";
            Destroy(house.transform.GetChild(0).gameObject);
            i++;
        }
    }


    public static void addNewHouse(GameObject newHouse) {
        HouseData data = new HouseData();
        int typeHouse = newHouse.GetComponent<HouseController1>().typeHouse;
        data.timeBuilt = newHouse.GetComponent<HouseController1>().timeBuilt;
        /* switch (typeHouse) {
             case 1:

                 break;
             case 2:
                 break;
             case 3:
                 break;
             case 4:
                 break;
             case 5:
                 break;
         }*/
        data.typeHouse = typeHouse;
        data.positon[0] = newHouse.transform.position.x;
        data.positon[1] = 0;
        data.positon[2] = newHouse.transform.position.z;
        listContructController.Add(data);
    }
    private void getDataSave() {
        for (int i = 0; i <= listContructController.Count - 1; i++) {
            GameObject house = GameObject.Find("" + i);
            listContructController[i].timeBuilt = house.GetComponent<HouseController1>().timeBuilt;
            listContructController[i].timeClickRun = house.GetComponent<HouseController1>().timeClickRun;
        }
    }
    public void checkDataBuy() {
        for (int j = 0; j < listContruct.Count; j++) {
            Debug.Log(listContruct.Count);
            for (int i = 0; i < gameData.data.Length; i++) {
                Debug.Log(i);
                if (gameData.data[i] < listContruct[j].GetComponent<HouseController1>().cost[i]) {
                    lsBtnBuy[j].GetComponent<Image>().color = Color.red;
                    lsBtnBuy[j].GetComponent<Button>().enabled = false;
                    break;
                } else {
                    lsBtnBuy[j].GetComponent<Image>().color = Color.white;
                    lsBtnBuy[j].GetComponent<Button>().enabled = true;
                }
            }
        }
    }
    private void OnApplicationPause(bool pause) {
        if (pause) {
            getDataSave();
            SaveSystem.SaveListHouse(listContructController, gameData);
        }
    }
    private void OnApplicationQuit() {
        getDataSave();
        SaveSystem.SaveListHouse(listContructController, gameData);
    }
}
