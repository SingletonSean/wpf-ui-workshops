using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HighlightTextBlockControl
{
    [TemplatePart(Name = TEXT_DISPLAY_PART_NAME, Type = typeof(TextBlock))]
    public class HighlightTextBlock : Control
    {
        private const string TEXT_DISPLAY_PART_NAME = "PART_TextDisplay";

        private TextBlock _displayTextBlock;

        public static readonly DependencyProperty HighlightTextProperty =
            DependencyProperty.Register("HighlightText", typeof(string), typeof(HighlightTextBlock),
                new PropertyMetadata(string.Empty, OnHighlightTextPropertyChanged));

        public string HighlightText
        {
            get { return (string)GetValue(HighlightTextProperty); }
            set { SetValue(HighlightTextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            TextBlock.TextProperty.AddOwner(typeof(HighlightTextBlock), 
                new PropertyMetadata(string.Empty, OnHighlightTextPropertyChanged));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty HighlightRunStyleProperty =
            DependencyProperty.Register("HighlightRunStyle", typeof(Style), typeof(HighlightTextBlock),
                new PropertyMetadata(CreateDefaultHighlightRunStyle()));

        private static object CreateDefaultHighlightRunStyle()
        {
            Style style = new Style(typeof(Run));
            style.Setters.Add(new Setter(Run.BackgroundProperty, Brushes.Yellow));

            return style;
        }

        public Style HighlightRunStyle
        {
            get { return (Style)GetValue(HighlightRunStyleProperty); }
            set { SetValue(HighlightRunStyleProperty, value); }
        }

        static HighlightTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HighlightTextBlock), new FrameworkPropertyMetadata(typeof(HighlightTextBlock)));
        }

        public override void OnApplyTemplate()
        {
            _displayTextBlock = Template.FindName(TEXT_DISPLAY_PART_NAME, this) as TextBlock;
            UpdateHighlightDisplay();

            base.OnApplyTemplate();
        }

        private static void OnHighlightTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is HighlightTextBlock highlightTextBlock)
            {
                highlightTextBlock.UpdateHighlightDisplay();
            }
        }

        private void UpdateHighlightDisplay()
        {
            if(_displayTextBlock != null)
            {
                _displayTextBlock.Inlines.Clear();

                int highlightTextLength = HighlightText.Length;
                if(highlightTextLength == 0)
                {
                    _displayTextBlock.Text = Text;
                }
                else
                {
                    for (int i = 0; i < Text.Length; i++)
                    {
                        if(i + highlightTextLength > Text.Length)
                        {
                            _displayTextBlock.Inlines.Add(new Run(Text.Substring(i)));
                            break;
                        }

                        int nextHighlightTextIndex = Text.IndexOf(HighlightText, i);
                        if(nextHighlightTextIndex == -1)
                        {
                            _displayTextBlock.Inlines.Add(new Run(Text.Substring(i)));
                            break;
                        }

                        _displayTextBlock.Inlines.Add(new Run(Text.Substring(i, nextHighlightTextIndex - i)));
                        _displayTextBlock.Inlines.Add(CreateHighlightedRun(HighlightText));

                        i = nextHighlightTextIndex + highlightTextLength - 1;
                    }
                }    
            }
        }

        private Run CreateHighlightedRun(string text)
        {
            return new Run(text)
            {
                Style = HighlightRunStyle
            };
        }
    }
}
