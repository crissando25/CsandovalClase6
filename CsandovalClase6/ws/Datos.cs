using System;
using System.Collections.Generic;
using System.Text;

namespace CsandovalClase6.ws
{
    public class Datos
    {
        public int Tbl_jz_id { get; set; }

        public enum tbl_jz_nombre {Delicia,
                                   Calderon,
                                   Eugenio_Espejo,
                                    }
        public enum tbl_jz_grupo_t {mañana, 
                                    tarde,
                                   amanecida, 
                                   refuerzo,
                                      }
        public string  tbl_g_observaciones { get; set; }
    }
}
