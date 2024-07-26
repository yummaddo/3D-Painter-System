using UnityEngine;

namespace Game.DatabaseEngine.SaveData
{
    [System.Serializable]
    public class BrashSettingData
    {
        public DataBrash dataBrash;

        public BrashSettingData()
        {
            dataBrash = new DataBrash();
        }

        public BrashSettingData(DataBrash dataBrash)
        {
            this.dataBrash = dataBrash;
        }
    }
    [System.Serializable]

    public class DataBrash
    {
        public float opacity = 0;
        public float hardness = 5;
        public float size = 0.1f;
        public Color color = Color.red;
        public DataBrash() { }
        public DataBrash(float opacity, float hardness, float size, Color color)
        {
            this.opacity = opacity;
            this.hardness = hardness;
            this.size = size;
            this.color = color;
        }
    }
}