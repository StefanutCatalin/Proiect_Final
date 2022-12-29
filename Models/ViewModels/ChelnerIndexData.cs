using System.Security.Policy;

namespace Proiect_Final.Models.ViewModels
{
    public class ChelnerIndexData
    {
        public IEnumerable<Chelner> Chelneri { get; set; }
        public IEnumerable<Rezervare> Rezervari { get; set; }
    }
}
