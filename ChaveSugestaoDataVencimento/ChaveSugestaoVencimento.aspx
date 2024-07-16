<!-- código omitido -->

<td>
    <asp:Label runat="server" ID="lblPagamento" Text="Condições de Pagamento: "></asp:Label><br />
    <asp:DropDownList runat="server" ID="ddlPagamento" AutoPostBack="true" OnSelectedIndexChanged="ddlPagamento_SelectedIndexChanged" ClientIDMode="Static"></asp:DropDownList>
</td>

<!-- código omitido -->

<td>
    <asp:Label runat="server" ID="lblDataEmissao" Text="Data de emissão: "></asp:Label><br />
    <asp:TextBox runat="server" ID="txtDataEmissao" CssClass="datepicker" ClientIDMode="Static" 
    AutoPostBack="true" OnTextChanged="txtDataEmissao_TextChanged" />
</td>

<!-- código omitido -->

<Triggers>
<asp:AsyncPostBackTrigger ControlID="txtDataEmissao" EventName="TextChanged" />
<asp:AsyncPostBackTrigger ControlID="ddlPagamento" EventName="SelectedIndexChanged" />
<asp:PostBackTrigger ControlID="btnAdicionarParcela" />
</Triggers>