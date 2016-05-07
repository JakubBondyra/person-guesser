<%@ Page Title="Statystyki" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Website.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
    $(document).ready(function (e) {
        displayStatistics();
    });
    </script>
    <div class="jumbotron">
        <h2 id="statsHeader" class="text-center mytext">Statystyki dla systemu (ładowanie...)</h2>
        <div id="statistics">
        </div>
    </div>
</asp:Content>
