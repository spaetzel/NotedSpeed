using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sharpnote;

namespace NotedSpeed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SharpnoteRepository<Note> _repository;
        private IEnumerable<Note> _index;
        string _lastText;

        private IEnumerable<Note> Index
        {
            get
            {
                return _index;
            }
        }

        private SharpnoteRepository<Note> Repository
        {
            get
            {
                if (_repository == null)
                {
                    _repository = SharpnoteRepository<Note>.Instance;
                    _repository.Connect(Settings.Default.Email, Settings.Default.Password);
                }

                return _repository;

            }
        }
        public MainWindow()
        {
            InitializeComponent();

            var partialNotes = Repository.GetIndex();

            _index = from Note note in partialNotes
                     select Repository.GetNote(note.Key);
            
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_lastText != searchBox.Text.Trim())
            {
                _lastText = searchBox.Text.Trim();

                var matches = from n in Index
                              where n.Content.Contains(_lastText)
                              select n;

                searchResults.ItemsSource = from m in matches
                                            select new
                                            {
                                                Key = m.Key,
                                                Title = m.Content.Split('\n').First(),
                                                Content = m.Content,
                                                Modified = m.Modified
                                            };
            }                

        }
    }
}
