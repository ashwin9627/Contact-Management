<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ContactForm.aspx.cs" Inherits="ContactManagementWebForm.ContactForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        label{
            color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       
    <section class="card shadow mx-5 mb-5">
        <div class="card-header card-title text-center">Application Form</div>
        <div class="card-body">
            <%--firstName --%>
            <div class="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label ID="lbl1" runat="server" Text="firstName : "></asp:Label>

                </div>
                <div class="col-5 text-left">
                    <asp:TextBox ID="firstName1" runat="server" CssClass="form-control"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorfirstname" runat="server"
                        ControlToValidate="firstName1" Display="Static" Text="*"
                        ErrorMessage="first name is required"
                        CssClass="text-danger" />
                    <asp:RegularExpressionValidator ID="RegularValiFirstName" runat="server"
                        ControlToValidate="firstName1" Display="Static" Text="*"
                        ErrorMessage="Enter a valid Name,Name should not contain number or special characters"
                        CssClass="text-danger" ValidationExpression="/^[a-zA-Z ]+$/"  />

                </div>
            </div>

              <%--MiddleName --%>
            <div class="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label ID="Label1" runat="server" Text="MiddleName : "></asp:Label>

                </div>
                <div class="col-5 text-left">
                    <asp:TextBox ID="MiddleName1" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMiddleName" runat="server"
                        ControlToValidate="MiddleName1" Display="Static" Text="*"
                        ErrorMessage="Middle name is required"
                        CssClass="text-danger" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorMiddleName" runat="server"
                        ControlToValidate="MiddleName1" Display="Static" Text="*"
                        ErrorMessage="Enter a valid Name,Name should not contain number or special characters"
                        CssClass="text-danger" ValidationExpression="/^[a-zA-Z ]+$/"  />
                </div>
            </div>

              <%--LastName --%>
            <div class="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label ID="Label2" runat="server" Text="LastName : "></asp:Label>

                </div>
                <div class="col-5 text-left">
                    <asp:TextBox ID="LastName1" runat="server" CssClass="form-control"></asp:TextBox>

                      <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server"
                        ControlToValidate="LastName1" Display="Static" Text="*"
                        ErrorMessage="Last name is required"
                        CssClass="text-danger" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="LastName1" Display="Static" Text="*"
                        ErrorMessage="Enter a valid Name,Name should not contain number or special characters"
                        CssClass="text-danger" ValidationExpression="/^[a-zA-Z ]+$/"  />


                </div>
            </div>
             <%--Email --%>
            <div class="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label ID="Label7" runat="server" Text="Email : "></asp:Label>

                </div>
                <div class="col-5 text-left">
                    <asp:TextBox ID="Email" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                        ControlToValidate="Email" Display="Static" Text="*"
                        ErrorMessage=" Date Required"
                        CssClass="text-danger" />

                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                        ControlToValidate="LastName1" Display="Static" Text="*"
                        ErrorMessage="Enter a valid Name,Name should not contain number or special characters"
                        CssClass="text-danger" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  />

                </div>
            </div>

              <%--BirthDay --%>
            <div class="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label ID="Label3" runat="server" Text="BirthDay : "></asp:Label>

                </div>
                <div class="col-5 text-left">
                    <asp:TextBox ID="BirthDay1" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="birth1val" runat="server"
                        ControlToValidate="BirthDay1" Display="Static" Text="*"
                        ErrorMessage=" Date Required"
                        CssClass="text-danger" />
                    <asp:RangeValidator ID="RequiredFieldValidatorRange" runat="server"
                        ControlToValidate="BirthDay1" Display="Static" Text="*"
                        ErrorMessage=" Date Required"
                        CssClass="text-danger" Operator="DataTypeCheck" Type="Date" MinimumValue="01/01/1940" MaximumValue="31/12/2001" />

                     <asp:CompareValidator ID="DateValidator" runat="server"
                                ControlToValidate="BirthDay1" Display="Static" Text="*"
                                CssClass=" text-danger" ErrorMessage="Invalid Date"
                                Operator="DataTypeCheck" Type="Date"/>
                </div>
            </div>

              <%--HomeNumber --%>
            <div class="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label ID="Label4" runat="server" Text="HomeNumber : "></asp:Label>

                </div>
                <div class="col-5 text-left">
                    <asp:TextBox ID="HomeNumber1" runat="server" CssClass="form-control"></asp:TextBox>
                
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="HomeNumber1" Display="Static" Text="*"
                        ErrorMessage=" Date Required"
                        CssClass="text-danger" />

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                        ControlToValidate="HomeNumber1" Display="Static" Text="*"
                        ErrorMessage="Not a valid number"
                        CssClass="text-danger" ValidationExpression="^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}"  />
                
                </div>
            </div>

              <%--WorkNumber --%>
            <div class="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label ID="Label5" runat="server" Text="WorkNumber : "></asp:Label>

                </div>
                <div class="col-5 text-left">
                    <asp:TextBox ID="WorkNumber1" runat="server" CssClass="form-control"></asp:TextBox>
                
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="WorkNumber1" Display="Static" Text="*"
                        ErrorMessage=" Date Required"
                        CssClass="text-danger" />

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                        ControlToValidate="WorkNumber1" Display="Static" Text="*"
                        ErrorMessage="Not a valid number"
                        CssClass="text-danger" ValidationExpression="^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}"  />
                </div>
            </div>

              <%--MobileNumber --%>
            <div class="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label ID="Label6" runat="server" Text="MobileNumber : "></asp:Label>

                </div>
                <div class="col-5 text-left">
                    <asp:TextBox ID="MobileNumber1" runat="server" CssClass="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatormob" runat="server"
                        ControlToValidate="MobileNumber1" Display="Static" Text="*"
                        ErrorMessage=" Date Required"
                        CssClass="text-danger" />

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                        ControlToValidate="MobileNumber1" Display="Static" Text="*"
                        ErrorMessage="Not a valid mobile number"
                        CssClass="text-danger" ValidationExpression="^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}"  />
                </div>
            </div>

  <div class="col-2 offset-3 text-right">
            <div class="form-row">
                <div class="col-4 offset-4 btn-group-lg text-center">
                 <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary mx-2" OnClick="BtnSave_Click" />
            
                </div>
            </div>
      </div>

            </div>
   </section>

</asp:Content>
