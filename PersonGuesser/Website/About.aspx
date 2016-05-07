<%@ Page Title="Instrukcje" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Website.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
    $(document).ready(function (e) {
        displayStatistics();
    });
    </script>
    <div class="jumbotron">
        <h2 class="text-center mytext">Instrukcje</h2>
        <div class="text-center mytext">Wymyślasz sobie osobę (władcy i prezydenci Polski) i odpowiadasz na pytania systemu.</div>
        <br/>
        <div class="text-center mytext">System może zgadnąć twoją osobę lub się poddać, w przypadku poddania - możesz dodać nową osobę (o której myślałeś)</div>
        <br/>
        <div class="text-center mytext">Możesz dodatkowo dodać nowe pytania (dla osoby zgadniętej lub dodanej przez ciebie).</div>
        <br/>        
        <div class="text-center mytext">Dodatkowo, można podejrzeć podsumowanie rozgrywki (po skończonej rozgrywce) i statystyki aplikacji (link u góry).</div>
        <br/>    
    </div>
</asp:Content>
