using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Пз_29._3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new NotesViewModel();
        }
    }
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
    public class Note
    {
        public string title {get; set;}
        public string text {get; set;}
    }
    public class NotesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Note> notes;
        public ObservableCollection<Note> Notes
        {
            get {return notes;}
            set
            {
                notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }
        public ICommand noteCommandAdd {get; set;}
        public ICommand noteCommandDelete {get; set;}
        public NotesViewModel()
        {
            Notes = new ObservableCollection<Note>();
            noteCommandAdd = new RelayCommand(AddNote);
            noteCommandDelete = new RelayCommand(RemoveNote);
        }
        public void AddNote(object param)
        {
            Notes.Add(new Note {title = NewNoteTitle, text = NewNoteText});
        }
        private Note selectedNote;
        public Note SelectedNote
        {
            get {return selectedNote;}
            set
            {
                selectedNote = value;
                OnPropertyChanged(nameof(SelectedNote));
            }
        }
        public void RemoveNote(object param)
        {
            Note note = param as Note;
            if (note != null)
            {
                Notes.Remove(note);
            }
        }
        private string noteTitle;
        public string NewNoteTitle
        {
            get {return noteTitle;}
            set
            {
                noteTitle = value;
                OnPropertyChanged(nameof(NewNoteTitle));
            }
        }
        private string noteText;
        public string NewNoteText
        {
            get {return noteText;}
            set
            {
                noteText = value;
                OnPropertyChanged(nameof(NewNoteText));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
