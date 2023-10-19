using ProcessingLayer;
using System.Text;

namespace PresentationLayer
{
    public class Output :  IOutput
    {
        private ITextComponent component;
        public Output(ITextComponent component)
        {
            this.component = component;
        }
        public void translate()
        {
            Console.WriteLine("Input text:");
            string text = Console.ReadLine();
            var decorator = new TranslationDecorator(component);
            decorator.transform(text);
            Console.WriteLine("Text translated.");
        }
        public void retranslate()
        {
            var decorator = new TranslationDecorator(component);
            string text = decorator.read();
            Console.WriteLine(text);
            Console.WriteLine("Reverse translation completed.");
        }
        public void correctCase()
        {
            Console.WriteLine("Input text:");
            string text = Console.ReadLine();
            var decorator = new CaseCorrectionDecorator(component);
            decorator.transform(text);
            Console.WriteLine("Case corrected.");
        }
        public void recorrect()
        {
            var decorator = new CaseCorrectionDecorator(component);
            string text = decorator.read();
            Console.WriteLine(text);
            Console.WriteLine("Reverse case correction completed.");
        }
        public void correctAndTranslate()
        {
            Console.WriteLine("Input text:");
            string text = Console.ReadLine();
            var decorator1 = new TranslationDecorator(component);
            var decorator2 = new CaseCorrectionDecorator(decorator1);
            decorator2.transform(text);
            Console.WriteLine("Translation and case correction completed.");

        }
        public void retranslateAndRecorrect()
        {
            var decorator1 = new TranslationDecorator(component);
            var decorator2 = new CaseCorrectionDecorator(decorator1);
            string text = decorator2.read();
            Console.WriteLine(text);
            Console.WriteLine("Reverse translation and case correction completed.");
        }
        public void writeToFile()
        {
            Console.WriteLine("Input text:");
            string text = Console.ReadLine();
            component.transform(text);
        }
        public void readFromFile()
        {
            string text = component.read();
            Console.WriteLine(text);
        }
    }
}
