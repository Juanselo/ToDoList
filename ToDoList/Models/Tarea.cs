﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaLimite { get; set; }
        public bool Completada { get; set; }

    }
}
