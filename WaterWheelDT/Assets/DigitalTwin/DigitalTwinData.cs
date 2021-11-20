using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DigitalTwin
{
    [CreateAssetMenu(fileName = "DigitalTwinData", menuName = "DigitalTwin/Create Twin Data", order = 1)]
    public class DigitalTwinData : ScriptableObject
    {
        public UnityEvent<BottleItem> onBottleRecognized;
        
        [SerializeField]
        public List<BottleItem> bottles;
    }

    [Serializable]
    public class BottleItem
    {
        [SerializeField] public string name;

        [SerializeField] public int count;
    }
}
