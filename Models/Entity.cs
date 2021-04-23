using IndividualProject.Models.Interfaces;

namespace IndividualProject.Models
{
    public abstract class Entity : IPrintable
    {
        public int Id { get; set; }
    }
}
