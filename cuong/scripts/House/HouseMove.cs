using UnityEngine;
public class HouseMove : MonoBehaviour
{
    //
    //move on horve
    private Ray ray;
    private RaycastHit hit;
    private bool move = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 vitri = new Vector3();
                vitri.x = (float)System.Math.Truncate((decimal)hit.point.x);
                vitri.y = 0;
                vitri.z = (float)System.Math.Truncate((decimal)hit.point.z);
                gameObject.transform.position = vitri;
            }
        }
    }

    private void OnMouseDown()
    {
        move = true;
    }
    private void OnMouseUp()
    {
        move = false;
    }

    [System.Obsolete]
    private void OnTriggerStay(Collider other)
    {
        if (other.name != "Plane")
        {
            gameObject.transform.GetChild(0).GetChild(0).gameObject.active = false;
        }
    }

    [System.Obsolete]
    private void OnTriggerExit(Collider other)
    {
        if (other.name != "Plane")
        {
            gameObject.transform.GetChild(0).GetChild(0).gameObject.active = true;
        }
    }
}
