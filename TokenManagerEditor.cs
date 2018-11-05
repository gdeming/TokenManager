using System.Windows.Forms;

namespace TokenManager
{
    internal class TokenManagerEditor : TabPage
    {
        public TokenManagerEditor() { }

        protected TokenManagerEditor(TokenManagerModel model)
        {
            Model = model;
        }

        public virtual void AcceptChanges() { }

        public virtual void RevertChanges() { }

        public TokenManagerModel Model { get; }
    }
}
