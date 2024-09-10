using Samurai001.Repository.Models;

namespace Samurai001.Repository.Repositories
{
    public interface ITirsdag
    {
        public List<Samurai> getAll();
        public IEnumerable<Samurai> getAllWhere();
    }
}