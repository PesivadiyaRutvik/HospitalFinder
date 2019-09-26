<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Contant/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="HospitalList.aspx.cs" Inherits="AdminPanel_Hospital_HospitalList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    <asp:Label ID="lblHeader" runat="server" Text="Hospital List"></asp:Label></h1>
                <br />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <asp:HyperLink ID="hlAddHospital" runat="server" NavigateUrl="~/AdminPanel/Hospital/HospitalAddEdit.aspx" Text="Add Hospital" CssClass="btn btn-outline-primary m-3"></asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="col-md-12">
            <div style="overflow-x: inherit">
                <asp:GridView ID="gvHospitalList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover mt-5" OnRowCommand="gvHospitalList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="SrNo" HeaderText="Sr.No." />
                        <asp:BoundField DataField="HospitalName" HeaderText="HospitalName" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="CityName" HeaderText="City" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" />
                        <asp:BoundField DataField="CategoryType" HeaderText="CategoryType" />
                        <asp:BoundField DataField="EmailID" HeaderText="EmailID" />
                        <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" />
                        <asp:BoundField DataField="TelephoneNumber" HeaderText="TelephoneNumber" />
                        <asp:BoundField DataField="Fax" HeaderText="Fax" />
                        <asp:BoundField DataField="Website" HeaderText="Website" />
                        <asp:BoundField DataField="AmbulancePhoneNumber" HeaderText="AmbulancePhoneNumber" />
                        <asp:BoundField DataField="EmergencyNumber" HeaderText="EmergencyNumber" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-warning" NavigateUrl='<%# "~/AdminPanel/Hospital/HospitalAddEdit.aspx?HospitalID=" + Eval("HospitalID") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-outline-danger ml-3" CommandName="DeleteRecord" CommandArgument='<%# Eval("HospitalID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

