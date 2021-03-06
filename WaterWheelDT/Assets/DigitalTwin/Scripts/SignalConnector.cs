using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Microsoft.AspNetCore.SignalR.Client;
using DigitalTwin;

public class SignalRConnector {
    public Action<Message> onBottleRecognized;
    private HubConnection connection;

    public async Task InitAsync() {
        connection = new HubConnectionBuilder()
                .WithUrl("https://redi-digital-twin-demo-01.azurewebsites.net/api")
                .Build();
        connection.On<string, int>("onBottleRecognized", (user, count) => {
            onBottleRecognized?.Invoke(new Message {
                name = user,
                count = count,
            });
        });
        await StartConnectionAsync();
    }
    public async Task SendMessageAsync(Message message) {
        try {
            await connection.InvokeAsync("SendMessage",
                message.name, message.count);
        } catch (Exception ex) {
            UnityEngine.Debug.LogError($"Error {ex.Message}");
        }
    }
    private async Task StartConnectionAsync() {
        try {
            await connection.StartAsync();
        } catch (Exception ex) {
            UnityEngine.Debug.LogError($"Error {ex.Message}");
        }
    }
}
public class Message {
    public string name { get; set; }
    public int count { get; set; }
}