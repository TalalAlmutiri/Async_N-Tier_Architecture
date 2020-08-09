<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Async="true" CodeBehind="EmpAdd.aspx.cs" Inherits="PresentationLayer.EmployeesPL.EmpAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="card text-center mr-auto ml-auto " style="width: 90%">
        <div class="card-header">
            <h5 class="font-weight-bold">A New Employee Info</h5>
        </div>
        <div class="card-body">
            <div class="text-left">
                <div>
                    <label class="form-labe font-weight-bold pt-2" for="txtName">First Name:</label>
                    <input id="txtFirstName" runat="server" type="text" required="required" class="form-control bg-white" maxlength="10" />
                </div>
                <div>
                    <label class="form-label font-weight-bold pt-2" for="txtLastName">Last Name:</label>
                    <input id="txtLastName" runat="server" type="text" required="required" class="form-control bg-white" maxlength="10" />
                </div>
                <div>
                    <label class="form-label font-weight-bold pt-2" for="txtAge">Age:</label>
                    <input id="txtAge" runat="server" type="number" min="18" max="50" step="1" required="required" class="form-control bg-white" maxlength="10" />
                </div>
                <div>
                    <label class="form-label font-weight-bold pt-2" for="ddlCountries">Country:</label>
                    <asp:DropDownList ID="ddlCountries" DataTextField="CountryDesc" DataValueField="CountryID" CssClass="custom-select" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="card-footer text-muted">
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-md btn-rounded font-weight-bold text-capitalize " PostBackUrl="EmpList.aspx" UseSubmitBehavior="false" />
            <asp:Button ID="btnSave" runat="server" Text="Insert" CssClass="btn btn-primary btn-md btn-rounded font-weight-bold text-capitalize " OnClick="btnSave_Click" />

            <br />
            <h4 class="label text-danger text-center">
                <asp:Label ID="lbMsg" runat="server"></asp:Label></h4>
        </div>
    </div>

</asp:Content>
