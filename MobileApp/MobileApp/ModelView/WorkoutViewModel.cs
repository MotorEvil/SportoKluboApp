using MobileApp.Models;
using MobileApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ModelView
{
    public class WorkoutViewModel : INotifyPropertyChanged
    {
        private List<Treniruote> workouts;

        private DataService _dataService = new DataService();

        public List<Treniruote> Workouts
        {
            get { return workouts; }
            set
            {
                workouts = value;
                OnPropertyChanged();
            }
        }

        public WorkoutViewModel()
        {
            _ = Getworkout();
        }

        private async Task Getworkout()
        {

            Workouts = await _dataService.GetTreniruotes();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
