using BasuraWaterWheel;
using DigitalTwin;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    [SerializeField] DataReceiver dataReceiver;
    [SerializeField] DebrisSpawner debrisSpawner;

    [SerializeField] GameObject cokePrefab;
    [SerializeField] GameObject pepsiPreab;
    [SerializeField] GameObject spritePrefab;

    private void Start() {
        dataReceiver.onNewBottleRecognized += SpawnBottle;
    }

    private void SpawnBottle(string bottle, int count) {
        for (int i = 0; i < count; i++) {
            debrisSpawner.CreateBottle(bottle);
        }
    }

    private void OnDestroy() {
        dataReceiver.onNewBottleRecognized -= SpawnBottle;
    }
}
