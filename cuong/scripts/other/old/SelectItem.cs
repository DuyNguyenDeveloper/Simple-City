using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    public static GameObject objX;

    public  List<GameObject> listConstruct;
    // Start is called before the first frame update
    public void createConstruct(int positon)
    {
        GameObject construct;
        Vector3 vector = objX.transform.position;
        vector.y += listConstruct[positon].transform.localScale.y / 2;
        construct = Instantiate(listConstruct[positon],vector , listConstruct[positon].transform.rotation);
       construct.transform.SetParent(objX.transform);
    }
}
