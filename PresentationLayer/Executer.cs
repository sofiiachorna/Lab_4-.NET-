using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ProcessingLayer;

namespace PresentationLayer
{
    public class Executer : IExecuter
    {
        private IOutput output;
        public void createOutput(ITextComponent component)
        {
            this.output = new Output(component);
        }
        public void execute()
        {
            ITextComponent text = new TextComponent("D:\\kpi\\2 KURS\\.NET labs\\Lab_4\\text.txt");
            createOutput(text);
            Dictionary<methods, Action> commands = new Dictionary<methods, Action>()
            {
                {methods.translate,output.translate },
                {methods.retranslate,output.retranslate },
                {methods.correctCase,output.correctCase},
                {methods.recorrect,output.recorrect},
                {methods.correctAndTranslate,output.correctAndTranslate},
                {methods.retranslateAndRecorrect,output.retranslateAndRecorrect},
                {methods.writeToFile,output.writeToFile},
                {methods.readFromFile,output.readFromFile}
            };
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Translate text\n" +
            "2. Retranslate text\n" +
            "3. Correct case in sentences\n" +
            "4. Recorect case in sentences\n" +
            "5. Correct case in sentences and translate them\n" +
            "6. Show initial text\n" +
            "7. Write text into file\n" +
            "8. Read text from file\n");
            string a = "";
            while(a != "yes")
            {
                int num = int.Parse(Console.ReadLine());
                if(Enum.TryParse((num-1).ToString(),out methods method)&& commands.ContainsKey(method))
                {
                    commands[method]();

                }
                else { Console.WriteLine("choose valid option"); }
                Console.WriteLine("do you want to exit the program?");
                a = Console.ReadLine();

            }
        }
        

    }
     public enum methods
     {
         translate,
         retranslate,
         correctCase,
         recorrect,
         correctAndTranslate,
         retranslateAndRecorrect,
         writeToFile,
         readFromFile
     }
    
}
