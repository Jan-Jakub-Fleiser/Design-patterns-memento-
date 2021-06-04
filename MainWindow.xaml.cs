using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Caretaker caretaker = new Caretaker();
        Originator originator = new Originator();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            createMemento();
        }

        private void lstBox_memento_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            updateList();
        }
        private void tb_text_KeyUp(object sender, KeyEventArgs e)
        {
            //if(e.Key== Key.Return || e.Key == Key.Space || e.Key == Key.OemPeriod)
            //{
            //    createMemento();
            //}
        }

        private void btn_undo_Click(object sender, RoutedEventArgs e)
        {
            originator.restoreFromMemento(caretaker.undo());
            tb_text.Text = "";
            tb_text.Text = originator.GetWord();

        }

        private void btn_redo_Click(object sender, RoutedEventArgs e)
        {
            //This could be in a method
            originator.restoreFromMemento(caretaker.redo());

            tb_text.Text = "";
            tb_text.Text = originator.GetWord();
        }

        private void createMemento()
        {
            if (!caretaker.DoesThisExsit(tb_text.Text.Trim()))
            {
                btn_undo.IsEnabled = true;

                originator.setWord(tb_text.Text);
                caretaker.addMemento(originator.createMemento());

                //Memento temp = originator.createMemento(tb_text.Text.Trim());
                //caretaker.Push(temp);

                updateList();
            }

        }

        private void updateList()
        {
            lstBox_memento.Items.Clear();
            for (int i = 0; i < caretaker.count(); i++)
            {
                lstBox_memento.Items.Add(caretaker.getMemento(i).GetWord());
            }
        }
    }
}
