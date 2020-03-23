



  // $(document).ready(function (){
  //      $('.soloNumeros').keyup(function () {
		//	this.value = (this.value + '').replace(/[^0-9]/g, '');
		//});
  // });

jQuery(document).ready(function () {
	jQuery('.soloNumeros').keypress(function (tecla) {
		if (tecla.charCode < 48 || tecla.charCode > 57) return false;
	});
});




   $('#textArea').prop("required", true);




function validar() {

	//Almacenamos los valores
	nombre = $('#telefono').val();

	//Comprobamos la longitud de caracteres
	if (nombre.length < 8) {
		$('#telefono').prop("required", true);
	}
	else {
		$('#telefono').prop("required", false);

	}

}



