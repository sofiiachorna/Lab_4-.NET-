using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public interface IOutput
    {
        void translate();
        void retranslate();
        void correctCase();
        void recorrect();
        void correctAndTranslate();
        void retranslateAndRecorrect();
        void writeToFile();
        void readFromFile();
    }
}
