using InventoryTest.Data;
using UnityEngine;

namespace InventoryTest.Gameplay
{
    public class WeaponHUD : MonoBehaviour
    {
        [SerializeField] private int _pistolDamage;
        [SerializeField] private int _rifleDamage;
        [SerializeField] private int _selfDamage;

        private WeaponType _currentWeapon = WeaponType.Pistol;
        private Character _character;
        private Enemy _enemy;

        public void Constuct(Character character, Enemy enemy)
        {
            _character = character;
            _enemy = enemy;
        }

        public void Shoot()
        {
            switch (_currentWeapon)
            {
                case WeaponType.Pistol:
                    _character.health.GetDamage(_selfDamage);
                    _enemy.health.GetDamage(_pistolDamage);
                    return;
                case WeaponType.Rifle:
                    _character.health.GetDamage(_selfDamage);
                    _enemy.health.GetDamage(_rifleDamage);
                    return;
            }

        }

        public void ChangeWeapon(int type)
        {
            _currentWeapon = (WeaponType)type;
        }
    }
}