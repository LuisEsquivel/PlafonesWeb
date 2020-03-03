using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PlafonesWeb.Models
{
    public class SucursalesModel
    {
        [Key]
        [Display(Name = "Cve")]
        public int CVE_SUCURSAL_INT { get; set; }

        [Display(Name = "Nombre De La Sucursal")]
        [StringLength(100)]
        public string NOMBRE_SUCURSAL_VAR { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(300)]
        public string DIRECCION_VAR { get; set; }

        [Display(Name = "Telefono")]
        public string TELEFONO_VAR { get; set; }

        [Display(Name = "Mapa")]
        public String MAPA_VAR { get; set; }

        [Display(Name = "Imagen")]
        public String RUTA_IMAGEN_VAR { get; set; }


    }
}