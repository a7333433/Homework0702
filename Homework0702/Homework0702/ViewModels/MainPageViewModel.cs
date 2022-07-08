using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework0702.ViewModels
{

    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;

        public string Question { get; set; }
        public string ResultMessage { get; set; }
        public string Answer { get; set; }
        private int r1 { get; set; }
        private int r2 { get; set; }
        public DelegateCommand SubmitAnswer { get; set; }
        public DelegateCommand CreateQuestion { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            SubmitAnswer = new DelegateCommand(OnSubmitAnswerClick);
            CreateQuestion = new DelegateCommand(OnCreateQuestionClick);
            OnCreateQuestionClick();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        private void OnSubmitAnswerClick()
        {
            if (int.TryParse(Answer, out int result) && result == r1 + r2)
                ResultMessage = "正確!";
            else
                ResultMessage = "錯誤!";

        }

        private void OnCreateQuestionClick()
        {
            r1 = new Random(DateTime.Now.Millisecond).Next(1, 100);
            r2 = new Random(DateTime.Now.Millisecond).Next(1, 100);
            ResultMessage = "";
            Answer = "";
            Question = $@"{r1} + {r2} = ?";
        }
    }
}
