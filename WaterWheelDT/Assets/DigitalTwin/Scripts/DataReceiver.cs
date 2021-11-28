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

        public void DataReceived(string message) {
            onNewBottleRecognized?.Invoke(message, 1);
        }

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

        public void Start()
        {
            StartCoroutine(SpawnBottles());
        }

        private IEnumerator SpawnBottles()
        {
            while (true)
            {
                yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 5f));
                int i = UnityEngine.Random.Range(0, 3);
                switch (i) {
                    case 0:
                        onNewBottleRecognized?.Invoke("Coke", 1);
                        break;
                    case 1:
                        onNewBottleRecognized?.Invoke("Sprite", 1);
                        break;
                    case 2:
                        onNewBottleRecognized?.Invoke("Pepsi", 1);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
