using UnityEngine;

public class ShopController : MonoBehaviour {
    GameController gameController;
    public int costByHouse;
    public int costByLane;
    void Start() {
        gameController = gameObject.GetComponent<GameController>();
    }

    [System.Obsolete]
    public void buyHouse() {
        Debug.Log("a" + gameController.coin * (GameController.mapNow + 1) + "|" + costByHouse);
        if (gameController.coin * (GameController.mapNow + 1) < costByHouse) {
            Debug.Log("Khong mua dc");
        } else {
            gameController.changeCoin(-(costByHouse * (GameController.mapNow + 1)));
            var i = Random.Range(1f, 100f);
            if (i <= 65) {
                gameController.buyHouseSuccess(0);
            } else if (i <= 90) {
                gameController.buyHouseSuccess(1);
            } else if (i <= 98.8f) {
                gameController.buyHouseSuccess(2);
            } else if (i <= 99.9f) {
                gameController.buyHouseSuccess(3);
            } else if (i <= 100) {
                gameController.buyHouseSuccess(4);
            }
        }

    }
    [System.Obsolete]
    public void buyLane() {
        if (gameController.coin < costByHouse || gameController.lsSaveMap.Count >= gameController.allMap.transform.childCount) {
            Debug.Log("Khong mua dc");
        } else {
            gameController.changeCoin(-costByHouse);
            var i = 0;
            while (true) {
                i = (int)Random.Range(1f, 5f);
                bool kt = true;
                foreach (int obj in gameController.lsSaveMap) {
                    Debug.Log("test2" + i + "|" + obj);
                    if (i == obj) {
                        kt = false;
                    }
                }
                if (kt) {
                    break;
                }
            }
            gameController.allMap.transform.GetChild(i).gameObject.SetActive(true);
            gameController.lsSaveMap.Add(i);
        }

    }

}
