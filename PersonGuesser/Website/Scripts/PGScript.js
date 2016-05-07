
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
    r.append('<h2 class="text-center mytext">Rozpocznij nową grę</h2>');
    $('#game').append(r);
    $('#game').append($('<br/>'));
    $('#game').append($('<br/>'));
    var buttonRow = $('<div class="row"></div>');
    var colyes = $('<div class="col-md-4"></div>');
    var byes = $('');
    colyes.append(byes);
    var coldk = $('<div class="col-md-4"></div>')
    var bdk = $('<div class="btn btn-primary btn-lg btn-block mybutton myyes" onclick="initializeGame()">Start</div>');
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
    c.append($('<div class="btn btn-primary btn-lg btn-danger mybutton" onclick="endGame()">Zakończ</div>'));
    r.append(c);
    r.append($('<div class="col-md-4"></div>'));
    r.append($('<div class="col-md-4"></div>'));
    $('#game').append(r);
    r = $('<div class="row"></div>');
    r.append('<h2 class="text-center mytext">' + text + '</h2>');
    $('#game').append(r);
    $('#game').append($('<br/>'));
    $('#game').append($('<br/>'));
    var buttonRow = $('<div class="row"></div>');
    var colyes = $('<div class="col-md-4"></div>');
    var byes = $('<div class="btn btn-primary btn-lg btn-block mybutton myyes" onclick="sendYesAnswer()">Tak</div>');
    colyes.append(byes);
    var coldk = $('<div class="col-md-4"></div>')
    var bdk = $('<div class="btn btn-primary btn-lg btn-block mybutton mydk" onclick="sendDkAnswer()">Nie wiem</div>');
    coldk.append(bdk);
    var colno = $('<div class="col-md-4"></div>');
    var dno = $('<div class="btn btn-primary btn-lg btn-block mybutton myno" onclick="sendNoAnswer()">Nie</div>');
    colno.append(dno);
    buttonRow.append(colyes);
    buttonRow.append(coldk);
    buttonRow.append(colno);
    $('#game').append(buttonRow);
}

function displayEndScreen(txt, image) {
    //displaying ending screen (with text)
    $('#game').empty();
    if (image != null) {
        var i = $('<div class="row" style="text-align: center; "></div>');
        var img = new Image();
        img.style.display = 'inline-block';
        img.style.margin = '0 5px';
        img.height = 400;
        img.src = 'data:image/png;base64,' + image;
        i.append(img);
        $('#game').append(i);
    }
    var r = $('<div class="row"></div>');
    r.append('<h2 class="text-center mytext">' + txt + '</h2>');
    $('#game').append(r);
    $('#game').append($('<br/>'));
    $('#game').append($('<br/>'));
    var buttonRow = $('<div class="row"></div>');

    var colyes = $('<div class="col-md-4"></div>');
    var byes = $('<div class="btn btn-primary btn-lg btn-block mybutton mydk" onclick="sendSummaryDemand()">Podsumowanie</div>');
    colyes.append(byes);

    var colap = $('<div class="col-md-4" id="addDiv"></div>');

    var colno = $('<div class="col-md-4"></div>');
    var dno = $('<div class="btn btn-primary btn-lg btn-block mybutton myno" onclick="endGame()">Restart</div>');
    colno.append(dno);

    buttonRow.append(colyes);
    buttonRow.append(colap);
    buttonRow.append(colno);
    $('#game').append(buttonRow);
    $('#game').append($('<div id="adding"></div>'));
    $('#game').append($('<div id="summary"></div>'));
}

function appendAddPerson() {
    var addDiv = $('#addDiv');
    addDiv.empty();
    var bap = $('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="displayAddPerson()">Dodaj osobę</div>');
    addDiv.append(bap);
    addDiv.append($('<div id="adding"></div>'));
}

function appendAddQuestion() {
    var addDiv = $('#addDiv');
    addDiv.empty();
    var baq = $('<div class="btn btn-primary btn-lg btn-block mybutton" onclick="displayAddQuestion()">Dodaj pytanie</div>');
    addDiv.append(baq);
    addDiv.append($('<div id="adding"></div>'));
}

function displaySummaryScreen(summary) {
    //displaying summary screen
    //append entries
    if ($('#summary').children().length > 0)
        return;
    $('#summary').append($("<strong class=\"mytext\">Podsumowanie dla : " + summary.GuessedName + "</strong>"));
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
    form.append($('<p class="mytextsmall">Pomoż usprawnić system. Dodaj osobę, o której myślałeś:</p>'));
    form.append($('<input id="personText" placeholder="osoba" type="text"></input>'));
    form.append($('<div class="btn btn-primary btn-lg btn-block mybutton myyes" onclick="addPerson()">Wyślij</div>'));
    $('#adding').empty();
    $('#adding').append(form);
}

function displayAddQuestion() {
    var form = $('<form></form>');
    form.append($('<input id="questionText" placeholder="pytanie" type="text">' +
        '</input>'));
    form.append($('<p class="mytextsmall">Zaznacz odpowiedź dla powyższej osoby:</p>'));
    var tr = $('<div class="row"></div>');
    tr.append($('<div class="col-md-2"><input type="radio" name="answer" id="yesRadio"></div>'));
    tr.append($('<div class="col-md-2 mytextsmall">Tak</div>'));
    form.append(tr);
    tr = $('<div class="row"></div>');
    tr.append($('<div class="col-md-2"><input type="radio" name="answer"></div>'));
    tr.append($('<div class="col-md-2 mytextsmall">Nie</div>'));
    form.append(tr);
    form.append($('<div class="btn btn-primary btn-lg btn-block mybutton myyes" onclick="addQuestion()">Wyślij</div>'));
    $('#adding').empty();
    $('#adding').append(form);
}

function addPerson() {
    var data = $('#personText').val();
    ajaxCall('/GameService.svc/AddPerson', '{"person": "' + data + '", "token": "' + token + '"}', function (x) { alert('dane zostały przesłane'); });
    appendAddQuestion();
}

function addQuestion() {
    var data = $('#questionText').val();
    var answer = $('#yesRadio').is(':checked') ? 1 : 0;
    alert("odpowiedź: " + answer);
    //ajaxCall('/GameService.svc/AddQuestion', '{"question": "' + data + '", "answer": "' + answer + '", "token": "'+token+'"}',
        //function (x) { alert('dane zostały przesłane'); });
    //appendAddQuestion();
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
    ajaxCall('/GameService.svc/GetStep', '{"answer":"' + answer + '", "token": "' + token + '"}', handleStep);
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
    if (step.d.StepType == "Defeat") {
        displayEndScreen(step.d.DisplayText);
        appendAddPerson();
    } else if (step.d.StepType == "Victory") {
        displayEndScreen('Zgadłem - to ' + step.d.DisplayText, step.d.Image);
        appendAddQuestion();
    } else if (step.d.StepType == 'Question') {
        displayGameScreen(step.d.DisplayText);
    } else if (step.d.StepType == 'Guessing')
        displayGameScreen(step.d.DisplayText);
}

function saveToken(data) {
    token = data.d;
    ajaxCall('/GameService.svc/GetStep', '{"answer":"Init"' + ', "token": "' + token + '"}', handleStep);
}

function handleSummary(summary) {
    displaySummaryScreen(summary.d);
}

function displayStatistics() {
    ajaxCall('/GameService.svc/GetStats', '"token": "' + token + '"}', handleStatistics);
}

function handleStatistics(data) {
    var stats = data.d;
    var div = $('#statistics');
    div.empty();

    var tr = $('<div class="row"></div>');
    tr.append($('<div class="col-md-5 mytext">Ilość osób w bazie:</div>'));
    tr.append($('<div class="col-md-3 mytext"> ' + stats.PersonCount + '</div>'));
    div.append(tr);

    tr = $('<div class="row"></div>');
    tr.append($('<div class="col-md-5 mytext">Ilość pytań w bazie:</div>'));
    tr.append($('<div class="col-md-3 mytext"> ' + stats.QuestionCount + '</div>'));
    div.append(tr);

    tr = $('<div class="row"></div>');
    tr.append($('<div class="col-md-5 mytext">Łączna ilość pytań zadanych przez system:</div>'));
    tr.append($('<div class="col-md-3 mytext"> ' + stats.AskCount + '</div>'));
    div.append(tr);

    tr = $('<div class="row"></div>');
    tr.append($('<div class="col-md-5 mytext">Ilość rozegranych gier:</div>'));
    tr.append($('<div class="col-md-3 mytext"> ' + stats.GameCount + '</div>'));
    div.append(tr);

    tr = $('<div class="row"></div>');
    tr.append($('<div class="col-md-5 mytext">Ilość osób zgadniętych przez system:</div>'));
    tr.append($('<div class="col-md-3 mytext"> ' + stats.WonCount + '</div>'));
    div.append(tr);
}