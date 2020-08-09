<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Async="true" CodeBehind="EmpList.aspx.cs" Inherits="PresentationLayer.EmployeesPL.EmpList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="card text-center mr-auto ml-auto " style="width: 90%">
        <div class="card-header">
            <h5 class="font-weight-bold">Employees Info</h5>
        </div>
        <div class="card-body">
            <asp:Repeater ID="reptEmployees" runat="server" OnItemCommand="reptEmployees_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-bordered text-center mr-auto ml-auto" style="width: 80%">
                        <thead>
                            <tr>
                                <th>Employee Id</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Age</th>
                                <th>Country</th>
                                <th></th>
                                <th></th>
                            </tr>
                        </thead>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Literal ID="lbEmpID" Text='<%# Eval("EmpId")%>' runat="server"></asp:Literal>
                        </td>
                        <td>
                            <label><%# Eval("FirstName") %></label>
                        </td>
                        <td>
                            <label><%# Eval("LastName") %></label></td>
                        <td>
                            <label><%# Eval("Age") %></label></td>
                        <td>
                            <label><%# Eval("CountryDesc") %></label></td>

                        <td>
                            <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-primary btn-md  btn-rounded font-weight-bold text-capitalize" CommandName="rowEdit">Edit</asp:LinkButton></td>
                        <td>
                            <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-primary btn-md  btn-rounded font-weight-bold text-capitalize" CommandName="rowDelete"
                                OnClientClick="return confirm('Are you sure you want to delete this record?');">Delete</asp:LinkButton></td>

                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="card-footer text-muted">
            <asp:Button ID="btnAdd" runat="server" Text="New Employeee" CssClass="btn btn-primary btn-md btn-rounded font-weight-bold text-capitalize " PostBackUrl="EmpAdd.aspx"   />
            <br />
            <h4 class="label text-danger text-center">
                <asp:Label ID="lbMsg" runat="server"></asp:Label></h4>

        </div>
    </div>

</asp:Content>

