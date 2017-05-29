using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using Oestbanehus.Models;
using System.Collections.ObjectModel;

namespace Oestbanehus.ViewModels
{
    class ConditionDetailVM : ViewModelBase
    {


        private ConditionsOfItem _condition;
        public ConditionsOfItem condition
        {
            get
            {
                return _condition;
            }
            set
            {
                Set(ref _condition, value);
            }
        }

       public ObservableCollection<Comment> comments { get; set; }

        private string _comment;
        public string comment
        {
            get
            {
                return _comment;
            }
            set
            {
                Set(ref _comment, value);
            }
        }

        DelegateCommand _addComment;
        public DelegateCommand addComment
            => _addComment ?? (_addComment = new DelegateCommand(() =>
            {
                Comment a = new Comment();
                a.ConditionId = condition.Id;
                a.Content = comment;
                a.PersonId = 1;
                a.PublishedDate = DateTime.Now;  
                Persistence.Persistence.addComment(a);
                comments.Add(a);
                

            }, () => true));

        public ConditionDetailVM()
        {
            comments = new ObservableCollection<Comment>();
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            shit((int)parameter);
            foreach (var item in condition.Comments)
            {
                comments.Add(item);
            }
        }

        public async void shit(int id)
        {
            condition = await Persistence.Persistence.getConditionDetails(id);     
        }

        public void GotoSettings() =>
           NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
