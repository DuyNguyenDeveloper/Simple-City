using System.Collections;
using UnityEngine;

public class HouseController1 : MonoBehaviour {
    public int typeHouse;
    public int timeClick;
    public int timeClickRun;
    public int timeBuilt;
    public int[] resources = new int[6];
    public int[] cost = new int[6];
    void Start() {
        if (timeBuilt > 0) {
            StartCoroutine(timeBuiltBack());
        } else {
            StartCoroutine(houseClickWait());
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            Destroy(gameObject.transform.GetChild(1).gameObject);
            if (timeClickRun <= 0) {
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }
    private void OnMouseDown() {
        if (timeClickRun <= 0) {
            DataController.updateData(resources);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            timeClickRun = timeClick;
            StartCoroutine(houseClickWait());
        }
    }
    // wait after click
    IEnumerator houseClickWait() {
        if (timeClickRun <= 0) {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(1);
        if (timeClickRun > 0) {
            timeClickRun--;
            StartCoroutine(houseClickWait());
        }
    }
    //time xay dung
    IEnumerator timeBuiltBack() {
        timeClickRun = timeClick;
        if (gameObject.GetComponent<HouseMove>().enabled) {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        } else {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        if (gameObject.GetComponent<HouseMove>().enabled) {
            yield return new WaitForSeconds(1);
            StartCoroutine(timeBuiltBack());
        } else {
            yield return new WaitForSeconds(1);
            timeBuilt--;
            if (timeBuilt != 0) {
                StartCoroutine(timeBuiltBack());
            } else {
                StartCoroutine(houseClickWait());
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                Destroy(gameObject.transform.GetChild(1).gameObject);
            }
        }


    }




}
