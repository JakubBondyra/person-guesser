<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="Website._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div id="startWindow" style="display: <%= StartWindowVisibility %>">
            <div class="row">
                <h2 class="text-center">Rozpocznij nową grę</h2>
            </div>
            <br/>
            <br/>
             <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <div class="btn btn-primary btn-lg btn-danger mybutton" onclick="doWork()">Start</div>
                </div>
            </div>
        </div>
        <div id="mainWindow" style="display: <%= MainWindowVisibility %>">
         <div class="row">
            <div class="col-md-4">
                <asp:button runat="server" OnClick="ReturnToStartEventHandler" CssClass="btn btn-primary btn-lg btn-danger mybutton" Text="Ekran startowy"/>
            </div>
        </div>
        <div class="row">
            <h2 class="text-center">Pytanie</h2>
        </div>
        <br/>
        <br/>

        <div class="row">
            <div class="col-md-4">
                <asp:button runat="server" OnClick="YesEventHandler" CssClass="btn btn-primary btn-lg btn-block mybutton" Text="Jeszcze jak"/>
            </div>
            <div class="col-md-4">
                <asp:button runat="server" OnClick="DkEventHandler" CssClass="btn btn-primary btn-lg btn-block mybutton" Text="Nie wiem"/>
            </div>
            <div class="col-md-4">
                <asp:button runat="server" OnClick="NoEventHandler"  CssClass="btn btn-primary btn-lg btn-block mybutton" Text="Nie"/>
            </div>
        </div>
        </div>
                <div id="endWindow" style="display: <%= EndWindowVisibility %>">
            <div class="row">
                <h2 class="text-center">Zakończenie i podsumowanie</h2>
            </div>
            <br/>
            <br/>
             <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <asp:button runat="server" OnClick="ReturnToStartEventHandler" CssClass="btn btn-primary btn-lg btn-block mybutton" Text="Zakończ"/>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
