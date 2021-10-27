namespace GoToCSharp
{
    public class Currency
    {
        public string CodeNBU { get; set; }     
        public string Name { get; set; }     
        public float Rate { get; set; }

        public override string ToString()
        {
            return $" | {CodeNBU.PadRight(1)} | {Name.PadRight(35)} | {Rate.ToString().PadRight(10)} |";
        }
    }
}