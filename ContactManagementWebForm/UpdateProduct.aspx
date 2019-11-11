<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="ContactManagementWebForm.UpdateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <section class="container mb-5">
        <h2 class="bg-success text-white text-center"> Update a new Product</h2>
        <div class="bg-light text-white-center">Update a New Product
           <%--first Row--%>
            <div class="row">
                <div class="col-4 offset-1">
                    <div class="form-group">
                        <asp:label ID="lblName" runat="server" CssClass="col-form-label text-dark"
                            Text="Product Name" />
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                    </div>
                </div>
                    <div class="col-6">
                    <div class="form-group">
                        <asp:label ID="lblPrice" runat="server" CssClass="col-form-label text-dark"
                            Text="Product Price" />
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </div>
            <%--second row--%>

                 <div class="row">
                <div class="col-4 offset-1">
                    <div class="form-group">
                        <asp:label ID="lblStock" runat="server" CssClass="col-form-label text-dark"
                            Text="Product Stock" />
                        <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" />
                    </div>
                </div>
                    <div class="col-6">
                    <div class="form-group">
                        <asp:label ID="lblCatg" runat="server" CssClass="col-form-label text-dark"
                            Text="Category" />
                        <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </div>
       
            <%--third row--%>

                 <div class="row">
                <div class="col-4 offset-1">
                    <div class="form-group">
                        <asp:label ID="lblDiscontinued" runat="server" CssClass="col-form-label text-dark"
                            Text="Discontinue" />
                        <asp:Checkbox ID="chkDiscontinued" runat="server" CssClass="ml-3 fom-check-inline" />
                    </div>
                </div>
            </div>
       


            <div class="row">
            <div class="col-8 offset-2">
                <asp:LinkButton ID="btnSave" runat="server" 
                    CssClass="btn btn-primary m-1 p-4 w-25"
                    OnClick="btnSave_Click">
                    <i class="fa fa-save"></i>Save
                </asp:LinkButton>

                  <asp:LinkButton ID="btnCancel" runat="server" 
                    CssClass="btn btn-danger m-1 p-2 w-25"
                    OnClick="btnCancel_Click">
                    <i class="fa fa-sign-out"></i>Discard
                </asp:LinkButton>
            </div>
        </div>
            </div>

    </section>



</asp:Content>
