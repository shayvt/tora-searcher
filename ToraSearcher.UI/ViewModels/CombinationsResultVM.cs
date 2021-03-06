﻿using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using ToraSearcher.Entities;

namespace ToraSearcher.UI.ViewModels
{
    public class CombinationsResultVM : ViewModelBase
    {
        private string _word;
        public string Word
        {
            get
            {
                return _word;
            }
            set
            {
                _word = value;

                _highlightedWords.Clear();
                _highlightedWords.Add(_word);

                RaisePropertyChanged(() => Word);
                RaisePropertyChanged(() => HighlightedWords);
            }
        }

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;

                RaisePropertyChanged(() => Id);
            }
        }

        public string IdDisplay
        {
            get
            {
                return IsWord ? _id.ToString() : "";
            }
        }

        private bool _isWord;
        public bool IsWord
        {
            get
            {
                return _isWord;
            }
            set
            {
                _isWord = value;

                RaisePropertyChanged(() => IsWord);
            }
        }

        private Sentence _firstSentence;
        public Sentence FirstSentence
        {
            get
            {
                return _firstSentence;
            }
            set
            {
                _firstSentence = value;
                RaisePropertyChanged(() => FirstSentence);
                RaisePropertyChanged(() => FirstSentenceText);
            }
        }

        public string FirstSentenceBookName
        {
            get
            {
                return FirstSentence == null ? "" : FirstSentence.BookName;
            }
        }

        public string FirstSentenceChapterName
        {
            get
            {
                return FirstSentence == null ? "" : FirstSentence.ChapterName;
            }
        }

        public string FirstSentenceSentenceName
        {
            get
            {
                return FirstSentence == null ? "" : FirstSentence.SentenceName;
            }
        }

        public string FirstSentenceText
        {
            get
            {
                if (FirstSentence == null)
                    return "";

                if (FirstSentence.Text != null)
                    return FirstSentence.Text;

                var leftIndex = FoundWordIndex - 5 < 0 ? 0 : FoundWordIndex - 5;
                var count = FirstSentence.Words.Length - leftIndex > 10 ? 10 : FirstSentence.Words.Length - leftIndex;

                return string.Join(" ", FirstSentence.Words, leftIndex, count);
            }
        }

        public int FoundWordIndex { get; set; }

        private readonly ObservableCollection<string> _highlightedWords = new ObservableCollection<string>();
        public ObservableCollection<string> HighlightedWords
        {
            get
            {
                return _highlightedWords;
            }
        }
    }
}
