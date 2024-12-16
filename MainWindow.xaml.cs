using System.ComponentModel;
using System.Runtime.CompilerServices;
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


namespace PracticeProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        string[] Story = {
            "True,", "Nervous,", "very,", "very", "dreadfully", "nervous", "I", "had", "been", "and", "am;",
            "but", "why", "will", "you", "say", "that", "I", "am", "mad?", "The", "disease", "had", "sharpened",
            "my", "senses", "—", "not", "destroyed", "—", "not", "dulled", "them.", "Above", "all", "was", "the",
            "sense", "of", "hearing", "acute.", "I", "heard", "all", "things", "in", "the", "heaven", "and", "in",
            "the", "earth.", "I", "heard", "many", "things", "in", "hell.", "How,", "then,", "am", "I", "mad?",
            "Hearken!", "and", "observe", "how", "healthily", "—", "how", "calmly", "I", "can", "tell", "you",
            "the", "whole", "story.", "It", "is", "impossible", "to", "say", "how", "first", "the", "idea", "entered",
            "my", "brain;", "but", "once", "conceived,", "it", "haunted", "me", "day", "and", "night.", "Object",
            "there", "was", "none.", "Passion", "there", "was", "none.", "I", "loved", "the", "old", "man.",
            "He", "had", "never", "wronged", "me.", "He", "had", "never", "given", "me", "insult.", "For", "his",
            "gold", "I", "had", "no", "desire.", "I", "think", "it", "was", "his", "eye!", "yes,", "it", "was",
            "this!", "One", "of", "his", "eyes", "resembled", "that", "of", "a", "vulture", "—", "a", "pale", "blue",
            "eye,", "with", "a", "film", "over", "it.", "Whenever", "it", "fell", "upon", "me,", "my", "blood", "ran",
            "cold;", "and", "so", "by", "degrees", "—", "very", "gradually", "—", "I", "made", "up", "my", "mind",
            "to", "take", "the", "life", "of", "the", "old", "man,", "and", "thus", "rid", "myself", "of", "the", "eye",
            "forever.", "Now", "this", "is", "the", "point.", "You", "fancy", "me", "mad.", "Madmen", "know", "nothing.",
            "But", "you", "should", "have", "seen", "me.", "You", "should", "have", "seen", "how", "wisely", "I",
            "proceeded", "—", "with", "what", "caution", "—", "with", "what", "foresight", "—", "with", "what",
            "dissimulation", "I", "went", "to", "work!", "I", "was", "never", "kinder", "to", "the", "old", "man",
            "than", "during", "the", "whole", "week", "before", "I", "killed", "him.", "And", "every", "night,",
            "about", "midnight,", "I", "turned", "the", "latch", "of", "his", "door", "and", "opened", "it", "—", "oh,",
            "so", "gently!", "And", "then,", "when", "I", "had", "made", "an", "opening", "sufficient", "for", "my",
            "head,", "I", "put", "in", "a", "dark", "lantern,", "all", "closed,", "closed,", "so", "that", "no",
            "light", "shone", "out,", "and", "then", "I", "thrust", "in", "my", "head.", "Oh,", "you", "would", "have",
            "laughed", "to", "see", "how", "cunningly", "I", "thrust", "it", "in!", "I", "moved", "it", "slowly",
            "—", "very,", "very", "slowly,", "so", "that", "I", "might", "not", "disturb", "the", "old", "man’s",
            "sleep.", "It", "took", "me", "an", "hour", "to", "place", "my", "whole", "head", "within", "the", "opening",
            "so", "far", "that", "I", "could", "see", "him", "as", "he", "lay", "upon", "his", "bed.", "Ha!", "—",
            "would", "a", "madman", "have", "been", "so", "wise", "as", "this?", "And", "then,", "when", "my", "head",
            "was", "well", "in", "the", "room,", "I", "undid", "the", "lantern", "cautiously", "—", "oh,", "so", "cautiously"
        };
        string messageBoxText = "Game has finished";

        private int _correct;
        public int Correct 
        {
            get { return _correct; }
            set
            {
                if (_correct != value)
                {
                    _correct = value;
                    OnPropertyChanged();
                }

            }
        }
        private int _incorrect;
        public int Incorrect
        {
            get { return _incorrect; }
            set
            {
                if (_incorrect != value)
                {
                    _incorrect = value;
                    OnPropertyChanged();
                }

            }
        }
        Random random = new Random();
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            TextBlock.Text = "I will be a random word";
            Textbox.Text="Press start and begin typing";

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string proppertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proppertyName));
        }

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                IsWordCorrect(this, e);
                TextBlock.Text = Story[random.Next(Story.Length)];
                Textbox.Text = null;


            }
        }
        private void IsWordCorrect(object sender, KeyEventArgs e) {
            if (Textbox.Text == TextBlock.Text)
            {
                _correct++;
                TextBlock.Text = Story[random.Next(0, Story.Length)];
                Textbox.Text = null;
            }
            else
            {
                _incorrect++;
                TextBlock.Text = Story[random.Next(0, Story.Length)];
                Textbox.Text = null;

            }
            lblCorrect.Content = "Correct" + _correct;
            lblIncorrect.Content="Incorrect "+ _incorrect;
        }

        private void StartClicked(object sender, RoutedEventArgs e)
        {
            Textbox.Focus();
            TextBlock.Text = Story[random.Next(0, Story.Length)];
            Textbox.Text= null;
            _correct = 0;
            _incorrect = 0;
        }

        private void StopClicked(object sender, RoutedEventArgs e)
        {
            
        }
       
    }
}