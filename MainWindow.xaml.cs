using System.ComponentModel;
using System.IO;
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
using System.Windows.Threading;


namespace PracticeProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
         

        DispatcherTimer timer;

        int startCount = 60;
        int minCount = 0;
        string[] Story = {
            "True,", "Nervous,", "very,", "very", "dreadfully", "nervous", "I", "had", "been", "and", "am;",
            "but", "why", "will", "you", "say", "that", "I", "am", "mad?", "The", "disease", "had", "sharpened",
            "my", "senses", "*", "not", "destroyed", "*", "not", "dulled", "them.", "Above", "all", "was", "the",
            "sense", "of", "hearing", "acute.", "I", "heard", "all", "things", "in", "the", "heaven", "and", "in",
            "the", "earth.", "I", "heard", "many", "things", "in", "hell.", "How,", "then,", "am", "I", "mad?",
            "Hearken!", "and", "observe", "how", "healthily", "how", "calmly", "I", "can", "tell", "you",
            "the", "whole", "story.", "It", "is", "impossible", "to", "say", "how", "first", "the", "idea", "entered",
            "my", "brain;", "but", "once", "conceived,", "it", "haunted", "me", "day", "and", "night.", "Object",
            "there", "was", "none.", "Passion", "there", "was", "none.", "I", "loved", "the", "old", "man.",
            "He", "had", "never", "wronged", "me.", "He", "had", "never", "given", "me", "insult.", "For", "his",
            "gold", "I", "had", "no", "desire.", "I", "think", "it", "was", "his", "eye!", "yes,", "it", "was",
            "this!", "One", "of", "his", "eyes", "resembled", "that", "of", "a", "vulture", "—", "a", "pale", "blue",
            "eye,", "with", "a", "film", "over", "it.", "Whenever", "it", "fell", "upon", "me,", "my", "blood", "ran",
            "cold;", "and", "so", "by", "degrees", "*", "very", "gradually", "*", "I", "made", "up", "my", "mind",
            "to", "take", "the", "life", "of", "the", "old", "man,", "and", "thus", "rid", "myself", "of", "the", "eye",
            "forever.", "Now", "this", "is", "the", "point.", "You", "fancy", "me", "mad.", "Madmen", "know", "nothing.",
            "But", "you", "should", "have", "seen", "me.", "You", "should", "have", "seen", "how", "wisely", "I",
            "proceeded", "+", "with", "what", "caution", "+", "with", "what", "foresight", "*", "with", "what",
            "dissimulation", "I", "went", "to", "work!", "I", "was", "never", "kinder", "to", "the", "old", "man",
            "than", "during", "the", "whole", "week", "before", "I", "killed", "him.", "And", "every", "night,",
            "about", "midnight,", "I", "turned", "the", "latch", "of", "his", "door", "and", "opened", "it", "/", "oh,",
            "so", "gently!", "And", "then,", "when", "I", "had", "made", "an", "opening", "sufficient", "for", "my",
            "head,", "I", "put", "in", "a", "dark", "lantern,", "all", "closed,", "closed,", "so", "that", "no",
            "light", "shone", "out,", "and", "then", "I", "thrust", "in", "my", "head.", "Oh,", "you", "would", "have",
            "laughed", "to", "see", "how", "cunningly", "I", "thrust", "it", "in!", "I", "moved", "it", "slowly",
            ".", "very,", "very", "slowly,", "so", "that", "I", "might", "not", "disturb", "the", "old", "man’s",
            "sleep.", "It", "took", "me", "an", "hour", "to", "place", "my", "whole", "head", "within", "the", "opening",
            "so", "far", "that", "I", "could", "see", "him", "as", "he", "lay", "upon", "his", "bed.", "Ha!", "~",
            "would", "a", "madman", "have", "been", "so", "wise", "as", "this?", "And", "then,", "when", "my", "head",
            "was", "well", "in", "the", "room,", "I", "undid", "the", "lantern", "cautiously", "+", "oh,", "so", "cautiously","True", "Nervous", "very", "very", "dreadfully", "nervous", "I", "had", "been", "and", "am", "but", "why", "will", "you", "say", "that", "I", "am", "mad",
            "The", "disease", "had", "sharpened", "my", "senses", "not", "destroyed", "not", "dulled", "them",
            "Above", "all", "was", "the", "sense", "of", "hearing", "acute",
            "I", "heard", "all", "things", "in", "the", "heaven", "and", "in", "the", "earth",
            "I", "heard", "many", "things", "in", "hell",
            "How", "then", "am", "I", "mad",
            "Hearken", "and", "observe", "how", "healthily", "how", "calmly", "I", "can", "tell", "you", "the", "whole", "story",
            "It", "is", "impossible", "to", "say", "how", "first", "the", "idea", "entered", "my", "brain", "but", "once", "conceived", "it", "haunted", "me", "day", "and", "night",
            "Object", "there", "was", "none",
            "Passion", "there", "was", "none",
            "I", "loved", "the", "old", "dog",
            "He", "had", "never", "wronged", "me",
            "He", "had", "never", "given", "me", "insult",
            "For", "his", "gold", "I", "had", "no", "desire",
            "I", "think", "it", "was", "his", "eye", "yes", "it", "was", "this",
            "One", "of", "his", "eyes", "resembled", "that", "of", "a", "vulture", "a", "pale", "blue", "eye", "with", "a", "film", "over", "it",
            "Whenever", "it", "fell", "upon", "me", "my", "blood", "ran", "cold", "and", "so", "by", "degrees", "very", "gradually", "I", "made", "up", "my", "mind", "to", "take", "the", "life", "of", "the", "old", "man", "and", "thus", "rid", "myself", "of", "the", "eye", "forever","On", "a", "crisp", "autumn", "morning", "the", "wind", "rustled", "through", "the", "trees", "carrying", "with", "it", "the", "scent", "of", "pine", "and", "fresh", "earth.",
"Sarah", "stood", "at", "the", "edge", "of", "the", "forest", "her", "heart", "racing.", "She", "had", "always", "wanted", "to", "explore", "these", "woods", "but", "something", "felt", "different", "today.",
"Her", "grandmother’s", "warning", "echoed", "in", "her", "mind:", "'Never", "go", "too", "deep", "into", "the", "forest", "child.", "It", "holds", "secrets", "that", "are", "not", "meant", "for", "wandering", "feet.'",
"But", "Emily", "had", "never", "been", "one", "to", "shy", "away", "from", "curiosity.", "Today", "the", "urge", "to", "explore", "seemed", "impossible", "to", "resist.",
"She", "took", "a", "deep", "breath", "and", "stepped", "forward", "the", "cool", "leaves", "crunching", "beneath", "her", "boots", "as", "she", "ventured", "deeper", "into", "the", "thicket.",
"The", "further", "she", "went", "the", "quieter", "the", "world", "became.", "The", "usual", "chatter", "of", "birds", "and", "insects", "faded", "into", "an", "eerie", "silence.",
"As", "she", "walked", "a", "peculiar", "shimmer", "caught", "her", "eye—something", "glistening", "in", "the", "distance", "hidden", "behind", "a", "thick", "veil", "of", "ivy.",
"With", "a", "mix", "of", "excitement", "and", "fear", "Sophia", "approached", "the", "shimmering", "object.", "It", "was", "a", "stone", "smooth", "and", "polished", "unlike", "anything", "she", "had", "ever", "seen.",
"Its", "surface", "seemed", "to", "ripple", "with", "an", "ethereal", "glow", "and", "as", "she", "reached", "out", "to", "touch", "it", "the", "stone", "pulsed", "with", "warmth", "making", "her", "hand", "tingle.",
"Suddenly", "the", "ground", "beneath", "her", "feet", "shifted", "and", "Louise", "stumbled", "backward.", "She", "caught", "her", "self", "on", "a", "nearby", "tree", "her", "pulse", "quickening.",
"'What", "was", "that?'", "she", "thought", "her", "mind", "racing.", "But", "the", "stone", "was", "no", "longer", "glowing", "and", "everything", "around", "her", "was", "still.",
"Jasmine", "hesitated", "unsure", "whether", "to", "continue", "or", "turn", "back.", "But", "the", "pull", "of", "the", "mysterious", "stone", "was", "too", "strong", "to", "ignore.",
"With", "trembling", "hands", "she", "picked", "it", "up.", "As", "soon", "as", "her", "fingers", "made", "contact", "with", "the", "surface", "a", "low", "hum", "filled", "the", "air", "and", "the", "world", "around", "her", "seemed", "to", "warp.",
"In", "an", "instant", "she", "was", "no", "longer", "standing", "in", "the", "forest.", "Instead", "she", "found", "her", "self", "on", "a", "narrow", "bridge", "suspended", "over", "a", "vast", "chasm", "the", "air", "heavy", "with", "an", "ancient", "energy.",
"The", "sky", "above", "was", "a", "swirling", "mix", "of", "violet", "and", "gold", "and", "strange", "creatures", "soared", "in", "the", "distance", "their", "wings", "gliding", "easily", "through", "the", "strange", "sky.",
"'Where", "am", "I?'", "Sophie", "whispered", "her", "voice", "barely", "audible", "against", "the", "sound", "of", "the", "wind.",
"A", "figure", "appeared", "before", "her—tall", "cloaked", "and", "shrouded", "in", "shadow.", "The", "figure’s", "face", "was", "hidden", "but", "Chloe", "could", "feel", "its", "gaze", "upon", "her.",
"'You", "have", "crossed", "into", "the", "realm", "of", "the", "forgotten,'", "the", "figure", "said", "its", "voice", "echoing", "like", "the", "whisper", "of", "wind", "through", "the", "trees.",
 "didn’t", "mean", "to,'", "Chloe", "stammered", "still", "clutching", "the", "stone.'", "I", "was", "just", "exploring.'",
"'Exploration", "often", "leads", "to", "discovery,'", "the", "figure", "answered", "cryptically.'", "But", "be", "warned", "child", "discovery", "comes", "at", "a", "price.'",
"Anna’s", "grip", "on", "the", "stone", "tightened.'", "What", "do", "you", "mean?", "What", "do", "you", "want", "from", "me?'", "she", "demanded", "her", "fear", "giving", "way", "to", "defiance.",
"The", "figure’s"

        };
        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged();
                }

            }
        }

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
            Textbox.Text = "Press start and begin typing";
            TxtInterval.Text = "---";
            lblCorrect.Content = "Correct " + _correct;
            lblIncorrect.Content = "Incorrect " + _incorrect;
            fullName.Text = "BEFORE STARTING!Please Double Click and Enter Your Full Name In Here!(Use spaces if necessary)";
            timer = new DispatcherTimer();


        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string proppertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proppertyName));
        }



        private void fullName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            fullName.Text = null;

            _fullName = fullName.Text;


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
        private void IsWordCorrect(object sender, KeyEventArgs e)
        {
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
            lblCorrect.Content = "Correct " + _correct;
            lblIncorrect.Content = "Incorrect " + _incorrect;
        }

        private void StartClicked(object sender, RoutedEventArgs e)
        {
            Textbox.Focus();


            //  timer = new DispatcherTimer();
            // timer.Interval = TimeSpan.FromSeconds(startCount);
            // timer.Tick += Timer_Tick;
            // timer.Start();
            TextBlock.Text = Story[random.Next(0, Story.Length)];
            Textbox.Text = null;
            _correct = 0;
            _incorrect = 0;
            lblCorrect.Content = "Correct " + _correct;
            lblIncorrect.Content = "Incorrect " + _incorrect;


            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(1);// TimeSpan.FromSeconds(startCount);
            timer.Start();


        }



        private void StopClicked(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            MessageBox.Show($"{_fullName} typed {_correct} correct words and {_incorrect} incorrect words");
            string message = $"{_fullName} typed {_correct} correct words and {_incorrect} incorrect words on {DateTime.Now}";

            string filePath = @"C:\TextFiles\TypingProject.txt";
             File.AppendAllText(filePath, message);
           // lines.Sort();
          //  lines.Add(message);

            Application.Current.Shutdown();

        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (startCount > minCount)
            {
                //   TxtInterval.Text = DateTime.Now.Second.ToString();

                TxtInterval.Text = startCount.ToString();
                startCount--;

                // TxtInterval.Text = timer.Interval.Seconds.ToString();
            }
            else if (startCount < minCount)
            {

                timer.Stop();

                MessageBox.Show($"{_fullName} typed {_correct} correct words and {_incorrect} incorrect words");
                string message = $"{_fullName} typed {_correct} correct words and {_incorrect} incorrect words on {DateTime.Now}";

                string filePath = @"C:\TextFiles\TypingProject.txt";
                File.AppendAllText(filePath, message);
                // lines.Sort();
                //  lines.Add(message);

                Application.Current.Shutdown();
            }
            else
            {
                timer.Stop();

                MessageBox.Show($"{_fullName} typed {_correct} correct words and {_incorrect} incorrect words");
                string message = $"{_fullName} typed {_correct} correct words and {_incorrect} incorrect words on {DateTime.Now}";

                string filePath = @"C:\TextFiles\TypingProject.txt";
                File.AppendAllText(filePath, message);
                // lines.Sort();
                //  lines.Add(message);

                Application.Current.Shutdown();
            }
            }
        }

       
    }
