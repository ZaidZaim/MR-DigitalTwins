using DigitalTwin;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalTwin {
    public class DataReceiver : MonoBehaviour
    {
        public DigitalTwinData digitalTwinData;
        public List<BottleItem> bottles;

        public event Action<string, int> onNewBottleRecognized;
      
        [Button]
        public void FakeEventCoke() {
            onNewBottleRecognized?.Invoke("Coke", 1);
        }
        [Button]
        public void FakeEventSprite() {
            onNewBottleRecognized?.Invoke("Sprite", 1);
        }
        [Button]
        public void FakeEventPepsi() {
            onNewBottleRecognized?.Invoke("Pepsi", 1);
        }
    }
}
