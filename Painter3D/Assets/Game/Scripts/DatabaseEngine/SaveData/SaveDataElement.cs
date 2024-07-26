namespace Game.DatabaseEngine.SaveData
{
    [System.Serializable]
    public class SaveDataElement
    {
        public string name;
        public string selectionMeshToDraw;
        public string path;
        public int width;
        public int height;
        public SaveDataElement(string name,string selectionMeshToDraw, string path, int width, int height)
        {
            this.name = name;
            this.selectionMeshToDraw = selectionMeshToDraw;
            this.path = path;
            this.width = width;
            this.height = height;
        }
    }
}