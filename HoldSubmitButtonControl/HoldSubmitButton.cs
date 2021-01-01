using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace HoldSubmitButtonControl
{
    public class HoldSubmitButton : Button
    {
        private CancellationTokenSource _cancellationTokenSource;

        public static readonly DependencyProperty HoldDurationProperty =
            DependencyProperty.Register("HoldDuration", typeof(Duration), typeof(HoldSubmitButton),
                new PropertyMetadata(Duration.Automatic, null, CoerceHoldDuration));

        private static object CoerceHoldDuration(DependencyObject d, object baseValue)
        {
            if(baseValue is Duration duration && duration.TimeSpan.TotalSeconds >= 0.5)
            {
                return baseValue;
            }

            return new Duration(TimeSpan.FromSeconds(0.5));
        }

        public Duration HoldDuration
        {
            get { return (Duration)GetValue(HoldDurationProperty); }
            set { SetValue(HoldDurationProperty, value); }
        }

        public static readonly RoutedEvent HoldCompletedEvent =
            EventManager.RegisterRoutedEvent(nameof(HoldCompleted), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HoldSubmitButton));

        public event RoutedEventHandler HoldCompleted
        {
            add => AddHandler(HoldCompletedEvent, value);
            remove => RemoveHandler(HoldCompletedEvent, value);
        }

        public static readonly RoutedEvent HoldCancelledEvent =
            EventManager.RegisterRoutedEvent(nameof(HoldCancelled), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HoldSubmitButton));

        public event RoutedEventHandler HoldCancelled
        {
            add => AddHandler(HoldCancelledEvent, value);
            remove => RemoveHandler(HoldCancelledEvent, value);
        }

        static HoldSubmitButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HoldSubmitButton), new FrameworkPropertyMetadata(typeof(HoldSubmitButton)));
        }

        protected override async void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await Task.Delay((int)HoldDuration.TimeSpan.TotalMilliseconds, _cancellationTokenSource.Token);
                base.OnClick();

                RaiseEvent(new RoutedEventArgs(HoldCompletedEvent));
            }
            catch (TaskCanceledException) 
            {
                RaiseEvent(new RoutedEventArgs(HoldCancelledEvent));
            }

            base.OnMouseLeftButtonDown(e);
        }

        protected override void OnClick() { }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            CancelSubmit();
            base.OnMouseLeftButtonUp(e);
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            CancelSubmit();
            base.OnMouseLeave(e);
        }

        private void CancelSubmit()
        {
            if(_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
            }
        }
    }
}
