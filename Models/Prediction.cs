using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP2_POO2.Models
{
    public class Prediction : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        public int Id { get; set; }
        private float _cp { get; set; }
        public float Cp
        {
            get { return this._cp; }
            set
            {
                if (this._cp != value)
                {
                    this._cp = (int)value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private float _oldpeak { get; set; }
        public float Oldpeak
        {
            get { return this._oldpeak; }
            set
            {
                if (this._oldpeak != value)
                {
                    this._oldpeak = (int)value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private float _thalach { get; set; }
        public float Thalach
        {
            get { return this._thalach; }
            set
            {
                if (this._thalach != value)
                {
                    this._thalach = (int)value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private float _thal { get; set; }
        public float Thal
        {
            get { return this._thal; }
            set
            {
                if (this._thal != value)
                {
                    this._thal = (int)value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private bool _target { get; set; }
        public bool Target
        {
            get { return this._target; }
            set
            {
                if (this._target != value)
                {
                    this._target = value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private float _ca { get; set; }
        public float Ca
        {
            get { return this._ca; }
            set
            {
                if (this._ca != value)
                {
                    this._ca = (int)value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
      

        private string _resultat { get; set; }
        public string Resultat
        {
            get { return this._resultat; }
            set
            {
                if (this._resultat != value)
                {
                    this._resultat = value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        private bool _isValid;

        public bool IsValid
        {
            get { return this._isValid; }
        }

        private void SetIsValid()
        {
            this._isValid = !(this.Cp == 0f) && !(this.Oldpeak == 0f) && !(this.Thalach == 0f) && !(this.Thal == 0f) && !(this.Ca == 0f) &&  !(this.PatientId == 0);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
