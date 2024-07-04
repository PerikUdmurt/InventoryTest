using System;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryTest.UI.ProgressBar
{
    public class ProgressBarUI : MonoBehaviour
    {
        public event Action Changed;

        [SerializeField] private float _animDuration;
        [SerializeField] private Image _image;
        private float _value;

        public float Value
        {
            get { return _value; }
            set
            {
                _value = value;
                Changed?.Invoke();
            }
        }

        public void SetValue(float value)
        {
            Value = value;
        }

        private void Update()
        {
            float currentValue = _image.fillAmount;
            _image.fillAmount = Mathf.Lerp(currentValue, _value, _animDuration);
        }
    }
}
