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
            while (true)
            {
                SpawnCoke();
                SpawnSprite();
                SpawnPepsi();

            }

        }

        private IEnumerator SpawnCoke()
        {
            while (true)
            {
                //Instantiate(baseball);
                onNewBottleRecognized?.Invoke("Coke", 1);
                yield return new WaitForSeconds(2);
            }
        }

        private IEnumerator SpawnSprite()
        {
            while (true)
            {
                //Instantiate(baseball);
                onNewBottleRecognized?.Invoke("Sprite", 1);
                yield return new WaitForSeconds(2);
            }
        }

        private IEnumerator SpawnPepsi()
        {
            while (true)
            {
                //Instantiate(baseball);
                onNewBottleRecognized?.Invoke("Pepsi", 1);
                yield return new WaitForSeconds(2);
            }
        }
    }
}
