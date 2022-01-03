using UnityEngine;

public class CameraMove : MonoBehaviour {
    private Ray ray;
    private RaycastHit hit;
    public GameObject cameraGame;
    Vector3 chenhLechCamera, chenhLechViTri;
    // Start is called before the first frame update
    void Start() {
        hit = new RaycastHit();
    }

    // Update is called once per frame
    void Update() {
    }
    void OnMouseDown() {
        chenhLechCamera = cameraGame.transform.position;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            chenhLechCamera -= hit.point;
            chenhLechViTri = hit.point;
        }
    }
    private void OnMouseDrag() {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                Vector3 moveCamera = cameraGame.transform.position;
                moveCamera.x -= (hit.point.x - chenhLechViTri.x) / 7;
                moveCamera.z -= (hit.point.z - chenhLechViTri.z) / 7;
                chenhLechViTri = hit.point;
                cameraGame.transform.position = moveCamera;
            }
        }
    }
}
