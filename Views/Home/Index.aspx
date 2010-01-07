<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Link>>" %>

<%@ Import Namespace="MVCSample.Models" %>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= Html.Encode(ViewData["Message"]) %></h2>
    <ul>
        <%
            foreach (Link link in Model)
            { %>
        <li>
            <%= link.Title %></li>
        <% } %>
    </ul>
</asp:Content>
