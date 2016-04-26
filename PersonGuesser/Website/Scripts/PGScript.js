
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
    //remove all childs of div
    //append proper buttons and divs with handlers
}

function displayGameScreen(text) {
    //displaying game (question, answers) screen
    //remove all childs of div
    //append proper buttons and divs with handlers
}

function displayEndScreen(text) {
    //displaying ending screen (with text)
    //remove all childs of div
    //append proper buttons and divs with handlers
}

function displaySummaryScreen(summary) {
    //displaying summary screen
    //remove all childs of div
    //append proper buttons and divs with handlers
}

function sendAnswer(answer) {
    ajaxCall('/GameService/GetStep', '{AnswerType: ' + answer + '}', handleStep(data));
}

function sendSummaryDemand() {
    ajaxCall('/GameService/GetSummary', '', handleSummary(data));
}

function initializeGame() {
    ajaxCall('/GameService/StartGame', '', null);
}
function endGame() {
    ajaxCall('/GameService/EndGame', '', null);
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