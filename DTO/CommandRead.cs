namespace Commander.DTO
{
    public class CommandRead
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        
        // As an example, this property will be
        // excluded from this DTO
        //public string Platform { get; set; }
    }
}