namespace ClassLibrary_OneTime
{
    public class Class_Time

    using System;

namespace ClassLibrary_OneTime
    {
        public class Time
        {
            private int hours;
            private int minutes;
            private int seconds;
            private int milliseconds;
            private bool isValid;

            // 1) Constructor sin parámetros
            public Time()
            {
                this.hours = 0;
                this.minutes = 0;
                this.seconds = 0;
                this.milliseconds = 0;
                this.isValid = true;
            }

            // 2) Constructor con horas
            public Time(int hours) : this(hours, 0, 0, 0) { }

            // 3) Constructor con horas y minutos
            public Time(int hours, int minutes) : this(hours, minutes, 0, 0) { }

            // 4) Constructor con horas, minutos y segundos
            public Time(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0) { }

            // 5) Constructor con horas, minutos, segundos y milisegundos
            public Time(int hours, int minutes, int seconds, int milliseconds)
            {
                if (hours < 0 || hours > 23 ||
                    minutes < 0 || minutes > 59 ||
                    seconds < 0 || seconds > 59 ||
                    milliseconds < 0 || milliseconds > 999)
                {
                    this.isValid = false;
                    throw new ArgumentException("Hora no válida");
                }
                else
                {
                    this.hours = hours;
                    this.minutes = minutes;
                    this.seconds = seconds;
                    this.milliseconds = milliseconds;
                    this.isValid = true;
                }
            }

            // Métodos de conversión
            public long ToMilliseconds()
            {
                if (!isValid) return 0;
                return ((hours * 3600L + minutes * 60L + seconds) * 1000L) + milliseconds;
            }

            public long ToSeconds()
            {
                if (!isValid) return 0;
                return (hours * 3600L) + (minutes * 60L) + seconds;
            }

            public long ToMinutes()
            {
                if (!isValid) return 0;
                return (hours * 60L) + minutes;
            }

            // Método IsOtherDay
            public bool IsOtherDay(Time other)
            {
                if (!isValid || !other.isValid) return false;
                long totalMillis = this.ToMilliseconds() + other.ToMilliseconds();
                long millisPerDay = 24 * 3600 * 1000;
                return totalMillis >= millisPerDay;
            }

            // Método Add
            public Time Add(Time other)
            {
                if (!isValid || !other.isValid) return new Time();

                int newMilliseconds = this.milliseconds + other.milliseconds;
                int carrySeconds = newMilliseconds / 1000;
                newMilliseconds %= 1000;

                int newSeconds = this.seconds + other.seconds + carrySeconds;
                int carryMinutes = newSeconds / 60;
                newSeconds %= 60;

                int newMinutes = this.minutes + other.minutes + carryMinutes;
                int carryHours = newMinutes / 60;
                newMinutes %= 60;

                int newHours = this.hours + other.hours + carryHours;
                newHours %= 24; // si pasa de 23, se reinicia (otro día)

                return new Time(newHours, newMinutes, newSeconds, newMilliseconds);
            }

            // ToString en formato 12h con AM/PM
            public override string ToString()
            {
                if (!isValid) return "Hora inválida";

                DateTime dt = new DateTime(1, 1, 1, hours, minutes, seconds, milliseconds);
                return dt.ToString("hh:mm:ss.fff tt");
            }
        }
    }
