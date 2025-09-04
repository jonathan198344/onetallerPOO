//using System;

using System;

namespace ClassLibrary_OneTime
{
    public class Time
    {
        private int hours, minutes, seconds, milliseconds;
        private bool isValid;

        // 1) sin parámetros
        public Time() : this(0, 0, 0, 0) { }

        // 2) con horas
        public Time(int hours) : this(hours, 0, 0, 0) { }

        // 3) con horas y minutos
        public Time(int hours, int minutes) : this(hours, minutes, 0, 0) { }

        // 4) con horas, minutos y segundos
        public Time(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0) { }

        // 5) con horas, minutos, segundos y milisegundos
        public Time(int hours, int minutes, int seconds, int milliseconds)
        {
            if (hours < 0 || hours > 23 ||
                minutes < 0 || minutes > 59 ||
                seconds < 0 || seconds > 59 ||
                milliseconds < 0 || milliseconds > 999)
                throw new ArgumentOutOfRangeException("Hora no válida");

            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.milliseconds = milliseconds;
            this.isValid = true;
        }

        public long ToMilliseconds() =>
            ((hours * 3600L + minutes * 60L + seconds) * 1000L) + milliseconds;

        public long ToSeconds() =>
            (hours * 3600L) + (minutes * 60L) + seconds;

        public long ToMinutes() =>
            (hours * 60L) + minutes;

        public bool IsOtherDay(Time other)
        {
            long total = this.ToMilliseconds() + other.ToMilliseconds();
            return total >= 24L * 3600 * 1000;
        }

        public Time Add(Time other)
        {
            int ms = milliseconds + other.milliseconds;
            int carryS = ms / 1000; ms %= 1000;

            int s = seconds + other.seconds + carryS;
            int carryM = s / 60; s %= 60;

            int m = minutes + other.minutes + carryM;
            int carryH = m / 60; m %= 60;

            int h = (hours + other.hours + carryH) % 24;

            return new Time(h, m, s, ms);
        }

        public override string ToString()
        {
            var dt = new DateTime(1, 1, 1, hours, minutes, seconds, milliseconds);
            return dt.ToString("hh:mm:ss.fff tt");
        }
    }
}





