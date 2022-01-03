using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IPackageBl
    {
        public  Task<List<Package>> get();
    }
}