using Syncfusion.Maui.Calendar;

namespace LongPressCallBack
{
    public class CalendarBehavior : Behavior<SfCalendar>
    {
        private SfCalendar calendar;

        protected override void OnAttachedTo(SfCalendar bindable)
        {
            base.OnAttachedTo(bindable);
            this.calendar = bindable;
            this.calendar.LongPressed += Calendar_LongPressed;
        }

        private void Calendar_LongPressed(object sender, CalendarLongPressedEventArgs e)
        {
            var mainPage = App.Current?.Windows.FirstOrDefault()?.Page;
            if (mainPage != null)
            {
                mainPage.DisplayAlert("DateCellHold Response", "DateCell " + e.Date.Day + " has been long pressed", "Ok");
            }
        }

        protected override void OnDetachingFrom(SfCalendar bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.calendar != null)
            {
                this.calendar.LongPressed -= Calendar_LongPressed;
            }

            this.calendar = null;
        }
    }
}
