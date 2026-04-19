namespace WhisperTranscriber
{
    public class SrtBlock
    {
        public int Number { get; set; }
        public string Timestamp { get; set; } = "";
        public string OriginalText { get; set; } = "";
        public string? ProposedText { get; set; }
        public bool HasChange => ProposedText != null && ProposedText != OriginalText;
    }
}
