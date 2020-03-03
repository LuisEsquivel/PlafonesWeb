namespace PlafonesWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductosModels
    {


        [Key]
        [Display(Name = "Cve")]
        public string CVE_PROD_VAR { get; set; }
        [Display(Name = "Producto")]
        public string NOM_PROD_VAR { get; set; }
        [Display(Name = "Descripción")]
        public string DESC_PROD_VAR { get; set; }
        [Display(Name = "Peso")]
        public decimal PESO_DEC { get; set; }
        [Display(Name = "Imagen")]
        public string RUTADEFOTO_VAR { get; set; }

        [Display(Name = "Precio de Venta")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal COSTO_PROMEDIO_DEC { get; set; }
        [Display(Name = "Ficha Tecnica")]
        public string FICHA_TECNICA_URL_VAR { get; set; }
        [Display(Name = "Ancho")]
        public string ANCHO_VAR { get; set; }
        [Display(Name = "Largo")]
        public string ALTO_VAR { get; set; }
        [Display(Name = "Espesor")]
        public string ESPESOR_VAR { get; set; }
        [Display(Name = "Sugerencia de Uso")]
        public string SUG_USO_VAR { get; set; }
        [Display(Name = "Clase")]
        public string CVE_CLASE_VAR { get; set; }

        [Display(Name = "Unidad de Medida")]
        public string UNIDAD_MEDIDA_VAR { get; set; }
        [Display(Name = "SubClase")]
        public string CVE_SUBCLASE_VAR { get; set; }

        [Display(Name = "Marca")]
        public string MARCA_VAR { get; set; }
    }
}
