using System;
using UnityEngine;

namespace Service.Buttons
{
    public class DamageButton : MonoBehaviour
    {
        public Action TakeDamageEvent;

        public void OnClicK()
        {
            TakeDamageEvent?.Invoke();
        }
    }
}