<%@ Page Title="" Language="C#" MasterPageFile="~/Contant/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="HospitalAddEdit.aspx.cs" Inherits="AdminPanel_Hospital_HospitalAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    <asp:Label ID="lblPageHeader" runat="server"></asp:Label>
                </h1>
                <asp:Label ID="lblMessage" runat="server" CssClass="badge badge-success"></asp:Label>
            </div>
            <div class="col-md-12 m-3">
                <div class="form-group row">
                    <label for="HospitalName" class="col-sm-2 col-form-label">Hospital Name :</label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtHospitalName" CssClass="form-control"></asp:TextBox>
                        <small id="passwordHelpBlock" class="form-text text-muted ">
                            <asp:RequiredFieldValidator ID="rfvHospitalName" runat="server" ErrorMessage="Enter Hospital Name" ControlToValidate="txtHospitalName" Display="Dynamic" ValidationGroup="HospitalAddEdit" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </small>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="HospitalAddress" class="col-md-2 col-form-label">Hospital Address :</label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        <small id="Small5" class="form-text text-muted ">
                            <asp:RequiredFieldValidator ID="rfvAdderss" runat="server" ErrorMessage="Enter Hospital Address" ControlToValidate="txtAddress" Display="Dynamic" ValidationGroup="HospitalAddEdit" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </small>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="MobileNumber" class="col-md-2 col-form-label">Mobile Number :</label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtMobileNumber" CssClass="form-control"></asp:TextBox>
                        <%--<small id="Small7" class="form-text text-muted ">
                            <asp:RequiredFieldValidator ID="rfvMobileNumber" runat="server" ErrorMessage="Enter Mobile Number" ControlToValidate="txtMobileNumber" Display="Dynamic" ValidationGroup="HospitalAddEdit" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </small>
                        <small id="Small6" class="form-text text-muted ">
                            <asp:RegularExpressionValidator ID="revMobileNumber" ControlToValidate="txtMobileNumber" runat="server" ErrorMessage="Only 10 Digit And Only Numbers" ValidationExpression="^([0-9]{10})$" ForeColor="Red" Display="Dynamic" ValidationGroup="HospitalAddEdit"></asp:RegularExpressionValidator>
                        </small>--%>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="EmailAddress" class="col-md-2 col-form-label">Email Address:</label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control"></asp:TextBox>
                        <%--<small id="Small8" class="form-text text-muted ">
                            <asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" ErrorMessage="Enter EmailAddress" ControlToValidate="txtEmailAddress" Display="Dynamic" ValidationGroup="HospitalAddEdit" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </small>--%>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="Fax" class="col-md-3 col-form-label">Fax :</label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtFax" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="Website" class="col-md-3 col-form-label">Website :</label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtWebsite" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="AmbulancePhoneNumber" class="col-md-3 col-form-label">AmbulancePhoneNumber :</label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtAmbulancePhoneNumber" CssClass="form-control"></asp:TextBox>
                        <%--<small id="Small9" class="form-text text-muted ">
                            <asp:RegularExpressionValidator ID="revAmbulancePhoneNumber" ControlToValidate="txtAmbulancePhoneNumber" runat="server" ErrorMessage="Only 10 Digit And Only Numbers" ValidationExpression="^([0-9]{10})$" ForeColor="Red" Display="Dynamic" ValidationGroup="HospitalAddEdit"></asp:RegularExpressionValidator>
                        </small>--%>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="TelePhoneNumber" class="col-md-3 col-form-label">TelePhoneNumber :</label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtTelePhoneNumber" CssClass="form-control"></asp:TextBox>
                        <%--<small id="Small10" class="form-text text-muted ">
                            <asp:RegularExpressionValidator ID="revTelePhoneNumber" ControlToValidate="txtTelePhoneNumber" runat="server" ErrorMessage="Only 10 Digit And Only Numbers" ValidationExpression="^([0-9]{10})$" ForeColor="Red" Display="Dynamic" ValidationGroup="HospitalAddEdit"></asp:RegularExpressionValidator>
                        </small>--%>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="EmergencyNumber" class="col-md-3 col-form-label">EmergencyNumber :</label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtEmergencyNumber" CssClass="form-control"></asp:TextBox>
                        <%--<small id="Small11" class="form-text text-muted ">
                            <asp:RegularExpressionValidator ID="revEmergencyNumber" ControlToValidate="txtEmergencyNumber" runat="server" ErrorMessage="Only 10 Digit And Only Numbers" ValidationExpression="^([0-9]{10})$" ForeColor="Red" Display="Dynamic" ValidationGroup="HospitalAddEdit"></asp:RegularExpressionValidator>
                        </small>--%>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="Category" class="col-md-3 col-form-label">Select Category :</label>
                    <div class="col-md-9">
                        <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                        <small id="Small2" class="form-text text-muted">
                            <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ErrorMessage="Select Category" ControlToValidate="ddlCategory" Display="Dynamic" ValidationGroup="HospitalAddEdit" ForeColor="#FF3300" InitialValue="-1"></asp:RequiredFieldValidator>
                        </small>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="CategoryType" class="col-md-3 col-form-label">Select Category Type :</label>
                    <div class="col-md-9">
                        <asp:DropDownList ID="ddlCategoryType" CssClass="form-control" runat="server"></asp:DropDownList>
                        <small id="Small3" class="form-text text-muted">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Category Type" ControlToValidate="ddlCategoryType" Display="Dynamic" ValidationGroup="HospitalAddEdit" ForeColor="#FF3300" InitialValue="-1"></asp:RequiredFieldValidator>
                        </small>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="City" class="col-md-3 col-form-label">Select City :</label>
                    <div class="col-md-9">
                        <asp:DropDownList ID="ddlCity" CssClass="form-control" runat="server"></asp:DropDownList>
                        <small id="Small1" class="form-text text-muted">
                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Select City Name" ControlToValidate="ddlCity" Display="Dynamic" ValidationGroup="HospitalAddEdit" ForeColor="#FF3300" InitialValue="-1"></asp:RequiredFieldValidator>
                        </small>
                    </div>
                </div>
                <%--               <div class="form-group row">
                    <label for="State" class="col-md-3 col-form-label">Select State :</label>
                    <div class="col-md-9">
                        <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server"></asp:DropDownList>
                        <small id="Small3" class="form-text text-muted">
                            <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Select State Name" ControlToValidate="ddlState" Display="Dynamic" ValidationGroup="HospitalAddEdit" ForeColor="#FF3300" InitialValue="-1"></asp:RequiredFieldValidator>
                        </small>
                    </div>
                </div>--%>
            </div>
            <div class="col-md-12 offset-10">
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-outline-success" ValidationGroup="HospitalAddEdit" OnClick="btnSave_Click" />
                <asp:HyperLink ID="hlCancel" runat="server" NavigateUrl="~/AdminPanel/Hospital/HospitalList.aspx" Text="Cancel" CssClass="btn btn-outline-danger"></asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>

