using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv06
{
    abstract class Objekt3D : GrObjekt
    {
        public abstract double SpoctiPovrch();
        public abstract double SpoctiObjem();
    }

}
