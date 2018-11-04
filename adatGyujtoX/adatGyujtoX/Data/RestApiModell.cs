using System;
using System.Collections.Generic;
using System.Text;

namespace adatGyujtoX.Data
{
    class RestApiModell
    {


        public class Rootobject
        {
            public bool error { get; set; }
            public string message { get; set; }
            public string id { get; set; }
            public string proj_id { get; set; }
            public string kerdiv1_nev { get; set; }
            public string kerdiv1_ver { get; set; }
            public string kerdiv2_le { get; set; }
            public int darab { get; set; }
            public Kerdivadat[] kerdivadat { get; set; }
        }

        public class Kerdivadat
        {
            public string id { get; set; }
            public string proj_id { get; set; }
            public string kerdiv1_nev { get; set; }
            public string kerdiv1_ver { get; set; }
            public int kerdiv2_le { get; set; }
            public string kerdiv1_title { get; set; }
            public string kerdivtip { get; set; }
            public string fugg_proj { get; set; }
            public string fugg_par { get; set; }
            public string fugg_par_ertek { get; set; }
        }


    }
}
