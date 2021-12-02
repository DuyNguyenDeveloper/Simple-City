using UnityEngine;

[System.Serializable]
public class HouseData
{
    public int typeHouse;
    public float[] positon;
    // Start is called before the first frame update
    public HouseData(int typeHouse, Vector3 vector)
    {
        this.typeHouse = typeHouse;

        positon = new float[3];
        positon[0] = vector.x;
        positon[1] = vector.y;
        positon[2] = vector.z;
    }
}
