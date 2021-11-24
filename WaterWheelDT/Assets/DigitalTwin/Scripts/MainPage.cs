using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.AspNetCore.SignalR.Client;
using DigitalTwin;

public class MainPage : MonoBehaviour {
    private SignalRConnector connector;
    [SerializeField] List<string> messagesReceived;
    [SerializeField] DataReceiver dataReceiver;

    public async Task Start() {
        connector = new SignalRConnector();
        connector.onBottleRecognized += UpdateReceivedMessages;

        await connector.InitAsync();
       //SendButton.onClick.AddListener(SendMessage);
    }
    private void UpdateReceivedMessages(Message newMessage) {
        messagesReceived.Add(newMessage.name);
        dataReceiver.DataReceived(newMessage.name);
    }
    private async void SendMessage() {
        await connector.SendMessageAsync(new Message {
            name = "Example",
            //Text = MessageInput.text,
        });
    }
}