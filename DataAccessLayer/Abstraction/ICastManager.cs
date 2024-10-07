using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Class;

namespace BusinessLayer.Abstraction
{
    public interface ICastManager<Cast>
    {
        List<Cast> GetAllCasts();
        void addCast(Cast cast);
        void removeCast(Cast cast);
        void updateCast(Cast cast);
        Cast GetCastById(int id);
    }
}
