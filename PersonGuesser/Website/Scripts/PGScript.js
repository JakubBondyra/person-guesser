
$(document).ready(function(e) {
    displayStartScreen();
});

function ajaxCall(_url, _data, _successFuncton) {
        $.ajax(
                {
                    url: _url,
                    type: 'GET',
                    contentType: 'application/JSON; charset=utf-8',
                    data: _data,
                    dataType: 'json',
                    success: _successFuncton,
                    error: function (data) { alert('ERROR: '+data.d); }
                });
}

function displayStartScreen() {
    //displaying first screen
    $('#game').empty();
    var r = $('<div class="row"></div>');
    r.append('<h2 class="text-center">Rozpocznij nową grę</h2>');
    $('#game').append(r);
    $('#game').append($('<br/>'));
    $('#game').append($('<br/>'));
    var buttonRow = $('<div class="row"></div>');
    var colyes = $('<div class="col-md-4"></div>');
    var byes = $('');
    colyes.append(byes);
    var coldk = $('<div class="col-md-4"></div>')
    var bdk = $('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="initializeGame()">Start</div>');
    coldk.append(bdk);
    var colno = $('<div class="col-md-4"></div>');
    var dno = $('');
    colno.append(dno);
    buttonRow.append(colyes);
    buttonRow.append(coldk);
    buttonRow.append(colno);
    $('#game').append(buttonRow);
}

function displayGameScreen(text) {
    //displaying game (question, answers) screen
    $('#game').empty();
    var r = $('<div class="row"></div>');
    r.append('<h2 class="text-center">'+text+'</h2>');
    $('#game').append(r);
    $('#game').append($('<br/>'));
    $('#game').append($('<br/>'));
    var buttonRow = $('<div class="row"></div>');
    var colyes = $('<div class="col-md-4"></div>');
    var byes = $('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="sendYesAnswer()">Tak</div>');
    colyes.append(byes);
    var coldk = $('<div class="col-md-4"></div>')
    var bdk = $('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="sendDkAnswer()">Nie wiem</div>');
    coldk.append(bdk);
    var colno = $('<div class="col-md-4"></div>');
    var dno = $('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="sendNoAnswer()">Nie</div>');
    colno.append(dno);
    buttonRow.append(colyes);
    buttonRow.append(coldk);
    buttonRow.append(colno);
    $('#game').append(buttonRow);
}

function displayEndScreen(text) {
    //displaying ending screen (with text)
    $('#game').empty();
    var r = $('<div class="row"></div>');
    r.append('<h2 class="text-center">'+text+'</h2>');
    $('#game').append(r);
    $('#game').append($('<br/>'));
    $('#game').append($('<br/>'));
    var buttonRow = $('<div class="row"></div>');
    var colyes = $('<div class="col-md-4"></div>');
    var byes = $('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="sendSummaryDemand()">Podsumowanie</div>');
    colyes.append(byes);
    var coldk = $('<div class="col-md-4"></div>')
    var bdk = $('<div class="btn btn-primary btn-lg btn-block mybutton">Pozostałe</div>');
    coldk.append(bdk);
    var colno = $('<div class="col-md-4"></div>');
    var dno = $('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="endGame()">Restart</div>');
    colno.append(dno);
    buttonRow.append(colyes);
    buttonRow.append(coldk);
    buttonRow.append(colno);
    $('#game').append(buttonRow);
}

function displaySummaryScreen(summary) {
    //displaying summary screen
    $('#game').empty();
    var r = $('<div class="row"></div>');
    r.append('<h2 class="text-center">Podsumowanie</h2>');
    $('#game').append(r);
    $('#game').append($('<br/>'));
    $('#game').append($('<br/>'));
    var buttonRow = $('<div class="row"></div>');
    var colyes = $('<div class="col-md-4"></div>');
    var byes = $('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="endGame()">Restart</div>');
    colyes.append(byes);
    var coldk = $('<div class="col-md-4"></div>')
    var bdk = $('');
    coldk.append(bdk);
    var colno = $('<div class="col-md-4"></div>');
    var dno = $('<div class="btn btn-primary btn-lg btn-block mybutton">Powrót</div>');
    colno.append(dno);
    buttonRow.append(colyes);
    buttonRow.append(coldk);
    buttonRow.append(colno);
    $('#game').append(buttonRow);
    //append entries
}

function sendYesAnswer() {
    sendAnswer("yes");
}

function sendNoAnswer() {
    sendAnswer("no");
}

function sendDkAnswer() {
    sendAnswer("unknown");
}

function sendAnswer(answer) {
    ajaxCall('/GameService/GetStep', '{AnswerType: ' + answer + '}', handleStep(data));
}

function sendSummaryDemand() {
    ajaxCall('/GameService/GetSummary', '', handleSummary(data));
}

function initializeGame() {
    ajaxCall('/GameService/StartGame', '', null);
    ajaxCall('/GameSerice/GetStep', '', handleStep(data));
}
function endGame() {
    ajaxCall('/GameService/EndGame', '', null);
    displayStartScreen();
}

function handleStep(step) {
    if (step.StepType == "Defeat")
        displayEndScreen('I have lost.')
    else if (step.StepType== "Victory")
        displayEndScreen('I have guessed correctly.')
    else if (step.StepType == 'Question')
        displayGameScreen(step.Question);
    else if (step.StepType == 'Guessing')
        displayGameScreen(step.Question);
}

function handleSummary(summary) {
    displaySummaryScreen(summary);
}