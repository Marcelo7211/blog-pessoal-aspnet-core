﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace blogPessoal.Model
{
    public class Tema
    {
        private int v1;
        private string v2;

       

        [Key]
        public int Id { get; set; }
        
        public string Descricao { get; set; }

        [JsonIgnore]
        public List<Postagem> Postagem { get; set; }

    }
}
