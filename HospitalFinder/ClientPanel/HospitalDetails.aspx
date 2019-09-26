<%@ Page Title="" Language="C#" MasterPageFile="~/Contant/MasterPage/ClientMasterPage.master" AutoEventWireup="true" CodeFile="HospitalDetails.aspx.cs" Inherits="ClientPanel_HospitalDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container">
        <div class="shadow-lg p-2 mb-5 bg-success rounded text-xl-center font-weight-bold">HOSPITAL DETAILS <i class="fas fa-info-circle" style="font-size:x-large"></i></div>
        <div class="shadow-lg card">
            <div class="card bg-light">
                <div class="card-body text-left">
                    <div class="row">

                        <div class="col-md-12">
                            <asp:label id="lblMessage" runat="server" cssclass="badge badge-success"></asp:label>
                        </div>

                        <div class="col-md-12">
                            <div class="form-group row">
                                <label for="HospitalName" class="col-md-3 col-form-label font-weight-bolder" >
                                    <i class="fas fa-hospital" style="font-size:x-large"></i> Hospital Name : 
                                </label>
                                <span id="txtHospitalName" class="col-md-6" runat="server"></span>
                            </div>
                            <div class="form-group row ">
                                <label for="Address" class="col-md-3 col-form-label font-weight-bolder">
                                    <i class="fas fa-address-card" style="font-size:x-large"></i> Address : 
                                </label>
                                <span id="txtAddress" class="col-md-6" runat="server"></span>
                            </div>
                            <div class="form-group row ">
                                <label for="MobileNumber" class="col-md-3 col-form-label font-weight-bolder">
                                    <i class="fas fa-mobile-alt" style="font-size:x-large"></i> MobileNumber : 
                                </label>
                                <span id="txtMobileNumber" class="col-md-6" runat="server"></span>
                            </div>
                            <div class="form-group row ">
                                <label for="TelephoneNumber" class="col-md-3 col-form-label font-weight-bolder">
                                    <i class="fas fa-tty" style="font-size:x-large"></i> TelephoneNumber : 
                                </label>
                                <span id="txtTelephoneNumber" class="col-md-6" runat="server"></span>
                            </div>
                            <div class="form-group row " style="color: red">
                                <label for="EmergencyNumber" class="col-md-3 col-form-label font-weight-bolder">
                                    EmergencyNumber : 
                                </label>
                                <span id="txtEmergencyNumber" class="col-md-6" runat="server"></span>
                            </div>
                            <div class="form-group row ">
                                <label for="AmbulanceNumber" class="col-md-3 col-form-label font-weight-bolder">
                                    <i class="fas fa-ambulance" style="font-size:x-large"></i>AmbulanceNumber : 
                                </label>
                                <span id="txtAmbulancePhoneNumber" class="col-md-6" runat="server"></span>
                            </div>
                            <div class="form-group row ">
                                <label for="Website" class="col-md-3 col-form-label font-weight-bolder">
                                    Website : 
                                </label>
                                <span id="txtWebsite" class="col-md-6" runat="server"></span>
                            </div>
                            <div class="form-group row ">
                                <label for="EmailID" class="col-md-3 col-form-label font-weight-bolder">
                                    <i class="fas fa-envelope" style="font-size:x-large"></i> EmailID : 
                                </label>
                                <span id="txtEmailID" class="col-md-6" runat="server"></span>
                            </div>
                            <div class="form-group row ">
                                <label for="Fax" class="col-md-3 col-form-label font-weight-bolder">
                                    <i class="fas fa-fax" style="font-size:x-large"></i> Fax : 
                                </label>
                                <span id="txtFax" class="col-md-6" runat="server"></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

