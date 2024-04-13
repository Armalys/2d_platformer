using System;
using UnityEngine;

namespace Service.Buttons
{
    public class HealButton : MonoBehaviour
    {
        public Action HealEvent;

        public void OnClicK()
        {
            HealEvent?.Invoke();
        }
    }
}