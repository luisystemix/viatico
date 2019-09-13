function AceptaNumero(evt) 
    {
        var nav4 = window.Event ? true : false;
        var key = nav4 ? evt.which : evt.keyCode; 
        return (key <= 13 || (key >= 48 && key <= 57)); 

    }
function AceptaNumeroD(evt) 
    {
        var nav4 = window.Event ? true : false;
        var key = nav4 ? evt.which : evt.keyCode; 
        return (key <= 13 || (key >= 48 && key <= 57) || key == 46); 

}
function AceptaNumeroTelel(evt) {
    var nav4 = window.Event ? true : false;
    var key = nav4 ? evt.which : evt.keyCode;
    return (key <= 13 || (key >= 48 && key <= 57) || key == 47);

}
function toUpper(control) {

    if (/[a-z]/.test(control.value)) {
        control.value = control.value.toUpperCase();
    }
}