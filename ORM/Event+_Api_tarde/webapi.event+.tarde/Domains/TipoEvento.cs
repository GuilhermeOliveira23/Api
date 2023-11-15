﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    //usar nameof quando for fazer uma referência a uma classe ou atributo

    [Table(nameof(TipoEvento))]
    public class TipoEvento
    {
        [Key]
        public Guid IdTipoEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Titulo do tipo de evento obrigatório!")]
        public string? Titulo { get; set; }





    }
}