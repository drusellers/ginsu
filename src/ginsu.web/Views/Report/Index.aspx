<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ginsu.jqGrid.JqGridOptions>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="jquery" ContentPlaceHolderID="JavaScript" runat="server">
    <script type="text/javascript">

        jQuery(document).ready(function () {
            jQuery("#data").jqGrid({
                datatype: "local",
                height: 250,
                colNames: [<%= Model.Columns.Select(m=>m.DisplayName).Aggregate((s,r) => string.Format("'{0}', '{1}'", s, r)) %>],
                colModel: [
                <% foreach(var c in Model.Columns) { %>
   		            <%= c %>,
                <% } %>
   	            ],
                caption: "Manipulating Array Data"
            });

            var mydata = [
                { id: 'bob', invdate: '2010-02-26' },
                { id: 'apgid', invdate: '2010-02-26' },
            ];

            for (var i = 0; i <= mydata.length; i++)
                jQuery("#data").jqGrid('addRowData', i + 1, mydata[i]);
        });

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>REPORT</h2>
    <table id="data"></table>
    <div id="pager"></div>
</asp:Content>
