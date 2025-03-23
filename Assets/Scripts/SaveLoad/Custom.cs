using UnityEngine;

public class Custom : MonoBehaviour
{
    public string now = "aa-1";
    public int love = 78;

    public void SaveData() {SaveManager.save_data(this);}
    public void LoadData() 
    {
        CustomData customData = SaveManager.load_data();
        if(customData == null)
            return;

        now = customData.now;
        love = customData.love;
    }

    void Start()
    {
        SaveData();
        Debug.Log("Saved!");
    }

    void Update()
    {
        
    }
}