using UnityEngine;
namespace InventoryTest.Infrastructure.Factory
{
    public class SlotFactory
    {
        private const string SlotPath = "Prefabs/Slot";
        private Transform _parentTransform;

        public SlotFactory(Transform parent)
        {
            _parentTransform = parent;
        }

        public GameObject Create()
        {
            var resource = Resources.Load<GameObject>(SlotPath);
            return GameObject.Instantiate<GameObject>(resource, _parentTransform);
        }
    }
}