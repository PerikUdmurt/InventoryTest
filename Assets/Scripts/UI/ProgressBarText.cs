using UnityEngine.UI;
using UnityEngine;
using TMPro;
using InventoryTest.UI.ProgressBar;

namespace InventoryTest.UI
{
    public class ProgressBarText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private ProgressBarUI _progressBar;

        private void Update()
        {
            _text.text = $"{_progressBar.Value * 100}%";
        }
    }
}
