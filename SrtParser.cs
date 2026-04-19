using System.Text;
using System.Text.RegularExpressions;

namespace WhisperTranscriber
{
    public static class SrtParser
    {
        public static List<SrtBlock> Parse(string content)
        {
            var blocks = new List<SrtBlock>();
            var rawBlocks = Regex.Split(content.Trim(), @"\r?\n\r?\n");

            foreach (var raw in rawBlocks)
            {
                var lines = raw.Trim().Split('\n');
                if (lines.Length < 2) continue;
                if (!int.TryParse(lines[0].Trim(), out int number)) continue;
                var timestamp = lines[1].Trim();
                if (!timestamp.Contains("-->")) continue;
                var text = string.Join("\n", lines.Skip(2).Select(l => l.TrimEnd('\r')));
                blocks.Add(new SrtBlock { Number = number, Timestamp = timestamp, OriginalText = text });
            }

            return blocks;
        }

        public static string Serialize(List<SrtBlock> blocks, HashSet<int> acceptedNumbers)
        {
            var sb = new StringBuilder();
            foreach (var b in blocks)
            {
                var useProposed = b.HasChange && acceptedNumbers.Contains(b.Number);
                var text = useProposed ? b.ProposedText! : b.OriginalText;
                sb.AppendLine(b.Number.ToString());
                sb.AppendLine(b.Timestamp);
                sb.AppendLine(text);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static string BlocksToSrtString(IEnumerable<SrtBlock> blocks)
        {
            var sb = new StringBuilder();
            foreach (var b in blocks)
            {
                sb.AppendLine(b.Number.ToString());
                sb.AppendLine(b.Timestamp);
                sb.AppendLine(b.OriginalText);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static void ApplyResponse(string response, Dictionary<int, SrtBlock> byNumber)
        {
            var rawBlocks = Regex.Split(response.Trim(), @"\r?\n\r?\n");
            foreach (var raw in rawBlocks)
            {
                var lines = raw.Trim().Split('\n');
                if (lines.Length < 2) continue;
                if (!int.TryParse(lines[0].Trim(), out int number)) continue;
                if (lines[1].Trim().Contains("-->") && lines.Length >= 3)
                {
                    var proposed = string.Join("\n", lines.Skip(2).Select(l => l.TrimEnd('\r')));
                    if (byNumber.TryGetValue(number, out var block) && proposed != block.OriginalText)
                        block.ProposedText = proposed;
                }
            }
        }
    }
}
