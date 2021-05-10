<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Buoi3_FacebookAPI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
        </div>

        <div class="fb-page" data-href="https://www.facebook.com/102475348692304/" data-tabs="timeline" data-width="1000" data-height="600" data-small-header="false" data-adapt-container-width="true" data-hide-cover="false" data-show-facepile="true">
            <blockquote cite="https://www.facebook.com/102475348692304/" class="fb-xfbml-parse-ignore">
                <a href="https://www.facebook.com/102475348692304/"></a>
            </blockquote>
        </div>
    
    <script async defer crossorigin="anonymous" src="https://connect.facebook.net/en_GB/sdk.js#xfbml=1&version=v10.0&appId=737285013600260&autoLogAppEvents=1" nonce="KqsbvlJp"></script>
    
    </form>
</body>
</html>
