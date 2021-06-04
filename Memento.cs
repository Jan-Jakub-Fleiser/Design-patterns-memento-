using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    class Memento
    {
        private string word;

        public Memento(string inWord)
        {
            this.word = inWord;
        }

        public string GetWord()
        {
            return word;
        }
    }
}
