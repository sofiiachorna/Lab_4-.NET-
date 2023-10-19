namespace ProcessingLayer
{
    public class TextComponent : ITextComponent
    {
        private readonly string destination;
        public TextComponent(string text)
        {
            destination = text;
        }
        public void transform(string text)
        {
            using (StreamWriter sw = new StreamWriter(destination))
            {
                sw.WriteLine(text);
            }
        }
        public string read()
        {
            using (StreamReader sr = new StreamReader(destination))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
