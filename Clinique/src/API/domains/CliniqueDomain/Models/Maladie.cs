﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueDomain.Models
{
    public class Maladie
    {
        public int Id { get; set; }
        public string Pathologie { get; set; } = string.Empty;
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
        public ICollection<Soin>Soins { get; set; } = new List <Soin>();

    }
}
