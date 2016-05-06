
var token = -1;

$(document).ready(function(e) {
    displayStartScreen();
});

function ajaxCall(_url, _data, _successFuncton) {
        $.ajax(
                {
                    url: _url,
                    type: 'POST',
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
    var c = $('<div class="col-md-4"></div>');
    c.append($('<div class="btn btn-primary btn-lg btn-danger mybutton">Powrót</div>'));
    r.append(c);
    r.append($('<div class="col-md-4"></div>'));
    r.append($('<div class="col-md-4"></div>'));
    $('#game').append(r);
    r = $('<div class="row"></div>');
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

    var colyes = $('<div class="col-md-3"></div>');
    var byes = $('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="sendSummaryDemand()">Podsumowanie</div>');
    colyes.append(byes);

    var colap = $('<div class="col-md-3"></div>');
    var bap = $('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="displayAddPerson()">Dodaj osobę</div>');
    colap.append(bap);

    var colaq = $('<div class="col-md-3"></div>');
    var baq = $('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="displayAddQuestion()">Dodaj pytanie</div>');
    colaq.append(baq);

    var colno = $('<div class="col-md-3"></div>');
    var dno = $('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="endGame()">Restart</div>');
    colno.append(dno);

    buttonRow.append(colyes);
    buttonRow.append(colap);
    buttonRow.append(colaq);
    buttonRow.append(colno);
    $('#game').append(buttonRow);
    $('#game').append($('<div id="adding"></div>'));
    $('#game').append($('<div id="summary"></div>'));
}

function displaySummaryScreen(summary) {
    //displaying summary screen
    //append entries
    if ($('#summary').children().length > 0)
        return;
    $('#summary').append($("<strong>Osoba - " + summary.GuessedName + "</strong>"));
    var tr = $('<div class="row"></div>');
    tr.append($('<div class="col-md-8 sumhs">Pytanie</div>'));
    tr.append($('<div class="col-md-2 sumusr">Ty:</div>'));
    tr.append($('<div class="col-md-2 sumsys">W systemie:</div>'));
    $('#summary').append(tr);

    for (var i = 0; i < summary.Entries.length; i++) {
        tr = $('<div class="row"></div>');
        tr.append($('<div class="col-md-8 sumhs">' + summary.Entries[i].QuestionText + '</div>'));
        tr.append($('<div class="col-md-2 sumusr">' + summary.Entries[i].UserAnswer + '</div>'));
        tr.append($('<div class="col-md-2 sumsys">' + summary.Entries[i].SystemAnswer + '</div>'));
        $('#summary').append(tr);
    }
}

function displayAddPerson() {
    var form = $('<form></form>');
    form.append($('<input id="personText" placeholder="osoba" type="text"></input>'));
    form.append($('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="addPerson()">Dodaj osobę</div>'));
    $('#adding').empty();
    $('#adding').append(form);
}

function displayAddQuestion() {
    var form = $('<form></form>');
    form.append($('<input id="questionText" placeholder="pytanie" type="text"></input>'));
    form.append($('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="addQuestion()">Dodaj pytanie</div>'));
    $('#adding').empty();
    $('#adding').append(form);
}

function addPerson() {
    var data = $('#personText').val();
    ajaxCall('/GameService.svc/AddPerson', '{"person": "'+data+'"}', function(x) { alert(x.d); });
}

function addQuestion() {
    var data = $('#questionText').val();
    ajaxCall('/GameService.svc/AddQuestion', '{"question": "' + data + '"}', function (x) { alert(x.d); });
}

function sendYesAnswer() {
    sendAnswer("Yes");
}

function sendNoAnswer() {
    sendAnswer("No");
}

function sendDkAnswer() {
    sendAnswer("Unknown");
}

function sendAnswer(answer) {
    ajaxCall('/GameService.svc/GetStep', '{"answer":"'+token+answer+'"}', handleStep);
}

function sendSummaryDemand() {
    ajaxCall('/GameService.svc/GetSummary', '{"token":"'+ token+ '"}', handleSummary);
}

function initializeGame() {
    ajaxCall('/GameService.svc/StartGame', '', saveToken);
}
function endGame() {
    ajaxCall('/GameService.svc/EndGame', '{"token":"'+ token+ '"}', null);
    displayStartScreen();
}

function handleStep(step) {
    if (step.d.StepType == "Defeat")
        displayEndScreen('I have lost.')
    else if (step.d.StepType== "Victory")
        displayEndScreen('I have guessed correctly.')
    else if (step.d.StepType == 'Question')
        displayGameScreen(step.d.Question);
    else if (step.d.StepType == 'Guessing')
        displayGameScreen(step.d.Question);
}

function saveToken(data) {
    token = data.d;
    ajaxCall('/GameService.svc/GetStep', '{"answer":"' + token + 'Init"}', handleStep);
}

function handleSummary(summary) {
    displaySummaryScreen(summary.d);
}