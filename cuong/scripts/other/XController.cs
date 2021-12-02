using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XController : MonoBehaviour
{
    public GameObject itemList, construct;
    private Vector3 vector;
    // Start is called before the first frame update
    private void Start()
    {
        vector = gameObject.transform.position;
        vector.y -= 100;
    }
    private void OnMouseDown()
    {
        itemList = Instantiate(itemList, vector, Quaternion.identity);
        itemList.transform.SetParent(GameObject.Find("Canvas").transform);
        itemList.transform.localPosition = vector;
        SelectItem.objX = gameObject;
    } 
}
