using System;

namespace ClassLibrary_OneTime
{
    public class Time
    {
        private int hours, minutes, seconds, milliseconds;
        private bool isValid;

        
        public Time() : this(0, 0, 0, 0) { }

       
        public Time(int hours) : this(hours, 0, 0, 0) { }

        public Time(int hours, int minutes) : this(hours, minutes, 0, 0) { }

        
        public Time(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0) { }

        