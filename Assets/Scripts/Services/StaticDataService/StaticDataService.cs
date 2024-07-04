
using InventoryTest.Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventoryTest.Services.StaticData
{
    public class StaticDataService
    {
        private const string StaticDataPath = "StaticDatas";
        private Dictionary<string, ItemStaticData> _modules;

        public void LoadStaticDatas()
        {
            _modules = Resources.LoadAll<ItemStaticData>(StaticDataPath)
                .ToDictionary(x => x.Name, x => x);
        }

        public ItemStaticData GetStaticData(string staticDataName, out ItemStaticData itemStaticData)
        {
            ItemStaticData data = _modules.TryGetValue(staticDataName, out ItemStaticData value) ? value : null;
            itemStaticData = data;
            return itemStaticData;
        }
    }
}

