function Validar() {

    if (!$('#Validade').val() == '' && !$('#Fabricacao').val() == '' && !$('#Descricao').val() == '') {
        if ($('#Validade').val() >= $('#Fabricacao').val()) {
            return true;
            alert("Ops! Produto salvo!", "warning", 5000);
        }
        else {
            alert("Ops! A data validade deve ser maior que a data fabricação!", "warning", 5000);
            return false;
        }
        
    }
    else {
        alert("Ops! Faltam inserir dados!", "warning", 5000);
        return false;
    }
    
   

}
