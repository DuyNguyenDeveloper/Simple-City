using System;
using UnityEngine;
public class HouseMove : MonoBehaviour {
    private Ray ray;
    private RaycastHit hit;
    public bool move = false;
    private void Start() {
        hit = new RaycastHit();
    }
    void Update() {
        if (move) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                Vector3 vitri = new Vector3();
                vitri.x = (float)System.Math.Truncate((decimal)hit.point.x);
                vitri.y = 0;
                vitri.z = (float)System.Math.Truncate((decimal)hit.point.z);
                gameObject.transform.position = vitri;
            }
        }
    }

    private void OnMouseDown() {
        if (enabled) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject.name.Equals("AddHouse")) {
                    buyHouse();
                    GetComponent<HouseMove>().enabled = false;
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    gameObject.name = "" + (DataController.listContructController.Count);
                    Destroy(gameObject.GetComponent<Rigidbody>());
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                    DataController.addNewHouse(gameObject);
                } else if (hit.collider.gameObject.name.Equals("CancelAddHouse")) {
                    Destroy(gameObject);
                } else {
                    move = true;
                }
            }
        } else {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), 50.0f);
            foreach (RaycastHit hit in hits) {
                if (hit.collider.gameObject.name.Equals(DataController.listContructController.Count + "")) {
                    GameObject.Find(DataController.listContructController.Count + "").GetComponent<HouseMove>().move = true;
                }
            }
        }
    }
    private void OnMouseUp() {
        if (enabled) {
            move = false;
        } else {
            try {
                GameObject.Find(DataController.listContructController.Count + "").GetComponent<HouseMove>().move = false;
            } catch (Exception) {

            }
        }
    }

    [System.Obsolete]
    private void OnTriggerStay(Collider other) {
        if (enabled) {
            if (other.name != "Plane") {
                gameObject.transform.GetChild(0).GetChild(0).gameObject.active = false;
            }
        }
    }

    [System.Obsolete]
    private void OnTriggerExit(Collider other) {
        if (enabled) {
            if (other.name != "Plane") {
                gameObject.transform.GetChild(0).GetChild(0).gameObject.active = true;
            }
        }
    }

    public void buyHouse() {
        HouseController1 houseController = gameObject.GetComponent<HouseController1>();
        for (int i = 0; i < houseController.cost.Length; i++) {
            DataController.gameData.data[i] -= houseController.cost[i];
        }
        DataController.loadDataView();
    }
}
