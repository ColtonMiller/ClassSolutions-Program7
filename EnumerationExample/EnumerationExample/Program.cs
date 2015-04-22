using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerationExample
{
    public enum Colors
    {
        blue,
        black,
        red,
        green
    }

    public class Calendar
    {
        public enum Days
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        public List<Event> Plans { get; set; }

    }
    public class Event
    {
        public enum EventType
        {
            Party,
            GrillOut,
            Wedding,
            BusinessPlanMeeting
        }
        public EventType KindOfEvent { get; set; }

        public Event()
        {
            this.KindOfEvent = EventType.Party;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Calendar mycal = new Calendar();
            mycal.Plans.Where(x => x.KindOfEvent == Event.EventType.Wedding);

        }
    }
}
