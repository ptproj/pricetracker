using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IPackageDl
    {
        public  Task<List<Package>> get();
    }
}