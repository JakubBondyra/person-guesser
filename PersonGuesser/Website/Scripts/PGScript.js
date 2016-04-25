
function doWork(event) {
    $.ajax(
                   {
                       url: '/GameService.svc/GetData',
                       type: 'GET',
                       contentType: 'application/JSON; charset=utf-8',
                       data: { "int": 1 },
                       dataType: 'json',
                       success: function (data) { alert(data.d); },
                       error: function (data) { alert('cos sie zjebalo'); }
                   }
                   );

}