using Core.Persistence;

namespace Core.Core.Models
{
    public class TeamQuery : IQueryObject
    {
        public int? LeagueId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
