﻿using System.ComponentModel.DataAnnotations;

namespace P01_2022_PL_601_2023_RR_655.Models
{
    public class Sucursal
    {
        [Key]
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public string Administrador { get; set; }
            public int NumeroEspacios { get; set; }
     

    }
}
