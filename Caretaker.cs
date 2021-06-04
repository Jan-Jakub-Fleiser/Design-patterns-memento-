using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    class Caretaker
    {
        private List<Memento> mementos = new List<Memento>();
        private int currentState = -1;

        public void addMemento(Memento memento)
        {
            mementos.Add(memento);
            currentState = mementos.Count() - 1;
        }

        public Memento getMemento(int inIndex)
        {
            return mementos[inIndex];
        }

        public Memento undo()
        {

            if (currentState <= 0)
            {
                currentState = 0;
                return mementos[0];
            }

            currentState--;
            return getMemento(currentState);
        }

        public Memento redo()
        {
            if(currentState >= mementos.Count() - 1)
            {
                currentState = mementos.Count() - 1;
                return getMemento(currentState);
            }

            currentState++;
            return getMemento(currentState);
        }

        public int count()
        {
            return mementos.Count();
        }

        public bool DoesThisExsit(string inString)
        {
            Memento findIt = mementos.Find(x => x.GetWord().Equals(inString));

            if (findIt == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
