<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebFormsExample.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <p>This demo illustrates usage of <a href="http://autofac.readthedocs.io/en/latest/integration/webforms.html">Autofac in an ASP.NET web forms environment</a>.</p>

    <p>Check out the Global.asax and web.config for how to set up the application.</p>
</asp:Content>
