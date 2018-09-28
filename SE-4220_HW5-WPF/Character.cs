using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Character
    {
        private string lastName, firstName, height, weight;
        /*
        // Basic Information
        private string lastName,
            firstName,
            age,
            nationality,
            hometown,
            curhome,
            occupation,
            income,
            talentOrSkill,
            salary,
            birthOrder,
            siblings,
            spouse,
            children,
            grandparents,
            grandchildren,
            significantOthers,
            relationshpSkills,
            role;

        // Physical Characteristics
        private string height,
            weight,
            race,
            eyeColor,
            hairColor,
            skinColor,
            sightAid,
            faceShape,
            distinguishedFeatures,
            dress,
            mannerisms,
            habits,
            health,
            hobbies,
            favoriteQuotes,
            speechPattern,
            disabilities,
            style,
            flaws,
            qualities;

        // Intellectual/Mental/Personality Attributes and Attitudes
        private string education,
            mentalIllness,
            learningExperiences,
            shortGoals,
            longGoals,
            selfReflection,
            othersReflection,
            selfEsteem,
            logicEmotion,
            embarrassement;

        // Emotional
        private string strengths,
            weaknesses,
            verted,
            anger,
            sadness,
            conflict,
            change,
            loss,
            life,
            motivation,
            frightens,
            happy,
            judgmental,
            giving,
            friendly;

        // Relationship Mapping
        private string relationships;

        // Religous
        private string beliefs, religousRoles, behaviorChange;*/

        public string Name
        {
            get { return $"{FirstName} {LastName}"; }
        }
     
        public string FirstName
        {
            get { return firstName; }
            set
            {
                SetField(ref firstName, value);
                OnPropertyChanged(nameof(Name));
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                SetField(ref lastName, value);
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Height
        {
            get { return height; }
            set
            {
                SetField(ref height, value);
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Weight
        {
            get { return weight; }
            set
            {
                SetField(ref weight, value);
                OnPropertyChanged(nameof(Name));
            }
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
