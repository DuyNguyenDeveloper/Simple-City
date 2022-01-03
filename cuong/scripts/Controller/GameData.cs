[System.Serializable]
public class GameData {
    public int[] data;
    public GameData() {
        data = new int[6];
        data.SetValue(1000, 0);
        data.SetValue(1000, 1);
        data.SetValue(1000, 2);
    }
}
