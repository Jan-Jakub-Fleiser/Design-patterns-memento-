using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    class Originator
    {
        private string oneWord;
        public void setWord(string newWord)
        {
            this.oneWord = newWord;
        }

        public string GetWord()
        {
            return oneWord;
        }

        public Memento createMemento()
        {
            return new Memento(oneWord);
        }
        public void restoreFromMemento(Memento memento)
        {
            oneWord = memento.GetWord();
            //return oneWord;
        }





    }

}
