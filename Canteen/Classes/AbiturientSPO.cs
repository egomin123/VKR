﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Classes
{
    public class AbiturientSPO
    {

        public int ID_Abiturient { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int SeriesPasport { get; set; }
        public int NumberPasport { get; set; }
        public int FirstDirectionBall { get; set; }
        public int SecondDirectionBall { get; set; }
        public int ThiredDerictionBall { get; set; }
        public int ID_FirstDirection { get; set; }
        public int ID_SecondDirection { get; set; }
        public int ID_ThiredDeriction { get; set; }

        public string FirstDirection { get; set; }
        public string SecondDirection { get; set; }
        public string ThiredDeriction { get; set; }

        public int SummBall { get; set; }
    }
}