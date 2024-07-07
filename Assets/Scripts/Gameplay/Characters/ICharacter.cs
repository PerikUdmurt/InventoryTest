using InventoryTest.Services.SaveLoad;

namespace InventoryTest.Gameplay
{
    public interface ICharacter : IDataSaver
    {
        void OnDied();
    }
}
