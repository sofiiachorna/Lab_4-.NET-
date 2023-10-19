
namespace ProcessingLayer
{
    public abstract class BaseDecorator : ITextComponent
    {
        protected ITextComponent wrapee;
        public BaseDecorator(ITextComponent wrapee)
        {
            this.wrapee = wrapee;
        }
        public virtual void transform(string text)
        {
            this.wrapee.transform(text);
        }
        public virtual string read()
        {
            return this.wrapee.read();
        }
    }
}
