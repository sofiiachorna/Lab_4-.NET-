using System.Text;

namespace ProcessingLayer
{
    public class CaseCorrectionDecorator : BaseDecorator
    {
        private static bool[] characterUpper;
        public CaseCorrectionDecorator(ITextComponent wrapee) : base(wrapee) { }

        public override void transform(string text)
        {
            CustomString(text);
            string value = CaseCorrection(text);
            base.transform(value);
        }
        public override string read()
        {
            var text = base.read();
            return UpdateValue(text);
        }
        public string CaseCorrection(string text)
        {
            string[] args = text.Split(". ");
            for (int i = 0; i < args.Length; i++)
            {
                args[i] = args[i].Substring(0, 1).ToUpper() +
                args[i].Substring(1).ToLower();
            }
            return string.Join(". ", args);
        }
        //Зворотнє перетворення
        //Масив для збереження початкової стрічки
        public static void CustomString(string text)
        {
            string value = text.Trim(new char[] { '\n', '\r' });
            characterUpper = new bool[value.Length];

            // Ініціалізуємо масив інформації про регістр
            for (int i = 0; i < value.Length; i++)
            {
                characterUpper[i] = char.IsUpper(value[i]);
            }
        }
        public string UpdateValue(string value)
        {
            // Оновлюємо значення рядка на підставі інформації про регістр
            string text = value.Trim(new char[] { '\n', '\r' });
            StringBuilder newValue = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (characterUpper[i])
                {
                    newValue.Append(char.ToUpper(text[i]));
                }
                else
                {
                    newValue.Append(char.ToLower(text[i]));
                }
            }
            return newValue.ToString();
        }
    }
}
