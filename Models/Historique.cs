using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_POO2.Models
{
     public class Historique
    {
        public int Id { get; set; }
        public string NameOfPatient { get; set; }
        public DateTime DateOfPrediction { get; set; }
        public string Resultat { get; set; }
        public int K { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}
