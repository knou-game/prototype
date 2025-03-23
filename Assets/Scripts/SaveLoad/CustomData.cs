[System.Serializable]
public class CustomData
{
    public string now;
    public int love;
    public CustomData(Custom custom)     // 생성자
    {
        now = custom.now;
        love = custom.love;
    }
}