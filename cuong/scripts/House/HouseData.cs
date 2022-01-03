[System.Serializable]
public class HouseData {
    public int typeHouse;
    public int timeBuilt;
    public int timeClickRun;
    public float[] positon = new float[3];
    // Start is called before the first frame update
    public HouseData() { }
    /*public HouseData(int typeHouse, Vector3 vector, int timeBuilt) {
        this.typeHouse = typeHouse;
        this.timeBuilt = timeBuilt;
        positon = new float[3];
        positon[0] = vector.x;
        positon[1] = vector.y;
        positon[2] = vector.z;
    }*/
}
