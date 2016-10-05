<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsExample._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<h2>Autofac Web Forms Example</h2>

<p>This web form consumes a dependency that is injected by Autofac. Check out the code-behind and web.config to understand where the value is coming from.</p>

<p>Dependency ID: <asp:Label runat="server" ID="DependencyLabel" /></p>
</asp:Content>
