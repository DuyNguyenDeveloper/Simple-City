using System.Collections;
using UnityEngine;

public class HouseController1 : MonoBehaviour
{
    public int typeHouse = 1;
    public int timeClick = 3;
    public int timeBuilt = 30;
    public bool canClick = false;
    // Start is called before the first frame update
    void Start()
    {
        if (timeBuilt == 0)
        {
            canClick = true;
        }
        else
        {
            StartCoroutine(timeBuiltTime());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (canClick)
        {

            DataController.updateData(100, 0, 0, 0, 0, 0);
            canClick = false;
            StartCoroutine(houseClickTime());
        }
    }
    IEnumerator houseClickTime()
    {
        yield return new WaitForSeconds(timeClick);
        canClick = true;
    }
    IEnumerator timeBuiltTime()
    {
        yield return new WaitForSeconds(1);
        /* if (gameObject.GetComponent<HouseMove>().enabled == false)
         {
             Debug.Log("test");
             timeBuilt--;
             if (timeBuilt != 0)
             {
                 StartCoroutine(timeBuiltTime());
             }
             else
             {
                 canClick = true;
             }
         }*/
        try
        {
            Debug.Log("test" + gameObject.GetComponent<HouseMove>().enabled);
            StartCoroutine(timeBuiltTime());
        }
        catch
        {
            timeBuilt--;
            if (timeBuilt != 0)
            {
                StartCoroutine(timeBuiltTime());
            }
            else
            {
                canClick = true;
            }
        }


    }




}
