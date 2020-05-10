
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("Message", function () {
    chatModalSignalr();
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

$(function () {
    chatModal();
});

$("#btn_chat").click(function () {
    var messsageText = $("#btn_input").val();
    if (messsageText == "") {
        alert("Error, El mensaje esta en blanco");
    }
    else {
        $.ajax({
            url: urlSendMessage,
            type: "POST",
            data: {
                TextMessage: messsageText,
                UserEmail: emailUserFromIdentity
            }
        }).done(function (response) {
            $("#btn_input").val("");
            var dataMessages = JSON.parse(response);
            chatModalSignalr(dataMessages);
        }).fail(function () {
            alert("Mensaje no enviado, error en la solicitud");
        });
    }
});

function chatModal() {

    $.ajax({
        url: urlGetAllChatMessages,
        type: "GET"
    }).done(function (response) {
        var dataMessages = JSON.parse(response);
        cleanMessageBox();
        createChatMessage(dataMessages);
        makeScrollBottom();
    });
};

function chatModalSignalr(data) {
    loadMessages(data);
    makeScrollBottom();
}

function cleanMessageBox() {
    var list = document.getElementById("chatBody");

    while (list.hasChildNodes()) {
        list.removeChild(list.firstChild);
    }
}
function createChatMessage(dataMessages) {
    dataMessages.forEach(loadMessages);
}
function loadMessages(item, index) {
    var body = document.getElementById("chatBody");

    var liMessage = document.createElement("li");
    liMessage.classList.add("left");
    liMessage.classList.add("clearfix");

    var divGeneral = document.createElement("div");
    divGeneral.classList.add("chat-body");
    divGeneral.classList.add("clearfix");

    var chatHeader = document.createElement("div");
    chatHeader.classList.add("header");

    var messageBody = document.createElement("p");
    var textMessage = document.createTextNode(item["TextMessage"]);
    messageBody.appendChild(textMessage);

    var autorName = document.createElement("strong");
    autorName.classList.add("primary-font");
    var textAutor = document.createTextNode(item["User"]["FullName"]);
    autorName.appendChild(textAutor);

    var messageTime = document.createElement("small");
    messageTime.classList.add("pull-right");
    messageTime.classList.add("text-muted");
    var textMessage = document.createTextNode(item["DateOnText"]);
    messageTime.appendChild(textMessage);

    var logoTime = document.createElement("span");
    logoTime.classList.add("glyphicon")
    logoTime.classList.add("glyphicon-time")

    messageTime.appendChild(logoTime)

    chatHeader.appendChild(autorName)
    chatHeader.appendChild(messageTime)

    divGeneral.appendChild(chatHeader)
    divGeneral.appendChild(messageBody)

    liMessage.appendChild(divGeneral)

    body.appendChild(liMessage)
}
function makeScrollBottom() {
    $("div.panel-body").scrollTop($("div.panel-body").prop("scrollHeight"));
}

