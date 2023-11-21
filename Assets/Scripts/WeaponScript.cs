using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    // Различные параметры оружия, например, урон, скорость стрельбы, звуки и т.д.

    private Collider weaponCollider;

    private void Start()
    {
        // Получаем Collider оружия при запуске
        weaponCollider = GetComponent<Collider>();
        // Включаем триггер при старте
        EnableTrigger();
    }

    public void Fire()
    {
        // Логика стрельбы
        // Можете добавить звук выстрела, визуальные эффекты и т.д.
    }

    public void Reload()
    {
        // Логика перезарядки
    }

    public void DisableTrigger()
    {
        // Отключаем триггер на оружии (Collider)
        weaponCollider.enabled = false;
    }

    public void EnableTrigger()
    {
        // Включаем триггер на оружии (Collider)
        weaponCollider.enabled = true;
    }
}