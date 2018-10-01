using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HW5.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public BindingList<Character> Characters { get; set; }
        public List<string> CharacterTraits { get; set; }
        private readonly DelegateCommand<string> _clickCharViewListCommand;

        public MainViewModel()
        {
            Characters = new BindingList<Character>(new[]
            {
                new Character{FirstName="Jim",LastName="Bob", Height="123.45", Weight="300lbs"},
                new Character{FirstName="Joe",LastName="Bob", Height="223.45", Weight="178lbs"},
                new Character{FirstName="Jack",LastName="Bob", Height="323.45", Weight="400kgs"},
                new Character{FirstName="Jill",LastName="Bob", Height="423.45", Weight="138lbs"},
            }.ToList());
            CharacterTraits = new List<string>(new[]
            {
                "Basic Overview",
                "Physical Characteristics",
                "Intellectual, Mental, Personality Attitudes",
                "Emotional",
                "Spiritual"
            });

            _clickCharViewListCommand = new DelegateCommand<string>(
                (s) => 
                { /* perform some action */
                    if (IsCharListOpen == false)
                        IsCharListOpen = true;
                    else
                        IsCharListOpen = false;
                }, //Execute
                (s) => { return !string.IsNullOrEmpty(_input); } //CanExecute
           );

        }

        public DelegateCommand<string> CharViewListCommand
        {
            get { return _clickCharViewListCommand; }
        }

        private string _input = "can execute";
        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                _clickCharViewListCommand.RaiseCanExecuteChanged();
            }
        }

        private bool isCharListOpen;
        public bool IsCharListOpen
        {
            get { return isCharListOpen; }
            set
            {
                isCharListOpen = value;
                OnPropertyChanged(nameof(IsCharListOpen));
            }
        }

        public string SelectedTrait { get; set; }
        //private List<string> SelectedTrait;
        public List<string> TraitList
        {
            get { return CharacterTraits; }
            //set { SetField(ref SelectedTrait, value); }
        }

        private Character selectedCharacter;
        public Character SelectedCharacter
        {
            get { return selectedCharacter;  }
            set { SetField(ref selectedCharacter, value);  }
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

    }
}
