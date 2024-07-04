namespace InventoryTest.Services.SaveLoad
{
    public interface IDataPersistentService
    {
        GameData GameData { get; }

        void AddSaver(IDataSaver saver);
        void LoadGame();
        void NewGame();
        void SaveGame();
    }
}
