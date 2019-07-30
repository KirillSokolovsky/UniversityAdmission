namespace UniversityAdmission
{
    using ReactiveUI;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UniversityAdmission.Models;

    public class MainModel : ReactiveObject
    {
        private ObservableCollection<UniversityModel> _universities = new ObservableCollection<UniversityModel>();
        public ObservableCollection<UniversityModel> Universities
        {
            get => _universities;
            set => this.RaiseAndSetIfChanged(ref _universities, value);
        }

        private string _filter = "Криницкий";
        public string Filter
        {
            get => _filter;
            set => this.RaiseAndSetIfChanged(ref _filter, value);
        }
    }
}
