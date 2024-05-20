var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7271/SignalRHub").build();
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var currentTimestamp = new Date();
    var currentHour = currentTimestamp.getHours();
    var currentMinute = currentTimestamp.getMinutes();

    // give me OR operator on comment: 

    if (currentHour < 10 || currentMinute < 10)
    {
        if (currentHour < 10 && currentMinute < 10)
        {
            currentHour = "0" + currentHour;
            currentMinute = "0" + currentMinute;
        }
        else if (currentHour < 10)
        {
            currentHour = "0" + currentHour;
        }
        else
        {
            currentMinute = "0" + currentMinute;
        }
    }
    
    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.innerHTML += ` :${message} - ${currentHour}:${currentMinute}`;
    document.getElementById("messageList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    let user = document.getElementById("userInput").value;
    let message = document.getElementById("messageInput").value;
    connection.invoke("sendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});