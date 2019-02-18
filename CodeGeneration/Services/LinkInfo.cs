namespace Quantumart.QP8.CoreCodeGeneration.Services
{
    public class LinkInfo
    {
        public int Id { get; set; }
        public string MappedName { get; set; }
        public string PluralMappedName { get; set; }
        public int ContentId { get; set; }
        public int LinkedContentId { get; set; }
        public bool IsSelf { get; set; }
    }
}
